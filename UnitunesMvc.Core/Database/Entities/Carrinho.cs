using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitunesMvc.Core.Database.Entities
{
    public class Carrinho
    {
        private UnitunesEntities db = new UnitunesEntities();
        [Key]
        public int Id { get; set; }

        
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<CarrinhoItem> Items { get; set; }

        [NotMapped]
        [Display(Name = "Sub-Total")]
        public double SubTotal
        {
            get
            {
                double subtotal = 0;
                foreach(var item in this.Items)
                {
                    subtotal += item.Midia.Preco;
                }
                return subtotal;
            }
        }

        public Carrinho()
        {
            this.Items = new List<CarrinhoItem>();
        }

        public void CriarOrdem() {
            var venda = new Venda();
            venda.UsuarioID = this.UsuarioId;
            double total = 0;
            foreach (var item in this.Items)
            {
                var creditoAutor = item.Midia.Preco * 0.9;
                var creditoAdmin = item.Midia.Preco * 0.1;
                total += item.Midia.Preco;

                var autor = item.Midia.Autor;
                var administrador = db.Usuarios.Find(UnitunesEntities.USUARIO_ADMIN_ID);

                this.Usuario.Conta.Transferir(creditoAutor, autor.Conta);
                this.Usuario.Conta.Transferir(creditoAdmin, administrador.Conta);

                venda.Items.Add(new VendaItem
                {
                    MidiaId = item.MidiaId,
                    Valor = item.Midia.Preco
                });
            }
            venda.Total = total;
            db.SaveChanges();
        }

        public void EsvaziarCarrinho()
        {
            foreach (var item in this.Items)
            {
                this.Items.Remove(item);
            }
            db.SaveChanges();
        }

    }
}
