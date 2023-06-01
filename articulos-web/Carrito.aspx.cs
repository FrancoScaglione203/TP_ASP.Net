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


        public Carrito()
        {
            if (artsCarrito != null)
            {
                artsCarrito = new List<Articulo>(); // Inicializa la lista en el constructor
            }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = negocio.listarConSp();
                artsCarrito = new List<Articulo>(listaArticulos);
                repRepetidor.DataSource = artsCarrito;
                repRepetidor.DataBind();
            }
        }

        public void EliminarCarrito_Click(object sender, EventArgs e)
        {
            int idEliminar = int.Parse(((Button)sender).CommandArgument);
            artsCarrito.RemoveAll(articulo => articulo.Id == idEliminar);
            repRepetidor.DataSource = artsCarrito;
            repRepetidor.DataBind();
        }
    }
}
