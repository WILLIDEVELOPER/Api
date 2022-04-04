using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class ProductModel
    {
        [PrimaryKey,AutoIncrement]
        public int ProdID { get; set; }
        public string Numero { get; set; }

        public string NombrePro { get; set; }
    }
}
