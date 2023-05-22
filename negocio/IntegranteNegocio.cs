using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class IntegranteNegocio
    {
        public List<Integrante> Listar()
        {
            List<Integrante> lista = new List<Integrante>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,Legajo,Nombre,Apellido,Avatar,Activo from Integrantes where Activo=1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Integrante aux = new Integrante();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Legajo = (int)datos.Lector["Legajo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["Avatar"]is DBNull))
                    {
                        aux.Avatar = (string)datos.Lector["Avatar"];
                    }
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Integrante integrante)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Integrantes(Legajo,Nombre,Apellido,Avatar)Values(@Legajo,@Nombre,@Apellido,@Avatar)");
                datos.setearParametro("@Legajo", integrante.Legajo);
                datos.setearParametro("@Nombre", integrante.Nombre);
                datos.setearParametro("@Apellido", integrante.Apellido);
                datos.setearParametro("@Avatar", integrante.Avatar);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Integrante integrante)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Integrantes set Legajo=@Legajo,Nombre=@Nombre,Apellido=@Apellido,Avatar=@Avatar Where Id=@Id");
                datos.setearParametro("@Legajo", integrante.Legajo);
                datos.setearParametro("@Nombre", integrante.Nombre);
                datos.setearParametro("@Apellido", integrante.Apellido);
                datos.setearParametro("@Avatar", integrante.Avatar);
                datos.setearParametro("@Id", integrante.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarLogico(int idIntegrante)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Integrantes set Activo=0 Where Id=@Id");
                datos.setearParametro("@Id", idIntegrante);
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

        public void eliminarFisico(int idIntegrante)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete Integrantes Where Id=@Id");
                datos.setearParametro("@Id", idIntegrante);
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
    }
}

