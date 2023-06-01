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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public List<Marca> ListaMarcas { get; set; }
        public List<Categoria> ListaCategorias { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ListaArticulos = articuloNegocio.listar();
            // ListaArticulos = articuloNegocio.listarConSp();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ListaMarcas = marcaNegocio.listar();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ListaCategorias = categoriaNegocio.listar();

            if (!IsPostBack)
            {

                // Llenar la lista de checked con las marcas
                foreach (dominio.Marca marca in ListaMarcas)
                {
                    rblMarcas.Items.Add(new ListItem(marca.Descripcion, marca.Id.ToString()));
                }
                // Llenar la lista de checked con las categorias
                foreach (dominio.Categoria categoria in ListaCategorias)
                {
                    rblCategorias.Items.Add(new ListItem(categoria.Descripcion, categoria.Id.ToString()));
                }
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Filtrar por marca
            if (rblMarcas.SelectedIndex != -1)
            {
                int idMarca = Convert.ToInt32(rblMarcas.SelectedValue);
                ListaArticulos = ListaArticulos.FindAll(k => k.Marca.Id == idMarca);
            }
            // Filtrar por categoria
            if (rblCategorias.SelectedIndex != -1)
            {
                int idCategoria = Convert.ToInt32(rblCategorias.SelectedValue);
                ListaArticulos = ListaArticulos.FindAll(k => k.Categoria.Id == idCategoria);
            }
            // Filtrar por nombre
            if (txtNombre.Text != "")
            {
                ListaArticulos = ListaArticulos.FindAll(k => k.Nombre.ToLower().Contains(txtNombre.Text.ToLower()));
            }
            // Filtrar por precio minimo
            if (txtPrecioMin.Text != "")
            {
                decimal precioMinimo = Convert.ToDecimal(txtPrecioMin.Text);
                ListaArticulos = ListaArticulos.FindAll(k => k.Precio >= precioMinimo);
            }
            // Filtrar por precio maximo
            if (txtPrecioMax.Text != "")
            {
                decimal precioMaximo = Convert.ToDecimal(txtPrecioMax.Text);
                ListaArticulos = ListaArticulos.FindAll(k => k.Precio <= precioMaximo);
            }

        }
    }
}