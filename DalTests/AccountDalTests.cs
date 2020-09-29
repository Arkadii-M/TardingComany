using NUnit.Framework;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.EnterpriseServices;
using DTO;
using DAL.Concrete;
namespace DALTests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class AccountDalTests : ServicedComponent
    {
        private string conn = "Data Source=DESKTOP-02EDOGO;Initial Catalog=\"Traiding Company\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public AccountDalTests()
        {

        }
        [Test]
        public void CreateAccountTest()
        {
            AccountDTO account = new AccountDTO() { UserLogin = "Account_Test", UserPassword = Encoding.ASCII.GetBytes("123(hashed)"), Salt = "S&hsdn&12jnjBHBHBH" };
            AccountDal tests = new AccountDal(conn);
            var tested = tests.CreateAccount(account);
            Assert.IsTrue(tested.UserID != 0);
        }
        [Test]
        public void GetAccountTest()
        {
            AccountDal tests = new AccountDal(conn);
            var tested_2 = tests.GetAllAccounts();
            Assert.IsTrue(tested_2.Count() > 0);
        }
        [Test]
        public void DeleteAccountTest()
        {

        }
        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
    }
}
