using Bunit;

namespace ProjectTest
{

    public class TripLocationTest : TestContext
    {
        /*Testataan locations -sivu. Mitä tulee esille jos on kirjautunut / kirjautumaton käyttäjä? (Linkit)?*/
        [Fact]
        public async void TestLocations()
        {
            var page = RenderComponent<FrontEnd.Pages.Locations>();
        }


    }
}
