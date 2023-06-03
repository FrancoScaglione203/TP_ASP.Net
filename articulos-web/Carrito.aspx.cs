using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Collections;

namespace articulos_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            cargarRepetidor();
        }

        public void cargarRepetidor() 
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;
            repRepetidor.DataSource = carrito;
            repRepetidor.DataBind();
        }






        public void EliminarCarrito_Click(object sender, EventArgs e)
        {





            //int idEliminar = int.Parse(((Button)sender).CommandArgument);
            //artsCarrito.RemoveAll(articulo => articulo.Id == idEliminar);

        }
    }
}
