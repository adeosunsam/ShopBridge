using Microsoft.EntityFrameworkCore;
using ShopBridge_data.Contexts;
using System;
using System.Threading.Tasks;

namespace ShopBridge_Test
{
    public class DbContextMock
    {
        public static async Task<ShopDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ShopDbContext(options);

            
            await databaseContext.Database.EnsureCreatedAsync();
            
            return databaseContext;
        }
    }
}
