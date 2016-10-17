using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HaveYouSeenMe;
using HaveYouSeenMe.Models.Business;
using Moq;
using HaveYouSeenMe.Models;


namespace HaveYouSeenMe.Tests.Business
{
    [TestClass]
    public class PetManagementTest
    {
        [TestMethod]
        public void GetByName_ExistingPet_ReturnsPet()
        {
            // Arrange
            string petName = "Fido";
            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(x => x.GetPetByName(It.Is<string>(y=>y=="Fido"))).Returns(new Models.Pet { PetName = "Fido" });
            var pm = new PetManagement(_repository.Object);
            
            // Act
            var result = pm.GetByName(petName);

            // Assert
            // The pet exists
            Assert.IsNotNull(result);
            // The pet name is "Fido"
            Assert.AreEqual(petName, result.PetName);
        }
    }
}
