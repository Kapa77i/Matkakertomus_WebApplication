using Bunit;
using SharedLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using Moq;


namespace ProjectTest
{

    public class TripLocationTest : TestContext
    {
        /*Testataan locations -sivu. Mitä tulee esille jos on kirjautunut / kirjautumaton käyttäjä? (Linkit)?*/
        [Fact]
        public async void TestLocations()
        {
            //using var ctx = new TestContext();
            //ctx.Services.AddSingleton<HttpClient>(new HttpClient());
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
            var loginState = new LoginState();
            loginState.loggedUser = loggeduser;

            Services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost") });
            Services.AddSingleton<LoginState>(loginState);
           // var loginState = Services.GetRequiredService<LoginState>();

            var page = RenderComponent<FrontEnd.Pages.Locations>();

            
            Checkpoint1(page, loggeduser, loginState);

        }

        //sivu renderöityy
        private static async void Checkpoint1(IRenderedComponent<FrontEnd.Pages.Locations> page, SharedLib.matkaajaDTO loggeduser, LoginState loginstate)
        {
            SharedLib.AuthUser.CurrentUser = loggeduser;
            Assert.NotNull(page);
            Assert.NotNull(loginstate.loggedUser);

            var otsikko = page.Find("#otsikko");
            Assert.NotNull(otsikko);
            Assert.NotNull(page.Find("#klikkaa"));

            loginstate.isLoggedIn = true; 
            Assert.True(loginstate.isLoggedIn);

            Assert.NotNull(page.Instance.locations);


            //var ctx = new TestContext();
            //var cut = ctx.RenderComponent<EditForm>();
            //var addbutton = cut.Find("button");

            //- - - - - - - - - - - - - - - - - - - - -

            //Ei löydä kuvia tai linkkejä vielä, missä vika? -Kata
            //hae locations

            //joku vika loginstatessä?

            //- - - - - - - - - - - - - - - - - - - - - 

            //var addlink = page.Find("#addlink");
            //Assert.NotNull(addlink);

            // var picture = page.Find("#picture");
            // Assert.NotNull(picture);
        }


        //Kirjautunut käyttäjä näkee sivun pääsisällön ja linkit
        [Fact]
        public void TestFetchData()
        {
            //mock datan alustaminen
            List<SharedLib.matkakohdeDTO>? locations = new List<matkakohdeDTO>(); 
            var location1 = new SharedLib.matkakohdeDTO();
            location1.idmatkakohde = 1;
            location1.kohdenimi = "Uhrikivi";
            location1.maa = "Suomi";
            location1.paikkakunta = "Kotalahti";
            location1.kuvausteksti = "Joku sisällissodan aikainen muistihärpäke";
            location1.kuva = "Uhrikivi.jpg";

            var location2 = new SharedLib.matkakohdeDTO();
            location2.idmatkakohde = 2;
            location2.kohdenimi = "Mualiman Napa";
            location2.maa = "Suomi";
            location2.paikkakunta = "Kuopio";
            location2.kuvausteksti = "Maailman napa.";
            location2.kuva = "MualimanNapa.jpg";

            locations.Add(location1);
            locations.Add(location2);

           
            //mock datan hakeminen
            //var fetchService = new MockFetchDataService<matkakohdeDTO>();
            
            //fetchService.Setup(x => x.FetchDataAsync()).ReturnsAsync(locations);

            
        }

       
       
    }
}
