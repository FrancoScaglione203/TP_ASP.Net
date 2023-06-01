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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ListaArticulos = articuloNegocio.listar();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                articulo = ListaArticulos.Find(k => k.Id == id);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}