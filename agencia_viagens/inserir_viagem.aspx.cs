using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace agencia_viagens
{
    public partial class inserir_viagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btn_inserir_sp_Click(object sender, EventArgs e)
        {

            string[] dataIda = tb_dataIda.Text.ToString().Split(' ');
            string[] dataVolta = tb_dataVolta.Text.ToString().Split(' ');


            string src = Server.MapPath("/");
            
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            
            FileUpload1.PostedFile.SaveAs(src + "images/viagens/" + fileName); 

            /*
              HttpPostedFile image = Request.Files["src_imagem"];
              Response.Write("imagem1 " + image.FileName); 
              if (image != null && image.ContentLength > 0)
               {
                     Response.Write("imagem2 " + image);
                   src = Path.GetFileName(image.FileName);
                   image.SaveAs(Server.MapPath(Path.Combine("~/images/viagens/", src)));

               }*/

            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
            // using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString))
            {

                myConn.Open();


                using (SqlCommand command = new SqlCommand())
                {

                    command.Parameters.AddWithValue("@titulo", tb_titulo.Text);
                    command.Parameters.AddWithValue("@descricao", tb_descricao.Text);
                    command.Parameters.AddWithValue("@data_ida", dataIda[0]);
                    command.Parameters.AddWithValue("@data_volta", dataVolta[0]);
                    command.Parameters.AddWithValue("@preco", tb_preco.Text);
                    command.Parameters.AddWithValue("@src", src + "images/viagens/" + fileName);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "inserir_viagem";
                    command.Connection = myConn;
                    command.ExecuteNonQuery();

                    lbl_mensagem.Text = "Viagem inserida com sucesso";

                }
                myConn.Close();
                tb_titulo.Text = "";
                tb_descricao.Text = "";
                tb_dataIda.Text = "";
                tb_dataVolta.Text = "";



            }
        }
    }
}