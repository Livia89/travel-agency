using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace agencia_viagens
{
    public partial class criar_conta1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_inserir_sp_Click(object sender, EventArgs e)
        {

            DateTime dataDaConta = DateTime.Now.AddYears(5);
            string data = dataDaConta.ToString("yyyy-MM-dd");


            if (ValidaPW(tb_pass.Text))
            {
                string token = EncryptString(tb_email.Text);
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
                // using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString))
                {

                    myConn.Open();


                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Parameters.AddWithValue("@nome", tb_nome.Text);
                        command.Parameters.AddWithValue("@morada", tb_address.Text);
                        command.Parameters.AddWithValue("@email", tb_email.Text);
                        command.Parameters.AddWithValue("@telefone", tb_phone.Text);
                        command.Parameters.AddWithValue("@validade_da_conta", data); 
                        command.Parameters.AddWithValue("@pass", EncryptString(tb_pass.Text));
                        command.Parameters.AddWithValue("@token", token);
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "criar_conta";
                        SqlParameter retorno = new SqlParameter();
                        retorno.ParameterName = "@retorno";
                        retorno.Direction = ParameterDirection.Output;
                        retorno.SqlDbType = SqlDbType.Int;
                        retorno.Size = 100;
                        command.Parameters.Add(retorno);
                        command.Connection = myConn;
                        command.ExecuteNonQuery();

                        int resposta = Convert.ToInt32(command.Parameters["@retorno"].Value);

                        switch (resposta)
                        {
                            case 2:
                                lbl_mensagem.Text = "Utilizador já registado, verifique o seu email";
                                break;

                            case 1:
                                lbl_mensagem.Text = "O utilizador já existe";

                                break;
                            default:
                                lbl_mensagem.Text = "Conta criada! Confirme o seu email";

                                MailMessage mail = new MailMessage();
                                SmtpClient sc = new SmtpClient();

                                mail.From = new MailAddress("liviapriscilla1989@gmail.com");
                                mail.To.Add(new MailAddress(tb_email.Text));
                                sc.Credentials = new System.Net.NetworkCredential("liviapriscilla1989@gmail.com", "");
                                mail.Subject = "Obrigada por te registares na Gold Excursões";
                                mail.IsBodyHtml = true;
                                mail.Body = ("<table align='center' width='661' cellspacing='2' cellpadding='2' border='0'><tbody><tr><td style = 'text-align:center' ><a href = 'http://localhost:60849/home.aspx' target = '_blank'>" +
                                    "<img border = '0' src = 'http://localhost:60849/images/aviao.jpg' width = '200' alt = 'Gold Excursões'>" +
                                    "</a></td></tr><tr><td style = 'padding:20px;font-size:12px'>" +
                                    "<h1> Bem vindo(a) à<span class='il'> Gold Excursões</span>.pt</h1></br>" +
                                    "<b>Olá " + tb_nome.Text + " :) </b>" +
                                    "<p>Enviamos-lhe as credenciais de acesso para a loja da <a href = 'http://localhost:60849/home.aspx' target='_blank'><span class='il'>Gold Excursões</span>.pt</a></p>" +
                                    "<p>Email: <a href = 'mailto:" + tb_email.Text + "' target='_blank'>" + tb_email.Text + "</a> </p>" +
                                    "<p>Palavra-passe : " + tb_pass.Text + "</p>" +
                                    "<h3><p>Clica<a href='http://localhost:60849/validar_conta.aspx?token=" + token + "' target='_blank'> Aqui</a> para validares a tua conta</p></h3>" +
                                    "Se o link não funcionar corretamente, copia este url e cola-o no teu navegador/browser." +
                                    "http://localhost:60849/validar_conta.aspx?token=" + token +
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
                                    lbl_mensagem.Text = ex.ToString();
                                }
                                break;




                        }
                        myConn.Close();
                    }
                }
            }
            else
            {
                lbl_mensagem.Text = "Insira uma password forte";
            }

        }

        /* Validar palavra-passe*/
        private Boolean ValidaPW(string password)
        {
            int minLength = 6;
            int minUpper = 1;
            int minLower = 1;
            int minSpecial = 1;
            int minNumbers = 1;

            Regex upper = new Regex("[A-Z]");
            Regex lower = new Regex("[a-z]");
            Regex number = new Regex("[0-9]");
            Regex special = new Regex("[^a-zA-Z0-9]"); // Se não tiver nenhum desses caracteres é especial
            Regex plica = new Regex("'");


            if (password.Length < minLength) return false;
            if (upper.Matches(password).Count < minUpper) return false;
            if (lower.Matches(password).Count < minLower) return false;
            if (number.Matches(password).Count < minNumbers) return false;
            if (special.Matches(password).Count < minSpecial) return false;
            if (plica.Matches(password).Count > 0) return false;

            return true;
        }

        public static string EncryptString(string Message)
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

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string

            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("\\", "III");
            return enc;
        }

    }
}