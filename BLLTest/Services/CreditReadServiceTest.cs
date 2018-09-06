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
        [Fact]
        public async void CanGetAllCreditsWithCorrectType()
        {
            // Arrange
            var tsc = new TaskCompletionSource<IEnumerable<CreditEntity>>();
            tsc.SetResult(new List<CreditEntity> { new CreditEntity(), new CreditEntity() } as IEnumerable<CreditEntity>);

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.ReadCredits.GetAll()).Returns(tsc.Task);
            var creditReadService = new CreditReadService(mock.Object);

            // Arrange
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

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.ReadCredits.Get(It.IsAny<int>())).Returns(tsc.Task);
            var creditReadService = new CreditReadService(mock.Object);

            // Act
            var result = await creditReadService.GetCreditById(It.IsAny<int>());

            // Assert
            Assert.IsAssignableFrom<Credit>(result);
        }
    }
}
