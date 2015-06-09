using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitunesMvc.Core.Database.Entities
{
    public abstract class Midia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Display(Name = "Imagem")]
        public Byte[] Imagem { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Conteúdo")]
        public Byte[] Conteudo { get; set; }
    }
}
