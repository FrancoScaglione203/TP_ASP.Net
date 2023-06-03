using dominio;
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

            CantidadCarrito();


        }

        public void Nombre_lbl(string usu)
        {
            lblLogueo.Text = usu;
        }

        public void CantidadCarrito() 
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;
            if (Session["Carrito"] == null || carrito.Count == 0) 
            {
                lblCantidad.Text = "(0)"; 
            }
            else
            {
                lblCantidad.Text ="(" + carrito.Count.ToString() + ")";
            }
            return;
        }
    }
}