using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.STATUS_SERVICE;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.STATUS_TESTS
{
    [TestFixture]
    public class StatusTests
    {
        IStatus StatusOk;
        IStatus StatusCalculating;

        [SetUp]
        public void Setup()
        {
            IStatus StatusOk = new OkStatus();
            IStatus StatusCalculating = new CalculatingStatus();

            this.StatusOk = StatusOk;
            this.StatusCalculating = StatusCalculating;
        }

        [Test]
        public void IsStatusOkTextReturned()
        {
            string StatusTextExpected = "Current Status: OK.";
            string StatusTextActual = "";

            StatusTextActual = StatusOk.GetStatus();

            Assert.AreEqual(StatusTextExpected, StatusTextActual);
        }

        [Test]
        public void IsStatusCalculatingTextReturned()
        {
            string StatusTextExpected = "Current Status: Calculating...";
            string StatusTextActual = "";

            StatusTextActual = StatusCalculating.GetStatus();

            Assert.AreEqual(StatusTextExpected, StatusTextActual);
        }

    }
}
