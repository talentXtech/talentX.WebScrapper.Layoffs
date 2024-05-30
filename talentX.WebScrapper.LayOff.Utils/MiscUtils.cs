using OpenQA.Selenium.Chrome;
using talentX.WebScrapper.LayOff.Extensions;
using OpenQA.Selenium;

namespace talentX.WebScrapper.LayOff.Utils
{
    public class MiscUtils
    {
        public static int FIndTotalNoOfData(ChromeDriver driver)
        {
            var dataCount = driver.FindElementTextByClass("selectionCount");

            string[] countOfData = dataCount.Split(" ");
            int totalNoOfData = int.Parse(countOfData[0], System.Globalization.NumberStyles.AllowThousands);
            return totalNoOfData;
        }
        public static void CloseComplianceOverlay(ChromeDriver driver)
        {
            try
            {
                var complianceOverlayElement = driver.FindElements(By.Id("onetrust-button-group"));
                if (complianceOverlayElement.Count() > 0) { complianceOverlayElement[0].ClickButtonById("onetrust-accept-btn-handler"); }
            }
            catch (Exception)
            {

                Console.WriteLine("Stale error skipped");
            }
        }
    }
    
}
