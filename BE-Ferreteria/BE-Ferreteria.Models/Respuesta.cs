using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_Ferreteria.Models
{
    public class Respuesta
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Function { get; set; }
        public object Parameters { get; set; }
        public int TotalRegistros { get; set; }
    }
}
