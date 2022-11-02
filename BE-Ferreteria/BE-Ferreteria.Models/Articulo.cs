using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_Ferreteria.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Info { get; set; }
    }
}
