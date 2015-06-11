using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitunesMvc.Core.Database.Entities
{
    public enum TipoMidia
    {
        [Display(Name = "Música")]
        Musica,
        [Display(Name = "Video")]
        Video,
        [Display(Name = "Podcast")]
        Podcast,
        [Display(Name = "Livro")]
        Livro
    }

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
        public ArquivoBinario Imagem { get; set; }

        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }

        [Display(Name = "Conteúdo")]
        public ArquivoBinario Conteudo { get; set; }

        public Usuario Autor { get;set;}
    }
}
