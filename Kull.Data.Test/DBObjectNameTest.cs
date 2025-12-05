using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Kull.Data.Test
{
    [TestClass]
    public class DBObjectNameTest
    {
        [TestMethod]
        public void TestKeyword()
        {
            DBObjectName dBObjectName = new DBObjectName("dbo", "SelEct");
            Assert.AreEqual(dBObjectName.ToString(false, true), "dbo.\"SelEct\"");
        }

        [TestMethod]
        public void TestKeyword2()
        {
            DBObjectName dBObjectName = "dbo.SelEct";
            Assert.AreEqual(dBObjectName.ToString(false, true), "dbo.\"SelEct\"");
        }

        [TestMethod]
        public void TestNormal()
        {
            DBObjectName dBObjectName = new DBObjectName("dbo", "SelEct_Things");
            Assert.AreEqual(dBObjectName.ToString(false, true), "dbo.SelEct_Things");
        }

        [TestMethod]
        public void TestSpace()
        {
            DBObjectName dBObjectName = new DBObjectName("dbo", "taes saf");
            Assert.AreEqual(dBObjectName.ToString(false, true), "dbo.\"taes saf\"");
        }

        [TestMethod]
        public void TestEscapedDbObjectName()
        {
            DBObjectName dBObjectName = new DBObjectName("dbo", "BulkInsert");
            Assert.AreEqual(dBObjectName.GetEscapedDbObjectName(false), "[dbo].[BulkInsert]");
        }
        [TestMethod]
        public void TestEscapedDbObjectNameWithDots()
        {
            DBObjectName dBObjectName = new DBObjectName("Sales.DataDelivery", "BulkInsert.2025");
            Assert.AreEqual(dBObjectName.GetEscapedDbObjectName(false), "[Sales.DataDelivery].[BulkInsert.2025]");
        }
        [TestMethod]
        public void TestEscapedDbObjectNameWithDotsEmptyDB()
        {
            DBObjectName dBObjectName = new DBObjectName("Sales.DataDelivery", "BulkInsert.2025");
            Assert.AreEqual(dBObjectName.GetEscapedDbObjectName(true), "[Sales.DataDelivery].[BulkInsert.2025]");
        }
        [TestMethod]
        public void TestEscapedDbObjectNameWithDotsDB()
        {
            DBObjectName dBObjectName = new DBObjectName("Sales.DataDelivery", "BulkInsert.2025", "Kull");
            Assert.AreEqual(dBObjectName.GetEscapedDbObjectName(true), "[Kull].[Sales.DataDelivery].[BulkInsert.2025]");
        }
    }
}
