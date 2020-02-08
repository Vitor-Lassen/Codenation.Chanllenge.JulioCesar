using Codenation.Chanllenge.JulioCesar.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Tests.Services
{
    [TestClass]
    public class CriptServiceTest
    {
        [TestMethod]
        public void DecriptJulioCesar_WithValidTexts_Cript()
        {
            //Arrange
            string original = "abcde.fghijk,lmno/pqr-stuvwxyz";
            string expected = "bcdef.ghijkl,mnop/qrs-tuvwxyza";

            //Act
            var criptService = new CriptService();

            var result = criptService.DecriptJulioCesar(original,-1);

            //Assert
            Assert.AreEqual(result,expected);
        }
        [TestMethod]
        public void DecriptJulioCesar_WithValidTexts_Decript()
        {
            //Arrange
            string original = "abcde.fghijk,lmno/pqr-stuvwxyz";
            string expected = "zabcd.efghij,klmn/opq-rstuvwxy";

            //Act
            var criptService = new CriptService();

            var result = criptService.DecriptJulioCesar(original, 1);

            //Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void GetHashSha1_WithValidTexts()
        {
            //Arrange
            string original = "apple";
            string expected = "d0be2dc421be4fcd0172e5afceea3970e2f3d940";

            //Act
            var criptService = new CriptService();

            var result = criptService.GetHashSha1(original);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
