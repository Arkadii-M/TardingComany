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
    class OrderStatusManagerTest
    {
        private Mock<IOrderStatusDal> orderStatusDal;
        private OrderStatusManager manager;

        [SetUp]
        public void Setup()
        {
            orderStatusDal = new Mock<IOrderStatusDal>(MockBehavior.Strict);

            manager = new OrderStatusManager(orderStatusDal.Object);
        }
        [Test]
        public void GetStatusesTest()
        {
            var to_ret = new List<OrderStatusDTO>() { new OrderStatusDTO {StatusID=1 } };
            orderStatusDal.Setup(d => d.GetAllOrderStatuses()).Returns(to_ret);
            var res = manager.GetAllOrderStatuses();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
        [Test]
        public void GetStatusByIdTest()
        {
            int st_id = 1;
            var to_ret =  new OrderStatusDTO { StatusID = st_id } ;
            orderStatusDal.Setup(d => d.GetOrderStatusByID(st_id)).Returns(to_ret);
            var res = manager.GetOrderStatusById(st_id);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.StatusID, st_id);
        }

    }
}
