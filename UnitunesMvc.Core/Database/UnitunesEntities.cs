using System.Text;
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
    }
}


