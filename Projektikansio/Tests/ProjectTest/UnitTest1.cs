using Bunit;
namespace ProjectTest
{

    public class SignUpTest : TestContext
    {
        [Fact]
        public void SignInExists()
        {
            var page = RenderComponent<FrontEnd.Pages.Signup>();

            Checkpoint1(page);
            Checkpoint2(page);
            Checkpoint3(page);
            Checkpoint4(page);
            Checkpoint5(page);
            Checkpoint6(page);
            Checkpoint7(page);
            Checkpoint8(page);
            Checkpoint9(page);
        }

        private static void Checkpoint1(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var firstNameInput = page.Find("#etunimi");
            Assert.NotNull(firstNameInput);
        }

        private static void Checkpoint2(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var lastNameInput = page.Find("#sukunimi");
            Assert.NotNull(lastNameInput);
        }

        private static void Checkpoint3(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var usernameInput = page.Find("#nimimerkki");
            Assert.NotNull(usernameInput);
        }

        private static void Checkpoint4(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var bioInput = page.Find("#esittely");
            Assert.NotNull(bioInput);
        }

        private static void Checkpoint5(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var locationInput = page.Find("#paikkakunta");
            Assert.NotNull(locationInput);
        }

        private static void Checkpoint6(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var emailInput = page.Find("#email");
            Assert.NotNull(emailInput);
        }

        private static void Checkpoint7(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var passwordInput = page.Find("#password");
            Assert.NotNull(passwordInput);
        }

        private static void Checkpoint8(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var button = page.Find("button[type='submit']");
            Assert.NotNull(button);
        }

        private static void Checkpoint9(IRenderedComponent<FrontEnd.Pages.Signup> page)
        {
            var radioButton = page.Find("input[type='radio'][name='kuva'][value='1.png'][checked]");
            Assert.NotNull(radioButton);
        }


    }
}
