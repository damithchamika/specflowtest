using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace googlesearch.Steps
{

    [Binding]
    public sealed class StepDefinition1
    {
        public IWebDriver driver;



      //  public FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\"); // location of the geckdriver.exe file

        
        [Given(@"I have navigate to google page")]
        public void GivenIHaveNavigateToGooglePage()
        {
            driver = new ChromeDriver();

            //driver = new FirefoxDriver(service);
            driver.Url = "http://www.google.com";
        }

        [Given(@"I see the google page fully loaded")]
        public void GivenISeeTheGooglePageFullyLoaded()
        {
            if (driver.FindElement(By.Name("q")).Displayed == true)
            {
                Console.WriteLine("Page is fully loaded");
            }
            else
            {
                Console.WriteLine("Page is Not fully loaded");
            }
        }

        [When(@"I type key word as")]
        public void WhenITypeKeyWordAs(Table table)
        {

            System.Threading.Thread.Sleep(8000);
            
            dynamic credentials = table.CreateDynamicInstance();
            driver.FindElement(By.Name("q")).SendKeys(credentials.Keyword);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("//li/div/div[2]")).Click();

        }

        [Then(@"i should see a result of the key word")]
        public void ThenIShouldSeeAResultOfTheKeyWord(Table table)
        {


            System.Threading.Thread.Sleep(5000);
            dynamic key = table.CreateDynamicInstance();

            String name = key.Keyword;

            if (driver.FindElement(By.PartialLinkText(name)).Displayed==true)
            {
                Console.WriteLine("Control Exist");
            }
            else
            {
                Console.WriteLine("Control Does Not Exist");
            }

        }
    }
}
