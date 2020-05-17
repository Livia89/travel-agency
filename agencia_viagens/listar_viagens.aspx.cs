using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace agencia_viagens
{
    public partial class listar_viagens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                string eliminado = Request.QueryString["eliminado"];

                if (eliminado == "1")
                {
                    Response.Write("Eliminado");
                    ClientScript.RegisterClientScriptBlock(e.GetType(), "modal", "<script>alert('Apagado com sucesso!');</script>");
                }
            }

        }
        
        protected void Repeater1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] dataIda = dr["data_ida"].ToString().Split(' ');
                string[] dataVolta = dr["data_volta"].ToString().Split(' ');

                ((Label)e.Item.FindControl("lbl_viagem")).Text = dr["id_viagem"].ToString();
                ((Label)e.Item.FindControl("lbl_titulo")).Text = dr["titulo"].ToString();
                ((Label)e.Item.FindControl("lbl_dataIda")).Text = dataIda[0].ToString();
                ((Label)e.Item.FindControl("lbl_dataVolta")).Text = dataVolta[0].ToString();
                ((Label)e.Item.FindControl("lbl_preco")).Text = dr["preco"].ToString() + " €";
                //((Label)e.Item.FindControl("lbl_perfil")).Text = dr["perfil"].ToString();
                ((LinkButton)e.Item.FindControl("btn_edita")).CommandArgument = dr["id_viagem"].ToString();
                ((LinkButton)e.Item.FindControl("btn_elimina")).CommandArgument = dr["id_viagem"].ToString();
            }
        }

        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("btn_edita"))
            {
                Response.Redirect("http://localhost:60849/editar_viagem.aspx?id=" + (((LinkButton)e.Item.FindControl("btn_edita")).CommandArgument).ToString());
            }
            else if (e.CommandName.Equals("btn_elimina"))
            {

                SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);
                con.Open();

                int num = Convert.ToInt32(((LinkButton)e.Item.FindControl("btn_elimina")).CommandArgument);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@id_viagem", num);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "eliminar_viagem";
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();

                Response.Redirect("http://localhost:60849/listar_viagens.aspx?eliminado=1");

            }
        }

    }
}