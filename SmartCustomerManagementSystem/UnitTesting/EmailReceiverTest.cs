using EmailCommunicator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    
    
    /// <summary>
    ///This is a test class for EmailReceiverTest and is intended
    ///to contain all EmailReceiverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmailReceiverTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ReceiveMails
        ///</summary>
        [TestMethod()]
        public void ReceiveMailsTest()
        {
            EmailReceiver target = new EmailReceiver(); // TODO: Initialize to an appropriate value
            target.ReceiveMails();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EmailReceiver Constructor
        ///</summary>
        [TestMethod()]
        public void EmailReceiverConstructorTest()
        {
            EmailReceiver target = new EmailReceiver();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
