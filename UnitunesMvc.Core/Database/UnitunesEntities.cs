﻿using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UnitunesMvc.Core.Database.Entities
{

    public class UnitunesEntities : DbContext
    {
        private const string SERVIDOR = "localhost\\sqlexpress";
        private const string DB_USER = "sa";
        private const string DB_PASS = "_43690";
        private const string DB_NAME = "Unitunes";

        public DbSet<Album> Albums { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Streaming> Streamings { get ; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ArquivoBinario> Binarios { get; set; }
        public DbSet<Conta> Contas { get; set; }

        static UnitunesEntities()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UnitunesEntities>());
        }

        public UnitunesEntities()
            : base(MontarStringConexao())
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private static string MontarStringConexao()
        {
            var cs = new StringBuilder();

            cs.AppendFormat("Server={0};", SERVIDOR);
            cs.AppendFormat("Database={0};", DB_NAME);
            cs.AppendFormat("User Id={0};", DB_USER);
            cs.AppendFormat("Password={0};", DB_PASS);

            return cs.ToString();
        }

        public void feed()
        {
            this.Usuarios.Add(new Usuario { PrimeiroNome = "Admin", UltimoNome = "Admin", Email = "admin@email.com", Senha = "qwerasd", Tipo = TipoUsuario.Administrador, Conta = new Conta { Saldo = 0 } });
            this.Usuarios.Add(new Usuario { PrimeiroNome = "Academico", UltimoNome = "Random", Email = "academico@email.com", Senha = "qwerasd", Tipo = TipoUsuario.Academico, Conta = new Conta { Saldo = 0 } });
            this.Usuarios.Add(new Usuario { PrimeiroNome = "Autor", UltimoNome = "Random", Email = "autor@email.com", Senha = "qwerasd", Tipo = TipoUsuario.Academico, Conta = new Conta { Saldo = 0 } });

            this.Categorias.Add(new Categoria { Nome = "Industrial Rock", Tipo = TipoMidia.Musica });   //1         
            this.Categorias.Add(new Categoria { Nome = "MPB", Tipo = TipoMidia.Musica });               //2           
            this.Categorias.Add(new Categoria { Nome = "Gospel", Tipo = TipoMidia.Musica });            //3
            this.Categorias.Add(new Categoria { Nome = "Alternative Rock", Tipo = TipoMidia.Musica });  //4
            this.Categorias.Add(new Categoria { Nome = "Pop", Tipo = TipoMidia.Musica });               //5
            this.Categorias.Add(new Categoria { Nome = "Tecnobrega", Tipo = TipoMidia.Musica });        //6

            this.Categorias.Add(new Categoria { Nome = "Exatas", Tipo = TipoMidia.Livro });             //7
            this.Categorias.Add(new Categoria { Nome = "Humanas", Tipo = TipoMidia.Livro });            //8 
            this.Categorias.Add(new Categoria { Nome = "Fantástica", Tipo = TipoMidia.Livro });         //9
            this.Categorias.Add(new Categoria { Nome = "Direito", Tipo = TipoMidia.Livro });            //10
            this.Categorias.Add(new Categoria { Nome = "Software", Tipo = TipoMidia.Livro });           //11

            this.Categorias.Add(new Categoria { Nome = "Sci-fi", Tipo = TipoMidia.Video });             //12
            this.Categorias.Add(new Categoria { Nome = "Ação", Tipo = TipoMidia.Video });               //13
            this.Categorias.Add(new Categoria { Nome = "Drama", Tipo = TipoMidia.Video });              //14
            this.Categorias.Add(new Categoria { Nome = "Suspense", Tipo = TipoMidia.Video });           //15
            this.Categorias.Add(new Categoria { Nome = "Terror", Tipo = TipoMidia.Video });             //16
            this.Categorias.Add(new Categoria { Nome = "Thriler", Tipo = TipoMidia.Video });            //17

            this.Categorias.Add(new Categoria { Nome = "Arte", Tipo = TipoMidia.Podcast });             //18
            this.Categorias.Add(new Categoria { Nome = "Games", Tipo = TipoMidia.Podcast });            //19
            this.Categorias.Add(new Categoria { Nome = "Ciência", Tipo = TipoMidia.Podcast });          //20
            this.Categorias.Add(new Categoria { Nome = "Tecnologia", Tipo = TipoMidia.Podcast });       //21
            this.Categorias.Add(new Categoria { Nome = "Filmes", Tipo = TipoMidia.Podcast });           //22

            this.Streamings.Add(new Streaming
            {
                Nome = "The Shawshank Redemption",
                Tipo = TipoStreaming.Video,
                Descricao = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Duracao = 120,
                CategoriaId = 14
            });

            this.Streamings.Add(new Streaming
            {
                Nome = "The Dark Knight",
                Tipo = TipoStreaming.Video,
                Descricao = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.",
                Duracao = 120,
                CategoriaId = 13
            });

            this.Streamings.Add(new Streaming
            {
                Nome = "The Lord of the Rings: The Return of the King",
                Tipo = TipoStreaming.Video,
                Descricao = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                Duracao = 220,
                CategoriaId = 12
            });
            this.SaveChanges();
        }
    }
}


