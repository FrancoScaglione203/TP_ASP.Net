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

        }

        public void AgregarCarrito(int Id) 
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;

            int id = Convert.ToInt32(Session["Id"]);
            Articulo articuloNuevo = new Articulo();
            articuloNuevo = seleccionArticulo(id);

            carrito.Add(articuloNuevo);

            Session["Carrito"] = carrito;


            repRepetidor.DataSource = Session["Carrito"] as List<Articulo>;
            repRepetidor.DataBind();

        }


        public Articulo seleccionArticulo (int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = negocio.listarConSp();
        
            foreach (var art in listaArticulos)
            {
                if (art.Id == id)
                {
                    return art;
                }
            }
            return null;
        }




        public void EliminarCarrito_Click(object sender, EventArgs e)
        {





            //int idEliminar = int.Parse(((Button)sender).CommandArgument);
            //artsCarrito.RemoveAll(articulo => articulo.Id == idEliminar);

        }
    }
}
