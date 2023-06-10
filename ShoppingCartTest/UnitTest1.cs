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
        private Mock<CardInfo> cardMock;
        private Mock<AddressInfo> addressInfoMock;
        private List<CartItem> items;

        [SetUp]
        public void Setup()
        {
            cartServiceMock = new Mock<ICartService>();
            paymentServiceMock = new Mock<IPaymentService>();
            shipmentServiceMock = new Mock<IShipmentService>();

            // arrange
            cardMock = new Mock<CardInfo>();
            addressInfoMock = new Mock<AddressInfo>();

            // 
            var cartItemMock = new Mock<CartItem>();
            cartItemMock.Setup(item => item.Price).Returns(10);
            //addressInfoMock.Setup(a => a.City).Returns("Kolkata"); // Classes are not overridable

            items = new List<CartItem>()
            {
              cartItemMock.Object
            };

            cartServiceMock.Setup(c => c.Items()).Returns(items.AsEnumerable());

            controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);

        }



        [Test]
        public void ShouldReturnCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            // myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Once());

            Assert.AreEqual("charged", result);
        }

        [Test]
        public void ShouldReturnNotCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(false);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Never());
            Assert.AreEqual("not charged", result);
        }

    }
}