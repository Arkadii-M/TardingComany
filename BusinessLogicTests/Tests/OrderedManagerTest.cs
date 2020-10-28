using BusinessLogic.Concrete;
using DalEF.Concrete;
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
    class OrderedManagerTest
    {
        private Mock<IOrderedDal> orderedDal;
        private OrderedManager manager;

        [SetUp]
        public void Setup()
        {
            orderedDal = new Mock<IOrderedDal>(MockBehavior.Strict);

            manager = new OrderedManager(orderedDal.Object);
        }
        [Test]
        public void GetAllOrderedItemsTest()
        {
            var to_ret = new List<OrderedDTO>() { new OrderedDTO { OrderID=1 } };
            orderedDal.Setup(d => d.GetAllOrdered()).Returns(to_ret);
            var res = manager.GetAllOrderedItems();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
    }
}
