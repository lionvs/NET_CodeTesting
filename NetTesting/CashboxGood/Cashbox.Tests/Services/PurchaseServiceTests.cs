using System.Linq;
using Cashbox.DataAccess;
using Cashbox.Models;
using Cashbox.Services;
using Cashbox.Tests.Fake;
using FakeItEasy;
using NUnit.Framework;

namespace Cashbox.Tests.Services
{
    [TestFixture]
    public class PurchaseServiceTests
    {
        // Example with fake objects without usage of mock frameworks.
        [Test]
        public void GetDiscount_When_account_has_enough_orders_and_selected_cheap_product_Then_orders_history_discount()
        {
            // Arrange
            var order1 = new Order { AccountId = 1, Total = PurchaseService.ORDERS_HISTORY_DISCOUNT_THRESHOLD + 10m };
            var order2 = new Order { AccountId = 1, Total = 40m };
            var order3 = new Order { AccountId = 2, Total = 70m };

            var productsTotal = PurchaseService.EXPENSIVE_PRODUCTS_DISCOUNT_THRESHOLD - 10m;

            var repository = new FakeRepository<Order>(order1, order2, order3);
            var unitOfWorkFactory = new FakeUnitOfWorkFactory(x => x.SetRepository(repository));

            var service = new PurchaseService(unitOfWorkFactory);

            // Act
            var discount = service.GetDiscount(1, productsTotal);

            // Assert
            Assert.That(discount, Is.EqualTo(PurchaseService.ORDERS_HISTORY_DISCOUNT));
        }

        // TODO: Write test to check that account can get 5% discount (for the selected expensive products).

        // TODO: Write test to check that account can get 15% discount (10% + 5%, for previous orders and for selected products).

        // Example with fake objects created using the FakeItEasy.
        [Test]
        public void Purchase_When_purchase_products_Then_products_amount_correctly_updated()
        {
            // Arrange
            var product1 = new Product { Id = 1, Price = 1, Amount = 5 };
            var product2 = new Product { Id = 2, Price = 2, Amount = 10 };
            var product3 = new Product { Id = 3, Price = 3, Amount = 7 };

            var productRepository = A.Fake<IRepository<Product>>();
            A.CallTo(() => productRepository.Query()).Returns(new[] { product1, product2, product3 }.AsQueryable());

            var account = new Account { Id = 1, Balance = 10 };

            var accountRepository = A.Fake<IRepository<Account>>();
            A.CallTo(() => accountRepository.Get(A<int>._)).Returns(account);

            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.Repository<Product>()).Returns(productRepository);
            A.CallTo(() => unitOfWork.Repository<Account>()).Returns(accountRepository);

            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(() => unitOfWorkFactory.Create()).Returns(unitOfWork);

            var service = new PurchaseService(unitOfWorkFactory);

            // Act
            service.Purchase(account.Id, new[] { product1.Id, product2.Id }, product1.Price + product2.Price);

            // Assert
            Assert.That(product1.Amount, Is.EqualTo(4));
            Assert.That(product2.Amount, Is.EqualTo(9));
        }

        [Test]
        public void Purchase_When_not_enough_balance_Then_throw_exception()
        {
            // Assert
            var account = new Account { Id = 1, Balance = 10 };

            var accountRepository = A.Fake<IRepository<Account>>();
            A.CallTo(() => accountRepository.Get(A<int>._)).Returns(account);

            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.Repository<Account>()).Returns(accountRepository);

            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(() => unitOfWorkFactory.Create()).Returns(unitOfWork);

            var service = new PurchaseService(unitOfWorkFactory);

            // Act and Assert
            Assert.Throws<PurchaseException>(() => service.Purchase(1, Enumerable.Empty<int>(), 20m));
        }

        // TODO: Write test to check that account balance is correctly updated after purchase.

        // TODO: Write test to check that account can't buy product if it's amount is 0. Purchase should throw an exception.
    }
}