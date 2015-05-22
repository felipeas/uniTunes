using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitunesMvc.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GeneroId { get; set; }
        public int AutorId { get; set; }
        public string Titulo { get; set; }
        public decimal Preco { get; set; }
        public Categoria Genero { get; set; }
        public Autor Autor { get; set; }
    }
}