using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Clave = txtClave.Text;
            Session["Nombre"] = Usuario;
            Response.Redirect("default.aspx");
        }
    }
}