using BLL.Services;
using DAL.Interfaces;
using Models.Business;
using Models.BusinessModels;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BLLTest.Services
{
    public class CreditReadServiceTest
    {
        private readonly Mock<IUnitOfWork> _uowMock;

        public CreditReadServiceTest()
        {
            _uowMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async void CanGetAllCreditsWithCorrectType()
        {
            // Arrange
            var tsc = new TaskCompletionSource<IEnumerable<CreditEntity>>();
            tsc.SetResult(new List<CreditEntity> { new CreditEntity(), new CreditEntity() } as IEnumerable<CreditEntity>);

            _uowMock.Setup(x => x.ReadCredits.GetAll()).Returns(tsc.Task);
            var creditReadService = new CreditReadService(_uowMock.Object);

            // Act
            var result = await creditReadService.GetAllCredits();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Credit>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void CanGetCreditById()
        {
            // Arrange
            var tsc = new TaskCompletionSource<CreditEntity>();
            tsc.SetResult(new CreditEntity());

            _uowMock.Setup(x => x.ReadCredits.Get(It.IsAny<int>())).Returns(tsc.Task);
            var creditReadService = new CreditReadService(_uowMock.Object);

            // Act
            var result = await creditReadService.GetCreditById(It.IsAny<int>());

            // Assert
            Assert.IsAssignableFrom<Credit>(result);
        }
    }
}
