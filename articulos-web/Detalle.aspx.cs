using dominio;
using negocio;
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
        public List<Articulo> ListaArticulos { get; set; }
        public Articulo articulo { get; set; }

        public List<Imagen> listaImagenes { get; set; }
        public Imagen imagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ListaArticulos = articuloNegocio.listar();

            listaImagenes = articuloNegocio.listarImagen();

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Session["Id"] = id;
                articulo = ListaArticulos.Find(a => a.Id == id);
                listaImagenes = listaImagenes.FindAll(i => i.IdArticulo == id);

        

        
            }
            catch (Exception)
            {
                throw;
            }


        }

        protected void AddCart_Click(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Usuario.aspx");
                return;
            }
            int Id = Convert.ToInt32(Session["Id"]);
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session["Carrito"] = carrito;
                AgregarCarrito(Id);

            }
            else 
            {
                AgregarCarrito(Id);
            }

            Response.Redirect("default.aspx");
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



        }


        public Articulo seleccionArticulo(int id)
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

    }
}
