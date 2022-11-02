using BE_Ferreteria.Data.Interfaces;
using BE_Ferreteria.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE_Ferreteria.Data.Services
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly IConnection _dbConnection;

        public ArticuloRepository(IConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Articulo> GetAllArticuloDetails()
        {
            List<Articulo> articuloList = new List<Articulo>();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarArticulo";
            cmd.CommandType = CommandType.StoredProcedure;
            articuloList = _dbConnection.GetDataList<Articulo>(cmd);

            return articuloList;
        }
        public bool CreateArticulo(Articulo articulo)
        {
            bool result;

            if (articulo != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GuardarArticulo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Producto", articulo.Producto);
                cmd.Parameters.AddWithValue("Cantidad", articulo.Cantidad);
                cmd.Parameters.AddWithValue("Marca", articulo.Marca);
                cmd.Parameters.AddWithValue("Categoria", articulo.Categoria);
                cmd.Parameters.AddWithValue("Info", articulo.Info);
                _dbConnection.ExecuteNonQuery(cmd);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool DeleteArticulo(int id)
        {
            bool result;

            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EliminarArticulo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                _dbConnection.ExecuteNonQuery(cmd);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


        public Articulo GetArticuloDetails(int id)
        {
            Articulo articulo = new Articulo();

            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ObtenerArticulo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                articulo = _dbConnection.GetDataItem<Articulo>(cmd);
            }
            return articulo;
        }

        public bool UpdateArticulo(Articulo articulo)
        {
            bool result;

            if (articulo != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EditarArticulo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", articulo.Id);
                cmd.Parameters.AddWithValue("Producto", articulo.Producto);
                cmd.Parameters.AddWithValue("Cantidad", articulo.Cantidad);
                cmd.Parameters.AddWithValue("Marca", articulo.Marca);
                cmd.Parameters.AddWithValue("Categoria", articulo.Categoria);
                cmd.Parameters.AddWithValue("Info", articulo.Info);
                _dbConnection.ExecuteNonQuery(cmd);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }


    }
}
