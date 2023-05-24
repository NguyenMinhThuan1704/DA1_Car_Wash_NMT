using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void add_nv()
        {
            var bd = new DateTime(02 / 03 / 2003);
            frmNhanVien nv = new frmNhanVien();
            Assert.IsTrue(nv.add_Nv(11, "thuan", true, "Hung Yen", "0123452315", bd)); // nhập trống tất cả 
        }
    }
}
