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
    public partial class listagem_viagens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName.Equals("btn_add")) { 

                SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);

                int num = Convert.ToInt32(((LinkButton)e.Item.FindControl("btn_add")).CommandArgument);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@id_viagem", num);
                myCommand.Parameters.AddWithValue("@cod_cliente", Session["id_cliente"]);
                myCommand.Parameters.AddWithValue("@quantidade", ((TextBox)e.Item.FindControl("quantidade")).Text);
                myCommand.CommandText = "adicionar_carrinho";
                myCommand.CommandType = CommandType.StoredProcedure;
                
                SqlParameter retorno = new SqlParameter();
                retorno.ParameterName = "@quantProduto";
                retorno.Direction = ParameterDirection.Output;
                retorno.SqlDbType = SqlDbType.Int;
                retorno.Size = 100;
                myCommand.Parameters.Add(retorno);

                myCommand.Connection = con;
                con.Open();
                myCommand.ExecuteNonQuery();

                if (myCommand.Parameters["@quantProduto"].Value.ToString() != "")
                {
                    Session["quantidade_carrinho"] = Convert.ToInt32(myCommand.Parameters["@quantProduto"].Value);
                    quantCarrinho.Text= myCommand.Parameters["@quantProduto"].Value.ToString();
                }
                


            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] dataIda = dr["data_ida"].ToString().Split(' ');
                string[] dataVolta = dr["data_volta"].ToString().Split(' ');

                Image img = e.Item.FindControl("imagem") as Image;

                img.ImageUrl = dr["src_imagem"].ToString();

                ((Label)e.Item.FindControl("titulo")).Text = dr["titulo"].ToString();
                ((Label)e.Item.FindControl("descricao")).Text = dr["descricao"].ToString();
                ((Label)e.Item.FindControl("data_ida")).Text = dataIda[0].ToString();
                ((Label)e.Item.FindControl("data_volta")).Text = dataVolta[0].ToString();
                ((Label)e.Item.FindControl("preco")).Text = dr["preco"].ToString() + " €";
                /*((ImageButton)e.Item.FindControl("imagem").  = dr["src_imagem"].ToString();*/
                
                
                 ((LinkButton)e.Item.FindControl("btn_add")).CommandArgument = dr["id_viagem"].ToString();
            }
        }
    }
}