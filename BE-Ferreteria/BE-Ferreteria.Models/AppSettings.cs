using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_Ferreteria.Models
{
    public sealed class AppSettings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; }

        public sealed class ConnectionStringsSettings
        {
            public string conexionSql { get; set; }
        }
    }
}
