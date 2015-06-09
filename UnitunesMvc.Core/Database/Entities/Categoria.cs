using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UnitunesMvc.Core.Database.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Album> Albums { get; set; }
    }
}