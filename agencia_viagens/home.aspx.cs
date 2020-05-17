using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agencia_viagens
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                back.Visible = false;
                string perfil = Session["login"].ToString().ToLower().Trim();

                if (perfil != null && perfil == "admin")
                {
                    back.Visible = true;
                }
            }

        }
    }
}