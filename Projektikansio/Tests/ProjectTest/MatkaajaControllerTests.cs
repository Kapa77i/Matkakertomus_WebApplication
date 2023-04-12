using Bunit;
using Microsoft.AspNetCore.Mvc;
using MyApi.Controllers;
using MyApi.Data;
using SharedLib;

namespace ProjectTest
{

    public class MatkaajaControllerTests
    {
        [Fact]
        public async void UserLoginSucceeds()
        {
            //Arrange
            MydbContext _db = new MydbContext();
            MatkaajasController matkaajasController = new MatkaajasController(_db);
            string username = "k@k.com";
            string password = "12345";

            //Act
            var actionResult = await matkaajasController.AuthMatkaaja(username, password);
            var actual = GetObjectResultContent<matkaajaDTO>(actionResult);

            //Assert
            Assert.NotNull(actual);
            
        }

        [Fact]
        public async void UserLoginFails()
        {
            //Arrange
            MydbContext _db = new MydbContext();
            MatkaajasController matkaajasController = new MatkaajasController(_db);
            string username = "k@k.com";
            string password = "123456";

            //Act
            var actionResult = await matkaajasController.AuthMatkaaja(username, password);
            

            //Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);

        }

        //https://stackoverflow.com/questions/51489111/how-to-unit-test-with-actionresultt/63217643#63217643
        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }

}
