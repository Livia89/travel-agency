using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agencia_viagens
{
    public partial class listar_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string eliminado = Request.QueryString["eliminado"];

                if (eliminado == "1")
                {

                    ClientScript.RegisterClientScriptBlock(e.GetType(), "modal", "<script>alert('Apagado com sucesso!');</script>");
                }
            }
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem; // Dados que vem do SQL
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] data = dr["validade_da_conta"].ToString().Split(' ');

                ((Label)e.Item.FindControl("lbl_nome")).Text = dr["nome"].ToString();
                ((Label)e.Item.FindControl("lbl_morada")).Text = dr["morada"].ToString();
                ((Label)e.Item.FindControl("lbl_email")).Text = dr["email"].ToString();
                ((Label)e.Item.FindControl("lbl_telefone")).Text = dr["telefone"].ToString();
                ((Label)e.Item.FindControl("lbl_data")).Text = data[0].ToString();
                ((Label)e.Item.FindControl("lbl_perfil")).Text = dr["perfil"].ToString();
                ((LinkButton)e.Item.FindControl("btn_edita")).CommandArgument = dr["id_cliente"].ToString();
                ((LinkButton)e.Item.FindControl("btn_elimina")).CommandArgument = dr["id_cliente"].ToString();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {



            if (e.CommandName.Equals("btn_edita"))
            {
                Response.Redirect("http://localhost:60849/editar_utilizador.aspx?id=" + (((LinkButton)e.Item.FindControl("btn_edita")).CommandArgument).ToString());
            }
            else if (e.CommandName.Equals("btn_elimina"))
            {

                SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);
                con.Open();

                int num = Convert.ToInt32(((LinkButton)e.Item.FindControl("btn_elimina")).CommandArgument);
                string email = ((Label)e.Item.FindControl("lbl_email")).Text;
                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@num_cliente", num);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "elimina_utilizadorTODOSREGISTOS";
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();

                Response.Redirect("http://localhost:60849/backoffice.aspx?eliminado=1");

            }
        }
    }
}