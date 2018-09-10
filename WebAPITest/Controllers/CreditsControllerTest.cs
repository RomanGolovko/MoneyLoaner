using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Business;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.ViewModels;
using Xunit;

namespace WebAPITest.Controllers
{
    public class CreditsControllerTest
    {
        private readonly Mock<IReadService<Credit>> _readServiceMock;
        private readonly Mock<IWriteService<Credit>> _writeServiceMock;

        public CreditsControllerTest()
        {
            _readServiceMock = new Mock<IReadService<Credit>>();
            _writeServiceMock = new Mock<IWriteService<Credit>>();
        }

        #region Get
        [Fact]
        public async void GetAll_CanGetAllCredits()
        {
            // Arrange
            var tsc = new TaskCompletionSource<IEnumerable<Credit>>();
            tsc.SetResult(new List<Credit> { new Credit(), new Credit() } as IEnumerable<Credit>);

            _readServiceMock.Setup(x => x.GetAllCredits()).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Get() as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<List<CreditViewModel>>(result.Value);
        }

        [Fact]
        public async void GetAll_CanGetNotFoundResult()
        {
            // Arrange
            var tsc = new TaskCompletionSource<IEnumerable<Credit>>();
            tsc.SetResult(new List<Credit>());

            _readServiceMock.Setup(x => x.GetAllCredits()).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Get() as StatusCodeResult;

            // Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async void GetById_CanGetCredit()
        {
            // Arrange
            var id = 8;

            var tsc = new TaskCompletionSource<Credit>();
            tsc.SetResult(new Credit { Id = id });

            _readServiceMock.Setup(x => x.GetCreditById(id)).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Get(8) as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<CreditViewModel>(result.Value);
            Assert.Equal((result.Value as CreditViewModel).Id, id);
        }

        [Fact]
        public async void GetById_CanGetBadRequestResult()
        {
            // Arrange
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Get(0) as StatusCodeResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void GetById_CanGetNotFoundResult()
        {
            // Arrange
            var tsc = new TaskCompletionSource<Credit>();
            tsc.SetResult(null);

            _readServiceMock.Setup(x => x.GetCreditById(28)).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Get() as StatusCodeResult;

            // Assert
            Assert.Equal(404, result.StatusCode);
        }
        #endregion

        #region Post
        [Theory]
        [InlineData(0, "added")]
        [InlineData(12, "updated")]
        public async void Post_ReturnsRightStateResult(int id, string state)
        {
            // Arrange
            var tsc = new TaskCompletionSource<Credit>();
            tsc.SetResult(new Credit());

            _writeServiceMock.Setup(x => x.UpsertCredit(It.IsAny<Credit>())).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Post(new CreditViewModel { Id = id }) as ObjectResult;

            // Assert
            _writeServiceMock.Verify(x => x.UpsertCredit(It.IsAny<Credit>()), Times.Once);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal($"Credit was {state}", result.Value);
        }

        [Fact]
        public async void Post_CanGetBadRequestResult()
        {
            // Arrange
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Post(null) as StatusCodeResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }
        #endregion

        #region Delete
        [Fact]
        public async void Delete_ReturnsDeletedStateResult()
        {
            // Arrange
            var tsc = new TaskCompletionSource<Credit>();
            tsc.SetResult(new Credit());

            _writeServiceMock.Setup(x => x.RemoveCredit(It.IsAny<int>())).Returns(tsc.Task);
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Delete(12) as ObjectResult;

            // Assert
            _writeServiceMock.Verify(x => x.RemoveCredit(It.IsAny<int>()), Times.Once);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Credit was deleted", result.Value);
        }

        [Fact]
        public async void Delete_CanGetBadRequestResult()
        {
            // Arrange
            var controller = new CreditsController(_readServiceMock.Object, _writeServiceMock.Object);

            // Act
            var result = await controller.Delete(null) as StatusCodeResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }
        #endregion
    }
}
