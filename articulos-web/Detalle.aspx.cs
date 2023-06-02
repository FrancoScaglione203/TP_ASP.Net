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
                articulo = ListaArticulos.Find(a => a.Id == id);
                listaImagenes = listaImagenes.FindAll(i => i.IdArticulo == id);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
