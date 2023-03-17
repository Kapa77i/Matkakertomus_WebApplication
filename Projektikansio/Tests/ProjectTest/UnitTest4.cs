using Bunit;
using FrontEnd.Pages;
using Microsoft.Extensions.DependencyInjection;
using SharedLib;

namespace ProjectTest
{
    public class UserEditTest : TestContext
    {
        [Fact]
        public void EditUser()
        {

            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();
            matkaajaDTO user = new matkaajaDTO();
            user.email = "keijo.kuosmanen@savonia.fi";
            user.password = "Salasana12345";
            loginState.SetLogin(true, user);



            var component = RenderComponent<User>();

            var etunimi = component.Find("#etunimi");
            etunimi.Change("Hello, world!");
            var sukunimi = component.Find("#sukunimi");
            sukunimi.Change("Hello, world!");
            var nimimerkki = component.Find("#nimimerkki");
            nimimerkki.Change("Hello, world!");
            var paikkakunta = component.Find("#paikkakunta");
            paikkakunta.Change("Hello, world!");
            var esittely = component.Find("#esittely");
            esittely.Change("Hello, world!");
            var sahkoposti = component.Find("#sähköposti");
            sahkoposti.Change("Hello, world!");
            var salasana = component.Find("#salasana");
            salasana.Change("Hello, world!");

            Assert.Equal("Hello, world!", etunimi.GetAttribute("value"));
            Assert.Equal("Hello, world!", sukunimi.GetAttribute("value"));
            Assert.Equal("Hello, world!", nimimerkki.GetAttribute("value"));
            Assert.Equal("Hello, world!", paikkakunta.GetAttribute("value"));
            Assert.Equal("Hello, world!", esittely.GetAttribute("value"));
            Assert.Equal("Hello, world!", sahkoposti.GetAttribute("value"));
            Assert.Equal("Hello, world!", salasana.GetAttribute("value"));


            Assert.True(true);
        }
    }
}
