using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Articulos.Id,Articulos.Codigo,Articulos.Nombre,Articulos.Descripcion,Articulos.Precio,Marcas.Descripcion as Marca,Categorias.Descripcion as Categoria,Imagenes.ImagenUrl,Articulos.IdMarca,Articulos.IdCategoria From Articulos\r\ninner join Marcas on Marcas.Id = Articulos.IdMarca\r\ninner join Categorias on Categorias.Id = Articulos.IdCategoria\r\ninner join Imagenes on Imagenes.IdArticulo = Articulos.Id Where Articulos.idMarca > 0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    try
                    {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id= (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion= (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                     if (!(datos.Lector["ImagenUrl"] is DBNull))
                     {
                        aux.Imagen = new Imagen();
                        aux.Imagen.ImagenUrl= (string)datos.Lector["ImagenUrl"];
                     }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

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

        public int agregar(Articulo nuevo)
            
        {
            int id = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Articulos(Codigo,Nombre,Descripcion,Precio,IdMarca,IdCategoria)values(" + "'" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion+ "','" + nuevo.Precio + "',@IdMarca,@IdCategoria); SELECT SCOPE_IDENTITY()");
                datos.setearParametro("@IdMarca",nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria",nuevo.Categoria.Id);
                //datos.ejecutarAccion();

                id = datos.leerIdUltimoCreado();



                return id;

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
        

        public void modificar(Articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Articulos set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,Precio=@Precio Where Id =@Id");
                datos.setearParametro("@Codigo", modificado.Codigo);
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdMarca", modificado.Marca.Id);
                datos.setearParametro("@IdCategoria", modificado.Categoria.Id);
                datos.setearParametro("@Precio", modificado.Precio);
                datos.setearParametro("@Id", modificado.Id);

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
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from Articulos Where Id =" + id);
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

        public void eliminarLogico(int id,int idMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            idMarca *= -1;
            try
            {
                datos.setearConsulta("Update Articulos set IdMarca=@IdMarca Where Id =" + id);
                datos.setearParametro("@IdMarca", idMarca);
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Articulos.Id,Articulos.Codigo,Articulos.Nombre,Articulos.Descripcion,Articulos.Precio,Marcas.Descripcion as Marca,Categorias.Descripcion as Categoria,Imagenes.ImagenUrl,Articulos.IdMarca,Articulos.IdCategoria From Articulos\r\ninner join Marcas on Marcas.Id = Articulos.IdMarca\r\ninner join Categorias on Categorias.Id = Articulos.IdCategoria\r\ninner join Imagenes on Imagenes.IdArticulo = Articulos.Id Where Articulos.idMarca > 0 and ";

                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Marcas.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Marcas.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Marcas.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Categorias.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Categorias.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Categorias.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
 

                        switch (criterio)
                        {
                            case "A partir de":
                                consulta += "Precio > " + filtro;
                                break;
                            default:
                                consulta += "Precio < " + filtro;
                                break;
                        }
                        break;
                }

               
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.Imagen = new Imagen();
                        aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
