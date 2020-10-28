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
    public class ItemManagerTest
    {
        private Mock<IItemDal> itemDal;
        private ItemManager manager;

        [SetUp]
        public void Setup()
        {
            itemDal = new Mock<IItemDal>(MockBehavior.Strict);

            manager = new ItemManager(itemDal.Object);
        }
        [Test]
        public void GetAllItemsTest()
        {
            var to_ret = new List<ItemDTO>() { new ItemDTO { ItemID=1 } };
            itemDal.Setup(d => d.GetAllItems()).Returns(to_ret);
            var res = manager.GetAllItems();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
    }
}
