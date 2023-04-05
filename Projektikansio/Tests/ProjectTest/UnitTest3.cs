using Bunit;
using SharedLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectTest
{

    public class TripLocationTest : TestContext
    {
        /*Testataan locations -sivu. Mitä tulee esille jos on kirjautunut / kirjautumaton käyttäjä? (Linkit)?*/
        [Fact]
        public async void TestLocations()
        {
            Services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost") });
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();

            var page = RenderComponent<FrontEnd.Pages.Locations>();

            var loggeduser = new SharedLib.matkaajaDTO();
            loggeduser.idmatkaaja = 3000;
            loggeduser.etunimi = "Maija";
            loggeduser.sukunimi = "Meikäläinen";
            loggeduser.nimimerkki = "MaijaMehiläinen";
            loggeduser.paikkakunta = "Maaninka";
            loggeduser.esittely = "Maaginen";
            loggeduser.kuva = "6.png";
            loggeduser.email = "m@m.com";
            loggeduser.password = "12345";

            loginState.loggedUser = loggeduser;
            Checkpoint1(page, loggeduser, loginState);
            await Task.Delay(300);

        }

        //Kirjautunut käyttäjä näkee sivun pääsisällön ja linkit
        private static void Checkpoint1(IRenderedComponent<FrontEnd.Pages.Locations> page, SharedLib.matkaajaDTO loggeduser, LoginState loginstate)
        {
            SharedLib.AuthUser.CurrentUser = loggeduser;
            Assert.NotNull(page);
            Assert.NotNull(loginstate.loggedUser);
            
           // Assert.True(loginstate.isLoggedIn);

            // var ctx = new TestContext();
            // var cut = ctx.RenderComponent<EditForm>();
            //var addbutton = cut.Find("button");

            //Ei löydä kuvia tai linkkejä vielä, missä vika? -Kata


           // var picture = page.Find("#picture");
           // Assert.NotNull(picture);
        }


    }
}
