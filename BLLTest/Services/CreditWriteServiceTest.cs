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
        private readonly Mock<IUnitOfWork> _uowMock;

        public CreditWriteServiceTest()
        {
            _uowMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async void CanDeleteCreditAsync()
        {
            // Arrange 
            _uowMock.Setup(x => x.WriteCredits.Delete(5)).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(_uowMock.Object);

            // Act
            await creditWriteService.RemoveCredit(5);

            // Assert
            _uowMock.Verify(x => x.WriteCredits.Delete(5), Times.Once);
            _uowMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async void CanInsertCredit()
        {
            // Arrange
            var credit = new Credit { Id = 0 };

            _uowMock.Setup(x => x.WriteCredits.Create(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            _uowMock.Setup(x => x.WriteCredits.Update(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(_uowMock.Object);

            // Act
            await creditWriteService.UpsertCredit(credit);

            // Assert
            _uowMock.Verify(x => x.WriteCredits.Create(It.IsAny<CreditEntity>()), Times.Once);
            _uowMock.Verify(x => x.WriteCredits.Update(It.IsAny<CreditEntity>()), Times.Never);
            _uowMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async void CanUpdateCredit()
        {
            // Arrange
            var credit = new Credit { Id = 13 };

            _uowMock.Setup(x => x.WriteCredits.Create(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            _uowMock.Setup(x => x.WriteCredits.Update(It.IsAny<CreditEntity>())).Returns(() => Task.FromResult(1));
            var creditWriteService = new CreditWriteService(_uowMock.Object);

            // Act
            await creditWriteService.UpsertCredit(credit);

            // Assert
            _uowMock.Verify(x => x.WriteCredits.Update(It.IsAny<CreditEntity>()), Times.Once);
            _uowMock.Verify(x => x.WriteCredits.Create(It.IsAny<CreditEntity>()), Times.Never);
            _uowMock.Verify(x => x.Save(), Times.Once);
        }
    }
}
