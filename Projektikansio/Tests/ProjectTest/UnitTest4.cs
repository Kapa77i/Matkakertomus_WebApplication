using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApi.Controllers;
using MyApi.Data;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest
{
    public class GroupTrips : TestContext
    {
        //Tämä facta pittää olla että näkkyyy tuolla test explorelilla <-- Tiedoksi tyhmälle Kapatille
        [Fact]
        public async Task TestGrouptripsPage()
        {
            Services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost") });
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();
            loginState.SetLogin(false, null);

            var navMenuComponent = RenderComponent<NavMenu>();

            var kirjauduButton = navMenuComponent.Find("#kirjaudu");
            kirjauduButton.Click();

            await Task.Delay(500);
           
        }

        [Fact]
        public async Task MatkaController_Get_Returns()
        {

            MydbContext dbContext = new MydbContext();
            MatkasController matkasController = new MatkasController(dbContext);

            //Act 
            var result = matkasController.GetMatkas();

            //Assert
            Assert.NotNull(result);

            //var actionResult = await matkasController.GetMatkas();
            //Assert.IsType<OkObjectResult>(actionResult.Result);
            //var resultObject = GetObjectResultContent<List<Matka>>(actionResult);


        }

        [Fact]
        public async void MatkasController_GetIdMatka_Returns()
        {
            //Arrange
            MydbContext dbContext = new MydbContext();
            MatkasController matkasController = new MatkasController(dbContext);
            long matkaId = 1;

            //Act
            var actionResult = await matkasController.GetMatka(matkaId);
            //Assert.IsType<OkObjectResult>(actionResult.Result);
            //var actual = GetObjectResultContent<Matka>(actionResult);

            //Assert
            Assert.NotNull(actionResult.Value);

        }


        //Vaatii toimiakseen
        //https://stackoverflow.com/questions/51489111/how-to-unit-test-with-actionresultt/63217643#63217643
        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }

    }
}