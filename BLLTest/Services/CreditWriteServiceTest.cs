using BLL.Services;
using DAL.Interfaces;
using Models.Business;
using Models.BusinessModels;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BLLTest.Services
{
    public class CreditWriteServiceTest
    {
        [Fact]
        public async void CanDeleteCreditAsync()
        {
            // Arrange 
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.WriteCredits.Delete(5)).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(mock.Object);

            // Act
            await creditWriteService.RemoveCredit(5);

            // Assert
            mock.Verify(x => x.WriteCredits.Delete(5), Times.Once);
            mock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async void CanInsertCredit()
        {
            // Arrange
            var credit = new Credit { Id = 0 };

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.WriteCredits.Create(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            mock.Setup(x => x.WriteCredits.Update(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(mock.Object);

            // Act
            await creditWriteService.UpsertCredit(credit);

            // Assert
            mock.Verify(x => x.WriteCredits.Create(It.IsAny<CreditEntity>()), Times.Once);
            mock.Verify(x => x.WriteCredits.Update(It.IsAny<CreditEntity>()), Times.Never);
            mock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async void CanUpdateCredit()
        {
            // Arrange
            var credit = new Credit { Id = 13 };

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.WriteCredits.Create(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            mock.Setup(x => x.WriteCredits.Update(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(mock.Object);

            // Act
            await creditWriteService.UpsertCredit(credit);

            // Assert
            mock.Verify(x => x.WriteCredits.Update(It.IsAny<CreditEntity>()), Times.Once);
            mock.Verify(x => x.WriteCredits.Create(It.IsAny<CreditEntity>()), Times.Never);
            mock.Verify(x => x.Save(), Times.Once);
        }
    }
}
