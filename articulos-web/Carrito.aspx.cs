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
            if (Session["Nombre"] == null) 
            {
                Response.Redirect("Usuario.aspx");
                return;
            }

            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;
            repRepetidor.DataSource = carrito;
            repRepetidor.DataBind();
            SumaTotal();
        }


        public void EliminarCarrito(int id)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;
            //int id = Convert.ToInt32(Session["Id"]);
            Articulo articuloEliminar = new Articulo();
            articuloEliminar = seleccionArticulo(id);
            carrito.Remove(articuloEliminar);
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


        public void SumaTotal()
        {
            if (Session["SumTotal"] == null)
            {
                Session["SumTotal"] = 0; 
            }

            List<Articulo> carrito = new List<Articulo>();
            carrito = Session["Carrito"] as List<Articulo>;
            decimal total = 0;
            foreach (var art in carrito) 
            {
                total += art.Precio;
            }

            Session["SumTotal"] = total;


            lblTotal.Text = (Session["SumTotal"].ToString());

        }

        protected void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idEliminar = Convert.ToInt32(btnEliminar.CommandArgument);
            this.EliminarCarrito(idEliminar);
            Response.Redirect("carrito.aspx");
        }



        // public void EliminarCarrito_Click(object sender, EventArgs e)
        // {
        //     Button btnEliminar = (Button)sender;
        //     int idEliminar = Convert.ToInt32(btnEliminar.CommandArgument);
        //     this.EliminarCarrito(idEliminar);
        //     //Response.Redirect("carrito.aspx");
        // }
    }
}
