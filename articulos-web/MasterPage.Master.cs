using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace articulos_web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] != null)
            {
                string Usuario = Session["Nombre"].ToString();
                Nombre_lbl(Session["Nombre"].ToString()); 
            }
            else
            {
                Nombre_lbl("Ingresar");
            }
        }

        public void Nombre_lbl(string usu)
        {
            lblLogueo.Text = usu;
        }
    }
}