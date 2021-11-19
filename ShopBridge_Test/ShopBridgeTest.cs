using ShopBridge_model;
using ShopBridge_repo.Repository.Implementations;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge_Test
{
    public class ShopBridgeTest
    {

        [Fact]
        public async Task Get_all_product()
        {
            var dbcontext = await DbContextMock.GetDatabaseContext();
            var repo = new ProductRepository(dbcontext);

            //Act
            var actual = repo.GetProducts();

            //Assert
            Assert.True(actual!= null);
        }

        [Fact]
        public async Task Get_all_product_by_name()
        {
            var dbcontext = await DbContextMock.GetDatabaseContext();
            var repo = new ProductRepository(dbcontext);
            var name = string.Empty;


            //Act
            var actual = await repo.GetProductByName(name);

            //Assert
            Assert.IsType<Product>(actual);
        }
    }
}
