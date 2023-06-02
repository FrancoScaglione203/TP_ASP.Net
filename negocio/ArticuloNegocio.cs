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

        public List<Articulo> listarConSp()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //string consulta = "Select Articulos.Id,Articulos.Codigo,Articulos.Nombre,Articulos.Descripcion,Articulos.Precio,Marcas.Descripcion as Marca,Categorias.Descripcion as Categoria,Imagenes.ImagenUrl,Articulos.IdMarca,Articulos.IdCategoria From Articulos\r\ninner join Marcas on Marcas.Id = Articulos.IdMarca\r\ninner join Categorias on Categorias.Id = Articulos.IdCategoria\r\ninner join Imagenes on Imagenes.IdArticulo = Articulos.Id Where Articulos.idMarca > 0";
                //datos.setearConsulta(consulta);

                datos.setearProcedimiento("SP_Listar");
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


        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("Select Articulos.Id,Articulos.Codigo,Articulos.Nombre,Articulos.Descripcion,Articulos.Precio,Marcas.Descripcion as Marca,Categorias.Descripcion as Categoria,Imagenes.ImagenUrl,Articulos.IdMarca,Articulos.IdCategoria From Articulos\r\ninner join Marcas on Marcas.Id = Articulos.IdMarca\r\nleft join Categorias on Categorias.Id = Articulos.IdCategoria\r\ninner join Imagenes on Imagenes.IdArticulo = Articulos.Id Where Articulos.idMarca > 0");
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion AS Marca, C.Descripcion AS Categoria, MIN(I.ImagenUrl) AS ImagenUrl, A.IdMarca, A.IdCategoria\r\nFROM Articulos AS A\r\nINNER JOIN Marcas AS M ON M.Id = A.IdMarca\r\nLEFT JOIN Categorias AS C ON C.Id = A.IdCategoria\r\nINNER JOIN Imagenes AS I ON I.IdArticulo = A.Id\r\nWHERE A.IdMarca > 0\r\nGROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion, C.Descripcion, A.IdMarca, A.IdCategoria");
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
                    if(!(datos.Lector["Categoria"] is DBNull))
                        {
                            aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        }
                        else
                        {
                            aux.Categoria.Descripcion = "Sin Categoria";
                        }
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    //aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
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

        public List<Imagen> listarImagen()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select I.Id,I.IdArticulo,I.ImagenUrl from imagenes as I");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    try
                    {
                        aux.Id = (int)datos.Lector["Id"];
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
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
