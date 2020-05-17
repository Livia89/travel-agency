using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace agencia_viagens
{
    public partial class editar_viagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {

                // using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString))
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
                {
                    myConn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@id_viagem", num);
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "devolve_viagem";
                        command.Connection = myConn;

                        using (SqlDataReader data = command.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                string[] dataIda = new string[] { };
                                string[] dataVolta = new string[] { };

                                while (data.Read())
                                {

                                    tb_titulo.Text = data["titulo"].ToString();
                                    tb_descricao.Text = data["descricao"].ToString();
                                    dataIda = data["data_ida"].ToString().Split(' ');
                                    dataVolta = data["data_volta"].ToString().Split(' ');
                                    tb_preco.Text = data["preco"].ToString();

                                }
                                DateTime dataI = Convert.ToDateTime(dataIda[0]);
                                tb_dataIda.Text = dataI.ToString("yyyy-MM-dd");

                                DateTime dataV = Convert.ToDateTime(dataVolta[0]);
                                tb_dataVolta.Text = dataV.ToString("yyyy-MM-dd");
                            }

                        }
                    }
                    myConn.Close();
                }
            }


        }

        /* MUDAR A QUERY DEPOIS PARA ACEITAR IMAGENS */
        protected void btn_inserir_sp_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(Request.QueryString["id"]);


            //using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agenciaPC_BDConnectionString"].ConnectionString))

            {

                myConn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    DateTime dataI = Convert.ToDateTime(tb_dataIda.Text);
                    DateTime dataV = Convert.ToDateTime(tb_dataVolta.Text);

                    command.Parameters.AddWithValue("@id_viagem", num);
                    command.Parameters.AddWithValue("@titulo", tb_titulo.Text);
                    command.Parameters.AddWithValue("@descricao", tb_descricao.Text);
                    command.Parameters.AddWithValue("@data_ida", dataI);
                    command.Parameters.AddWithValue("@data_volta", dataV);
                    command.Parameters.AddWithValue("@preco", tb_preco);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "editar_viagem";
                    command.Connection = myConn;
                    command.ExecuteNonQuery();


                }
                myConn.Close();

            }
        }
    }
}