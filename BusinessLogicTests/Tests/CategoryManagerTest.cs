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
    public class CategoryManagerTest
    {
        private Mock<ICategoryDal> categoryDal;
        private CategoryManager manager;

        [SetUp]
        public void Setup()
        {
            categoryDal = new Mock<ICategoryDal>(MockBehavior.Strict);

            manager = new CategoryManager(categoryDal.Object);
        }
        [Test]
        public void GetAllCategoriesTest()
        {
            var to_ret = new List<CategoryDTO>() { new CategoryDTO { CategoryID =1 } };
            categoryDal.Setup(d => d.GetAllCategories()).Returns(to_ret);
            var res = manager.GetAllCategories();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
    }
}
