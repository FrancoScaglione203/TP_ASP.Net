using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCart_Click(object sender, EventArgs e)
        {
            int Id = 4;
            Session["Id"] = Id;
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session["Carrito"] = carrito;
            }
        }
    }
}