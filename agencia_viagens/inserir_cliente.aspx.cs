using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agencia_viagens
{

    public partial class criar_conta : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /* Encriptação*/
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

        /*inserir na BD */
        protected void btn_inserir_sp_Click(object sender, EventArgs e)
        {
            if (ValidaPW(tb_pass.Text))
            {
                try
                {

                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString);
                    // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString);

                    SqlCommand myCommand = new SqlCommand();
                    myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
                    myCommand.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                    myCommand.Parameters.AddWithValue("@palavra_passe", EncryptString(tb_pass.Text).Trim());
                    myCommand.Parameters.AddWithValue("@morada", tb_address.Text);
                    myCommand.Parameters.AddWithValue("@telefone", tb_phone.Text);
                    myCommand.Parameters.AddWithValue("@validade_da_conta", tb_date.Text);
                    myCommand.Parameters.AddWithValue("@perfil", ddl_perfil.Text);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "inserir_cliente";

                    SqlParameter res = new SqlParameter();
                    res.ParameterName = "@retorno";
                    res.Direction = ParameterDirection.Output;
                    res.SqlDbType = SqlDbType.Int;
                    res.Size = 500;
                    myCommand.Parameters.Add(res);
                    myCommand.Connection = conn;
                    conn.Open();
                    myCommand.ExecuteNonQuery();

                    int resposta = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);


                    if (resposta == 1)
                    {
                        lbl_mensagem.Visible = true;
                        lbl_mensagem.Text = "Success";
                    }
                    else
                    {
                        lbl_mensagem.Visible = true;
                        lbl_mensagem.Text = "User already exists";
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
            else
            {
                lbl_mensagem.Visible = true;
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
    }
}