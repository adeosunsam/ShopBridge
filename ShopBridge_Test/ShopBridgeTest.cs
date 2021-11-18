using ShopBridge_model;
using ShopBridge_repo.Repository.Implementations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge_Test
{
    public class ShopBridgeTest
    {
        [Fact]
        public async Task Test_DbClass()
        {
            var dbcontext = await DbContextMock.GetDatabaseContext();
            var generic = new ProductRepository(dbcontext);
            var id = string.Empty;

            //Act
            var actual = await generic.GetProductById(id);

            //Assert
            Assert.IsType<Product>(actual);
        }
    }
}
