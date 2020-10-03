using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FizzWare.NBuilder;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using Onion.Infrastructure.Repository;
using Onion.Core.BusinessRules;
using Onion.Core.Interfaces.BusinessRules;
using Onion.DataAccess;
using System.Linq.Expressions;
using System;

namespace Onion.Tests
{
    public class Tests
    {
        private IProductRepository _productService;

        private Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();

        public Tests()
        {
            _productService = _productRepositoryMock.Object;
        }

        [Fact]
        public void SaveProduct()
        {
            // Arrange
            var producDetailDbSetMock = Builder<Product>.CreateListOfSize(100).Build();
            var productDbSetMock = Builder<Product>.CreateNew().Build();

            productDbSetMock.ProductId = 101;

            _productRepositoryMock.Setup(s => s.Create(It.IsAny<Product>())).
                Callback((Product product) =>
                {
                    producDetailDbSetMock.Add(product);
                });


            _productRepositoryMock.Setup(s => s.Single(It.IsAny<Expression<Func<Product, bool>>>())).Returns(

              new Func<Expression<Func<Product, bool>>, Product>(
                                              expr => producDetailDbSetMock.Where(expr.Compile()).FirstOrDefault())

                );


            _productService.Create(productDbSetMock);
            var product = _productService.Single(s => s.ProductId == productDbSetMock.ProductId);

            Assert.NotNull(product);
        }
    }
}