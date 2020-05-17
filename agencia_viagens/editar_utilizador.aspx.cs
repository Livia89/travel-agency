using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace agencia_viagens
{
    public partial class editar_utilizador : System.Web.UI.Page
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
                        command.Parameters.AddWithValue("@id_cliente", num);

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "devolve_cliente";
                        command.Connection = myConn;

                        using (SqlDataReader data = command.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                string[] dataBD = new string[] { };

                                while (data.Read())
                                {

                                    tb_nome.Text = data["nome"].ToString();
                                    tb_address.Text = data["morada"].ToString();
                                    tb_email.Text = data["email"].ToString();
                                    tb_phone.Text = data["telefone"].ToString();
                                    dataBD = data["validade_da_conta"].ToString().Split(' ');
                                    ddl_perfil.SelectedValue = data["perfil"].ToString();

                                }
                                DateTime dataClt = Convert.ToDateTime(dataBD[0]);
                                tb_date.Text = dataClt.ToString("yyyy-MM-dd");
                            }

                        }
                    }
                    myConn.Close();
                }
            }
        }

        protected void btn_inserir_sp_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(Request.QueryString["id"]);


            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["agencia_BDConnectionString"].ConnectionString))
            {

                myConn.Open();

                int revendedor = CheckBox1.Checked ? 1 : 0;
                using (SqlCommand command = new SqlCommand())
                {
                    DateTime data = Convert.ToDateTime(tb_date.Text);

                    command.Parameters.AddWithValue("@id_cliente", num);
                    command.Parameters.AddWithValue("@nome", tb_nome.Text);
                    command.Parameters.AddWithValue("@morada", tb_address.Text);
                    command.Parameters.AddWithValue("@telefone", tb_phone.Text);
                    command.Parameters.AddWithValue("@perfil", ddl_perfil.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@validade_da_conta", data);
                    command.Parameters.AddWithValue("@revendedor", revendedor);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "editar_cliente";
                    command.Connection = myConn;
                    command.ExecuteNonQuery();


                }
                myConn.Close();

            }
        }
    }
}