using Bunit;
namespace ProjectTest
{

    public class SignUpTest : TestContext
    {
        [Fact]
        public void SignInExists()
        {
            //Rekister�itymislomakkeen testit, katsotaan ett� tietyt palikat l�ytyv�t sielt�.

            var page = RenderComponent<FrontEnd.Pages.Signup>();

            var firstNameInput = page.Find("#etunimi");
            Assert.NotNull(firstNameInput);

            var lastNameInput = page.Find("#sukunimi");
            Assert.NotNull(lastNameInput);

            var usernameInput = page.Find("#nimimerkki");
            Assert.NotNull(usernameInput);

            var bioInput = page.Find("#esittely");
            Assert.NotNull(bioInput);

            var locationInput = page.Find("#paikkakunta");
            Assert.NotNull(locationInput);

            var button = page.Find("button[type='submit']");
            Assert.NotNull(button);
        }

    }
}
