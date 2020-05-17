using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agencia_viagens
{
    public partial class recuperar_pw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void send_Click(object sender, EventArgs e)
        {
              using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
            // using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString))

            {

                myConn.Open();


                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@email", tb_email.Text);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "devolve_pw_by_email";
                    SqlParameter retorno = new SqlParameter();
                    retorno.ParameterName = "@retorno";
                    retorno.Direction = ParameterDirection.Output;
                    retorno.SqlDbType = SqlDbType.VarChar;
                    retorno.Size = 500;
                    command.Parameters.Add(retorno);
                    command.Connection = myConn;
                    command.ExecuteNonQuery();

                    string pw = (command.Parameters["@retorno"].Value).ToString();

                    switch (pw)
                    {
                        case "0":

                            lbl_msg.Text = "Este email não está registado";

                            break;
                        case "1":
                            lbl_msg.Text = "Este conta não está ativa";
                            break;
                        default:
                            lbl_msg.Text = "Palavra-passe enviada, confirme o seu email.";
                            //Session["sucesso"] = "true";

                            MailMessage mail = new MailMessage();
                            SmtpClient sc = new SmtpClient();

                            mail.From = new MailAddress("liviapriscilla1989@gmail.com");
                            mail.To.Add(new MailAddress(tb_email.Text));
                            sc.Credentials = new System.Net.NetworkCredential("liviapriscilla1989@gmail.com", "_");
                            mail.Subject = "Recuperação de palavra-passe | Gold Excursões";
                            mail.IsBodyHtml = true;
                            mail.Body = ("<table align='center' width='661' cellspacing='2' cellpadding='2' border='0'><tbody><tr><td style = 'text-align:center' ><a href = 'http://localhost:60849/home.aspx' target = '_blank'>" +
                                         "<img border = '0' src = 'http://localhost:60849/images/aviao.jpg' width = '200' alt = 'Gold Excursões'>" +
                                         "</a></td></tr><tr><td style = 'padding:20px;font-size:12px'>" +
                                         "<h1> Bem vindo(a) à<span class='il'> Gold Excursões</span>.pt</h1></br>" +
                                         "<b>Olá Viajante :) </b>" +
                                         "<p>Enviamos-lhe as credenciais de acesso para a loja da <a href = 'http://localhost:60849/home.aspx' target='_blank'><span class='il'>Gold Excursões</span>.pt</a></p>" +
                                         "<p>Email: <a href = 'mailto:" + tb_email.Text + "' target='_blank'>" + tb_email.Text + "</a> </p>" +
                                         "<p>Palavra-passe : " + DecryptString(pw) + "</p>" +
                                         "<p> <a href='http://localhost:60849/login.aspx?email=" + tb_email.Text + "'>Clique aqui</a></p> para fazer login " +
                                         "<p>Obrigada :) </p>" +
                                         "<small><a href = 'http://localhost:60849/home.aspx' target='_blank'>Gold Excursões</a>" +
                                         "</small></td></tr><tr><td style = 'background-color: #53b5f8;padding:10px 0' > &nbsp;</td></tr><tr>" +
                                         "<td style='text-align:center;color:gray;font-size:10px;line-height:14px'>" +
                                         "<br>Página Web: <a href = 'http://localhost:60849/home.aspx' target='_blank'>https://www.<span class='il'>goldexcursoes</span>.pt</a>" +
                                         "<br>E-mail: <a href = 'mailto:geral@goldexcursoes.pt' target='_blank'>geral@<span class='il'>goldexcursoes</span>.pt</a><br>Contacto: 123 456 789</td></tr></tbody></table>");
                            sc.EnableSsl = true;


                            sc.Host = "smtp.gmail.com";
                            sc.Port = 587;//porto que o gmail utiliza
                            try
                            {
                                sc.Send(mail);
                            }
                            catch (Exception ex)
                            {
                                lbl_msg.Text = ex.ToString();
                            }
                            break;
                    }


                }
                myConn.Close();

            }
        }



        public static string DecryptString(string Message)
        {
            string Passphrase = "cinel";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]

            Message = Message.Replace("KKK", "+");
            Message = Message.Replace("JJJ", "/");
            Message = Message.Replace("III", "\\");


            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

    }
}