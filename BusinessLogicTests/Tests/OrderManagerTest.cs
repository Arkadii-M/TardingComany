using BusinessLogic.Concrete;
using DalEF.Interfaces;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTests.Tests
{
    class OrderManagerTest
    {
        private Mock<IOrderDal> orderDal;
        private OrderManager manager;

        [SetUp]
        public void Setup()
        {
            orderDal = new Mock<IOrderDal>(MockBehavior.Strict);

            manager = new OrderManager(orderDal.Object);
        }
        [Test]
        public void GetAllOrdersTest()
        {
            var to_ret = new List<OrderDTO>() { new OrderDTO {OrderID=1  } };
            orderDal.Setup(d => d.GetAllOrders()).Returns(to_ret);
            var res = manager.GetAllOrders();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
        [Test]
        public void GetOrderByIdTest()
        {
            int u_id = 1;
            var to_ret = new List<OrderDTO>() { new OrderDTO { OrderID = 1,UserID=u_id } };
            orderDal.Setup(d => d.GetAllOrders()).Returns(to_ret);
            var res = manager.GetAllOrdersByUserId(u_id);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }

    }
}
