
namespace TestFramework.Pages
{
    public class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver) 
        {
            personalInfoPageComponent = new PersonalInfoPageComponent(driver);
        }

        private PersonalInfoPageComponent personalInfoPageComponent;
    }
}
