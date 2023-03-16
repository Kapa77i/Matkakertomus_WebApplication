using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using SharedLib;
using FrontEnd;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Components;
using Moq;
using System.Net;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Sdk;


namespace ProjectTest
{
    public class RegTest : TestContext
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        [Fact]
        public void TestReg()
        {
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();

            // Render the NavMenu component
            var component = RenderComponent<NavMenu>();

            // Find the Kirjaudu sisään button
            var RegistryButton = component.Find("#rekisteroidy");

            // Simulate a click on the button
            RegistryButton.Click();

            // Assert that the user is redirected to the login page
            var navigationManager = Services.GetRequiredService<NavigationManager>();
            Assert.Equal("http://localhost/", navigationManager.Uri);


            //    var comp = RenderComponent<Signup>();
            //    var emailInput = comp.Find("#email");
            //    var passwordInput = comp.Find("#password");
            //    var nameInput = comp.Find("#etunimi");
            //    var lastNameInput = comp.Find("#sukunimi");
            //    var nickNameInput = comp.Find("#nimimerkki");
            //    var introductionInput = comp.Find("#esittely");
            //    var cityInput = comp.Find("#paikkakunta");

            //    var submitButton = comp.Find("button[type='submit']");


            //    // Act

            //    //matkaajaDTO testimatkaaja = new matkaajaDTO();
            //    //testimatkaaja.email = "testi@testaaja.fi";
            //    //testimatkaaja.password = "12345";
            //    //testimatkaaja.etunimi = "Unit";
            //    //testimatkaaja.sukunimi = "Test";
            //    //testimatkaaja.nimimerkki = "Testityyppi";
            //    //testimatkaaja.esittely = "Tämä on unit test!";
            //    //testimatkaaja.paikkakunta = "Testikaupunki";
            //    emailInput.Change("testi@testaaja.fi");
            //    passwordInput.Change("12345");
            //    nameInput.Change("Unit");
            //    lastNameInput.Change("Test");
            //    nickNameInput.Change("Testityyppi");
            //    introductionInput.Change("Tämä on unit test!");
            //    cityInput.Change("Testikaupunki");

            //    submitButton.Click();
            //    // Wait for the login to complete

            //    // Assert
            //    Assert.Equal("http://localhost/", navigationManager.Uri);


            //}

            // Arrange

            using var ctx = new TestContext();
            ctx.Services.AddSingleton<HttpClient>(_httpClient);
            ctx.Services.AddSingleton<NavigationManager>(_navigationManager);

         
            var page = ctx.RenderComponent<Signup>();

            var user = new matkaajaDTO
                {
                    etunimi = "John",
                    sukunimi = "Doe",
                    nimimerkki = "johndoe",
                    esittely = "Lorem ipsum",
                    paikkakunta = "Helsinki",
                    kuva = "1.png"
                };
            page.Instance.user = user;
     

            // Act
           

            // Assert
            Assert.NotNull(page.Instance.user);
            Assert.Equal(user.etunimi, page.Instance.user.etunimi);
            Assert.Equal(user.sukunimi, page.Instance.user.sukunimi);
            Assert.Equal(user.nimimerkki, page.Instance.user.nimimerkki);
            Assert.Equal(user.esittely, page.Instance.user.esittely);
            Assert.Equal(user.paikkakunta, page.Instance.user.paikkakunta);
            Assert.Equal(user.kuva, page.Instance.user.kuva);
        }
    }

    public class MockNavigationManager : NavigationManager
    {
        public MockNavigationManager()
        {
            Initialize("https://localhost/", "https://localhost/");
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            // Do nothing - mock implementation
        }
    }

}



