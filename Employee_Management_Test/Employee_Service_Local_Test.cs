using Employee_Profile.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employee_Management_Test
{
    [TestClass]
    public class Employee_Service_Local_Test
    {
        
        
        [TestMethod]
        public void ValidateShortContact()
        {
           
           bool result= Employee_Service_Local.ValidateContact("78451202");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateCharContact()
        {
            bool result = Employee_Service_Local.ValidateContact("784s51202a");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateContact()
        {
            bool result = Employee_Service_Local.ValidateContact("7845120012");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateInvalidEmail()
        {
            bool result = Employee_Service_Local.ValidateEmail("abx@a");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateEmail()
        {
            bool result = Employee_Service_Local.ValidateEmail("abx@pqr.xyz");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateName()
        {
            bool result = Employee_Service_Local.ValidateName("abxaa");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateInvalidName()
        {
            bool result = Employee_Service_Local.ValidateName("abx1aa");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateInValidGender()
        {
      
                bool result = Employee_Service_Local.ValidateGender("abxaa");
                Assert.IsFalse(result);
            
        }
        [TestMethod]
        public void ValidateValidGender()
        {

            bool result = Employee_Service_Local.ValidateGender("female");
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ValidateValidDOB()
        {

            bool result = Employee_Service_Local.ValidateDOB("08/10/1998");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void ValidateInValidDOB()
        {

            bool result = Employee_Service_Local.ValidateDOB("13/14/2002");
            Assert.IsFalse(result);

        }
    }
}
