using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitunesMvc.Core.Database.Entities
{
    public class Conta
    {
        private UnitunesEntities db = new UnitunesEntities();

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Saldo")]
        public double Saldo { get; set; }
        
        public List<Midia> Carrinho { get; set; }
    }
}
