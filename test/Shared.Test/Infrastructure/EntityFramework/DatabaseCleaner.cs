using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Test.Infrastructure.EntityFramework
{
    public class DatabaseCleaner
    {
        private List<string> Tables(DbContext context)
        {
            return context.GetType().GetProperties()
                .Where(x => x.PropertyType.Name == "DbSet`1")
                .Select(x => x.Name).ToList();
        }

        private string TruncateDatabaseSql(List<string> tables)
        {
            var truncateTables = tables.Select(x => $"TRUNCATE TABLE {x};").ToList();
            return $"SET FOREIGN_KEY_CHECKS=0;{string.Join(" ", truncateTables)} SET FOREIGN_KEY_CHECKS = 1;";
        }

        public void Invoke(DbContext context)
        {
            var tables = Tables(context);
            var truncateTablesSql = TruncateDatabaseSql(tables);
            context.Database.ExecuteSqlRaw(truncateTablesSql);
        }
    }
}
