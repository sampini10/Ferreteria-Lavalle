using BE_Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_Ferreteria.Data.Interfaces
{
    public interface IArticuloRepository
    {
        bool CreateArticulo(Articulo articulo);

        bool UpdateArticulo(Articulo articulo);

        bool DeleteArticulo(int id);

        Articulo GetArticuloDetails(int id);

        List<Articulo> GetAllArticuloDetails();

    }
}
