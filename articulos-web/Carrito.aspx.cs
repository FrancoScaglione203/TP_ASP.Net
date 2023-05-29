using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace articulos_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> artsCarrito { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            artsCarrito = negocio.listarConSp();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = artsCarrito;
                repRepetidor.DataBind();
            }
        }

        protected void EliminarCarrito_Click(object sender, EventArgs e)
        {
            int idEliminar = int.Parse(((Button)sender).CommandArgument);
        }
    }
}







