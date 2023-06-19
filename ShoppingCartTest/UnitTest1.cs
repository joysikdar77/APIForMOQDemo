using APIForMOQDemo.Controllers;
using EntityModelLayer.Entity;
using Moq;
using ServiceLayer.Interface;

namespace ShoppingCartTest
{
    public class Tests
    {
        private CartController controller;
        private Mock<IPaymentService> paymentServiceMock;
        private Mock<ICartService> cartServiceMock;
        private Mock<IShipmentService> shipmentServiceMock;
        private Mock<ICustomerService> customerServiceMock;
        private Mock<ICleanUserService> cleanUserServiceMock;
        private Mock<CardInfo> cardMock;
        private Mock<AddressInfo> addressInfoMock;
        private List<CartItem> items;
        UserInfo dummyUser;

        [SetUp]
        public void Setup()
        {
            // arrange
            cartServiceMock = new Mock<ICartService>();
            paymentServiceMock = new Mock<IPaymentService>();
            shipmentServiceMock = new Mock<IShipmentService>();
            customerServiceMock = new Mock<ICustomerService>();
            cleanUserServiceMock = new Mock<ICleanUserService>();



            cardMock = new Mock<CardInfo>();
            addressInfoMock = new Mock<AddressInfo>();

            // 
            var cartItemMock = new Mock<CartItem>();
            cartItemMock.Setup(item => item.Price).Returns(10);
            cartItemMock.Setup(item => item.Quantity).Returns(3);
            //addressInfoMock.Setup(a => a.City).Returns("Kolkata"); // Classes are not overridable

            dummyUser = new UserInfo { FirstName = "Bob", LastName = "Dylan", Email="bobdylan@abc.com" };

            items = new List<CartItem>()
            {
              cartItemMock.Object
            };

            cartServiceMock.Setup(c => c.Items()).Returns(items.AsEnumerable());
            customerServiceMock.Setup(c => c.getUserInfo(It.IsAny<int>())).Returns(dummyUser);
            cleanUserServiceMock.Setup(m => m.Clean(It.IsAny<UserInfo>()))
                .Callback(() => dummyUser.FirstName = "B");

            controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object, customerServiceMock.Object, cleanUserServiceMock.Object);

        }



        [Test]
        public void ShouldReturnCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Once());

            Assert.That(result, Is.EqualTo("charged"));
        }

        

        [Test]
        public void ShouldReturnNotCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Once());

            Assert.That(result, Is.EqualTo("charged"));
        }

        [Test]
        public void ShouldReturnGreetings()
        {
            // act
            var result = controller.GetUserGreetings(dummyUser);

            // assert
            Assert.That(result, Is.EqualTo("Welcome B Dylan"));
        }

        [Test]
        public void ShouldReturnUserInfo()
        {

            // act
            var result = controller.GetUserInfo(10);

            // assert
            customerServiceMock.Verify(c => c.getUserInfo(10), Times.Once());

            Assert.That(result, Is.EqualTo(dummyUser));
        }

    }
}