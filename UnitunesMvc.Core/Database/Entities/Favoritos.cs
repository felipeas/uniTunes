using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitunesMvc.Core.Database.Entities
{
    public class Favoritos
    {
        private UnitunesEntities db = new UnitunesEntities(); 
        //[ForeignKey("Usuario")]
        //public int UsuarioId { get; set; }
        //public virtual Usuario usuario { get; set; }
       
        public List<Midia> Midias { get; set; }

        public void addLivro(Livro livro)
        {
            this.Midias.Add(livro);    
        }
        public void addStreaming(Streaming streaming)
        {
            this.Midias.Add(streaming);
        }

    } 
}