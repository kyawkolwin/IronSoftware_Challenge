using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    using IronSoftware_Challenge;
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ConvertNumberToOneCharacter()
        {
            //Arrange
            string sNumber = "2";

            //Act
            PrivateObject obj = new PrivateObject(typeof(frmoldMobilekeypad));
            string strResult = obj.Invoke("oldPhonePad", sNumber).ToString();

            //Assert
            Assert.AreEqual("a", strResult,"Expected Result 'a' and " + strResult + " are same");
        }
    }
}
