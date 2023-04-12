using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using Microsoft.Extensions.DependencyInjection;
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

            ////ALustetaan yhteys dbhen
            //private static async Task<MydbContext> GetDbContext()
            //{
            //    var options = new DbContextOptionsBuilder<MydbContext>()
            //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //        .Options;
            //    var databaseContext = new MydbContext(options);
            //    databaseContext.Database.EnsureCreated();
            //    //if(await databaseContext.Matkas.CountAsync() > 0)
            //    //{
            //    //    databaseContext.Matkas.Add(

            //    //        new Matka()
            //    //        {
            //    //            Idmatkaaja = 1,
            //    //            Alkupvm = DateTime.Parse("2023-03-03"),
            //    //            Loppupvm = DateTime.Parse("2023-03-03"),
            //    //            Yksityinen = 1
            //    //        });

            //    //    await databaseContext.SaveChangesAsync();
            //    //}

            //    return databaseContext;
            //}

            ////Tämä facta pittää olla että näkkyyy tuolla test explorelilla <-- Tiedoksi tyhmälle Kapatille
            //[Fact]
            //public async Task MatkaController_Get_Returns()
            //{

            //    //Arrange

            //           //new Matka()
            //           //{
            //           //    Idmatkaaja = 1,
            //           //    Alkupvm = DateTime.Parse("2023-03-03"),
            //           //    Loppupvm = DateTime.Parse("2023-03-03"),
            //           //    Yksityinen = 1
            //           //};

            //    var dbContext = await GetDbContext();
            //    var matkasController = new MatkasController(dbContext);

            //    //Act 

            //    var result = matkasController.GetMatkas();

            //    //Assert
            //    result.IsCompletedSuccessfully.ToString();
            //    result.ToString();


            //}
        }
    }
}