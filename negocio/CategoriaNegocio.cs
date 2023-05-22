using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    
        public int UltimoId()  //Funcion que muestra el Id de la nueva categoria a Agregar
        {
            int ultimoId = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDENT_CURRENT('CATEGORIAS') AS UltimoId");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    ultimoId = Convert.ToInt32(datos.Lector["UltimoId"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return ultimoId;
        }








        public int numeroIdModificar(Categoria categoria)     //Funcion que devuelve el Id de Categoria que se selecciona  o 0 si no hay ninguna
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("select Id from CATEGORIAS where Id = "+categoria.Id+""); //INSERT INTO CATEGORIAS (DESCRIPCION) VALUES ('');SELECT SCOPE_IDENTITY() AS Id;
                datos.ejecutarLectura();

                if (datos.Lector.HasRows)   
                {
                    datos.Lector.Read();
                    int id = (int)datos.Lector["Id"];
                    return id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void modificar(Categoria categoria) 
        {
            AccesoDatos datos = new AccesoDatos();

            try 
            {
                datos.setearConsulta("update CATEGORIAS set Descripcion= '"+categoria.Descripcion+"' where id = "+categoria.Id+"");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {                
                datos.cerrarConexion();
            }
        }


        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion) Values ('"+nuevo.Descripcion+"')");
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public void eliminar(int id) 
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from CATEGORIAS where Id = "+id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
