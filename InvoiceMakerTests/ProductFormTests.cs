using NUnit.Framework;
using InvoiceMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker.Tests
{
    [TestFixture()]
    public class ProductFormTests
    {
        [Test()]
        public void No_ItemNumber_Fails()
        {
            ProductForm target = new ProductForm();
            String emptyString = "";
            Assert.IsFalse(target.validItemNumber(emptyString));
        }
    }
}