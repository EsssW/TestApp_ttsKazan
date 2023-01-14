using SQLite.CodeFirst;
using System.Data.Entity;

namespace TestApp
{
    public class DataContext : DbContext 
    {
        public DataContext()
            : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DataContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);

        }

        public DbSet <ServerUser> Users { get; set; }

        public DbSet<MousEvent> mousEvents { get; set; }
    }
}
