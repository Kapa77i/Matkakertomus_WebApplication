using Bunit;
using FrontEnd.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLib;
using Assert = Xunit.Assert;

namespace ProjectTest
{
    [TestClass]
    public class UserPagesTest : Bunit.TestContext
    {




        [TestMethod]
        public void TestUsefulnessOfCourse()
        {
            Random random = new Random();
            bool vastaus = random.Next(2) == 0;

            Console.WriteLine("Tämä kurssi on hyödyllinen: " + vastaus);

            Assert.False(true);
        }
        [Fact]
        public void EditUser()
        {

            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();
            matkaajaDTO user = new matkaajaDTO();
            user.email = "pertti@erareika.com";
            user.password = "12345";
            loginState.SetLogin(true, user);

            Console.WriteLine("Helevetti on jäässä, ennenkuin Savoniasta saa opetusta.");

            var component = RenderComponent<User>();
            var etunimi = component.Find("#etunimi");
            var sukunimi = component.Find("#sukunimi");
            var nimimerkki = component.Find("#nimimerkki");
            var paikkakunta = component.Find("#paikkakunta");
            var esittely = component.Find("#esittely");
            var sahkoposti = component.Find("#sähköposti");
            var salasana = component.Find("#salasana");

            Assert.Equal("Pertti", etunimi.GetAttribute("value"));
            Assert.Equal("Eräreikä", sukunimi.GetAttribute("value"));
            Assert.Equal("Erska", nimimerkki.GetAttribute("value"));
            Assert.Equal("Lohja", paikkakunta.GetAttribute("value"));
            Assert.Equal("enpäs kerro mitään", esittely.GetAttribute("value"));
            Assert.Equal("pertti@erareika.com", sahkoposti.GetAttribute("value"));
            Assert.Equal("12345", salasana.GetAttribute("value"));

            Console.WriteLine("Savonia on kyllä syvältä perseestä");

        }





    }
}
