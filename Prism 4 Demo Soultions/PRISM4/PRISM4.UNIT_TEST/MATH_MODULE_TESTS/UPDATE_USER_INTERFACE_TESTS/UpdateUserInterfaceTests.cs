using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.UPDATE_USER_INTERFACE_TESTS
{
    [TestFixture]
    public class UpdateUserInterfaceTests
    {
        private UpdateUserInterface UpdateUI;
        private IUpdateUIState BlankOrClearUIState;

        [SetUp]
        public void SetupFixture()
        {

        }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            IUpdateUIState BlankOrClearUIState = new TextboxOneAndTwoBlankOrClearState();
            //UpdateUserInterface UpdateUI = new UpdateUserInterface(BlankOrClearUIState);
        }

        [Test]
        public void ConfirmTypeBothBlankOrClear()
        {
           
        }
    }
}
