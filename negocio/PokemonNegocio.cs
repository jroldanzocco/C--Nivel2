using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using negocio;
using System.Net;

namespace winform_app
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setConsulta("Select Numero, Nombre, P.Descripcion, E.Descripcion as Tipo, urlImagen, d.Descripcion Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.idtipo = E.id and D.ID = p.IdDebilidad");
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    //if(!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("urlImagen"))))
                    //    aux.urlImagen = (string)datos.Lector["urlImagen"];
                    if (!(datos.Lector["urlImagen"] is DBNull))
                        aux.urlImagen = (string)datos.Lector["urlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
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

        public void agregar(Pokemon nuevo)
        {
            AccesoDatos conectar = new AccesoDatos();
            
            try
            {
                conectar.setConsulta("insert into POKEMONS (Numero,Nombre,Descripcion,Activo, idTipo,idDebilidad) values("+ nuevo.Numero +",'"+ nuevo.Descripcion + "','"+ nuevo.Descripcion + "',1, @idTipo,@idDebilidad)");
                conectar.setearParametro("@idTipo",nuevo.Tipo.id);
                conectar.setearParametro("@idDebilidad", nuevo.Debilidad.id);
                conectar.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }

        public void modificar(Pokemon modificar)
        {

        }
    }
}
