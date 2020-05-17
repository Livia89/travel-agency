using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agencia_viagens
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
        

            if (Request.QueryString["email"] != null)
            {
                tb_email.Text = Request.QueryString["email"].ToString();
            }
        }

        protected void tb_enviar_Click(object sender, EventArgs e)
        {
           
            try
            {
                  conn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString);
                //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString);

                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                myCommand.Parameters.AddWithValue("@palavra_passe", EncryptString(tb_pass.Text).Trim());
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "login";
                SqlParameter user = new SqlParameter();
                user.ParameterName = "@retorno";
                user.Direction = ParameterDirection.Output;
                user.SqlDbType = SqlDbType.Char;
                user.Size = 500;
                myCommand.Parameters.Add(user);
                SqlParameter cod_cliente = new SqlParameter();
                cod_cliente.ParameterName = "@cod_cliente";
                cod_cliente.Direction = ParameterDirection.Output;
                cod_cliente.SqlDbType = SqlDbType.Int;
                cod_cliente.Size = 500;
                myCommand.Parameters.Add(cod_cliente);

                myCommand.Connection = conn;
                conn.Open();
                myCommand.ExecuteNonQuery();

                string resposta = myCommand.Parameters["@retorno"].Value.ToString();
                if (myCommand.Parameters["@cod_cliente"].Value.ToString() != "")
                {
                    int codCliente = Convert.ToInt32(myCommand.Parameters["@cod_cliente"].Value);
                    Session["id_cliente"] = codCliente;

                }


                switch (resposta.Trim())
                 {
                     case "0":
                         lbl_error.Visible = true;
                         break;
                     case "1":
                         lbl_texto.Visible = true;
                         break;
                     case "2":
                         lbl_texto.Visible = true;
                         lbl_texto.Text = "Conta inexistente";
                         break;
                     case "3":
                         lbl_texto.Visible = true;
                         lbl_texto.Text = "A sua conta não esta ativa, verifique o seu email.";
                         break;
                     default:
                         Session["login"] = resposta;
                         Response.Redirect("home.aspx");
                         break;
                 }
                         
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
            finally
            {
                conn.Close();
            }
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