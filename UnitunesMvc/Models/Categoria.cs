using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitunesMvc.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string nome { get; set; }
        public List<Album> Albums { get; set; }
    }
}