using Bunit;
using SharedLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using Moq;
using MyApi.Data;
using MyApi.Controllers;

namespace ProjectTest
{

    public class TripLocationTest : TestContext
    {
        /*Testataan locations -sivu. Mitä tulee esille jos on kirjautunut / kirjautumaton käyttäjä? (Linkit)?*/
        [Fact]
        public async void TestLocations()
        {
            //Arrange
            MydbContext _db = new MydbContext();
            MatkakohdesController matkakohdesController = new MatkakohdesController(_db);
            MatkaajasController matkaajasController = new MatkaajasController(_db);
            List<SharedLib.matkakohdeDTO>? locations = new List<SharedLib.matkakohdeDTO>();

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
            loginState.isLoggedIn = true;

            Services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost") });
            Services.AddSingleton<LoginState>(loginState);
           // var loginState = Services.GetRequiredService<LoginState>();

            var page = RenderComponent<FrontEnd.Pages.Locations>();
            var otsikko = page.Find("#otsikko");
            Assert.NotNull(otsikko);
            Assert.NotNull(page.Find("#klikkaa"));

            //kun on kirjauduttu sisään, nähdään linkki matkakohteiden lisäystä varten
            page.WaitForState(() => loginState.isLoggedIn == true);
            page.WaitForState(() => page.FindAll("#addlink").Count.Equals(1));
            var addlink = page.Find("#addlink");
            Assert.NotNull(addlink);

            //kun on matkakohteita ja ollaan kirjauduttu, nähdään loput sivun osat ja toiminnot (edit ja poisto -linkit)

            var actionResult = await matkakohdesController.GetLocations();
            foreach (var location in actionResult.Value)
            {
                locations.Add(location);
            }
            Assert.NotNull(page.Instance.locations);
            //page.WaitForState(() => page.FindAll("#picture").Count.Equals(11)); //pitäisi tulla 11 matkakohdetta
            //var picture = page.Find("#picture");
            //Assert.NotNull(picture);

            Checkpoint1(page, loggeduser, loginState);

        }

        //sivu renderöityy
        private static async void Checkpoint1(IRenderedComponent<FrontEnd.Pages.Locations> page, SharedLib.matkaajaDTO loggeduser, LoginState loginstate)
        {
            SharedLib.AuthUser.CurrentUser = loggeduser;
            Assert.NotNull(page);
            Assert.NotNull(loginstate.loggedUser);

            loginstate.isLoggedIn = true; 
            Assert.True(loginstate.isLoggedIn);

            Assert.NotNull(page.Instance.locations);


            //var ctx = new TestContext();
            //var cut = ctx.RenderComponent<EditForm>();
            //var addbutton = cut.Find("button");


            // var picture = page.Find("#picture");
            // Assert.NotNull(picture);
        }


        //Haetaan matkakohteet, matkakohteita on 11 kpl
        [Fact]
        public async void GetLocations()
        {
            //Arrange
            MydbContext _db = new MydbContext();
            MatkakohdesController matkakohdesController = new MatkakohdesController(_db);

            //Act
            var actionResult = await matkakohdesController.GetLocations();
            Assert.NotNull(actionResult);
            Assert.True(actionResult.Value.Count == 11);
   
        }


    }
}
