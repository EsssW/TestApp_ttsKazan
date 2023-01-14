using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DB
{
    public class DbContextInitializer : SqliteDropCreateDatabaseAlways<DataContext>
    {
        public DbContextInitializer(DbModelBuilder modelBuilder)
           : base(modelBuilder) { }

        protected override void Seed(DataContext context)
        {
        }
    }
}
