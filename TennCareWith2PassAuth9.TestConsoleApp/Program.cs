
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TennCareWith2PassAuth9.TestConsoleApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        // Limit Program to run one instance only.
        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            if (PriorProcess() != null)
            {

                log.Error("Another instance of the app is already running.");
                return;
            }

            // configure logging via log4net
            string log4netConfigFullFilename =
                Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "log4net.config");
            var fileInfo = new FileInfo(log4netConfigFullFilename);
            if (fileInfo.Exists)
                log4net.Config.XmlConfigurator.Configure(fileInfo);
            else
                throw new InvalidOperationException("No log config file found");

            //Give the path of the geckodriver.exe    
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Program Files\Mozilla Firefox", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();

            TimeSpan time = TimeSpan.FromSeconds(100);

            IWebDriver browser = null;
            try
            {
                browser = new FirefoxDriver(service, options, time);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage = $"{errorMessage}\r\n\r\nInner Exception:  {ex.InnerException.Message}";
                }
                errorMessage = $"{errorMessage}\r\n\r\nExiting the application.";
                log.Error(errorMessage);
                System.Environment.Exit(1);
            }
            if (browser == null)
            {
                log.Error("The browser is null. Exiting Application.");
                System.Environment.Exit(1);
            }
            browser.Manage().Window.Maximize();
            // This will open up the URL
            browser.Url = "https://mylogin.tenncare.gov/";

            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            // If there is an alert, press the OK button of that alert
            try
            {
                IAlert myAlert = browser.SwitchTo().Alert();
                if (myAlert != null)
                {
                    myAlert.Accept();
                }
            }
            catch
            {
                
            }

            browser.Url = "https://tcmisweb.tenncare.tn.gov/tcmis/tennessee/Eligibility/ProviderEVSInquiry.asp";                                             

            string myBrowserUrl = browser.Url;

            string myPatientSSN = "268903803";
            string myPatientDOB = "08/21/1988";
            string myPatientClaimServiceDate = "11/06/2024";

            IWebElement ssnInput = null;
            ssnInput = browser.FindElement(By.Id("beneficiary SSN"));
            if (ssnInput != null)
            {
                ssnInput.SendKeys(myPatientSSN);
            }

            IWebElement dobInput = null;
            dobInput = browser.FindElement(By.Id("Recipient Date Of Birth"));
            if (dobInput != null)
            {
                dobInput.SendKeys(myPatientDOB);
            }

            IWebElement fromDosInput = null;
            fromDosInput = browser.FindElement(By.Id("from Date of Service"));
            if (fromDosInput != null)
            {
                fromDosInput.SendKeys(myPatientClaimServiceDate);
            }

            IWebElement toDosInput = null;
            toDosInput = browser.FindElement(By.Id("to Date of Service"));
            if (toDosInput != null)
            {
                toDosInput.SendKeys(myPatientClaimServiceDate);
            }

            IWebElement saveBtn = null;
            saveBtn = browser.FindElement(By.Id("save"));
            if (saveBtn != null)
            {
                saveBtn.Click();
            }

            IWebElement table1Element = browser.FindElement(By.Id("Table1"));
            if (table1Element == null)
            {
                //This is to handle an aborted thread. The DailyReportPage closes successfully. but has an async task still running, and cant be unloaded.
                //When the main thread on Form1 closed, it caused the elementId "Table1" to become orphaned and set to null crashing the program.
                //Checking if the element is not null, then run, if it becomes null for this reason exit the applicaton to the OS.
                Environment.Exit(0);
            }

            List<string> lookupResultTextLineList = new List<string>();
            IList<IWebElement> ListOfElements = table1Element.FindElements(By.TagName("tr"));

            foreach (var item in ListOfElements)
            {
                if (item != null && item.Text != null && item.Text.CompareTo("") != 0)
                {
                    lookupResultTextLineList.Add(item.Text);
                }
            }

            string lineContainingNoRecipientMatch =
                lookupResultTextLineList.Where(l => l.Contains("No Recipient match using search criteria")).FirstOrDefault();
            if (lineContainingNoRecipientMatch.Length > 0)
            {

            }

            /*if (outerText.Contains("Eligibility - Eligible for TennCare"))
                    {
                        patient.Status = "Yes";
                    }
                    if (outerText.Contains("MCO:"))
                    {
                        int num2 = outerText.IndexOf("MCO:") + 4;
                        int num3 = outerText.IndexOf("\n", num2);
                        patient.MCO = outerText.Substring(num2, num3 - num2).Trim();
                        if (patient.MCO.StartsWith("UNITED"))
                        {
                            patient.MCO = "UHC COMMUNITY PLAN";
                        }
                    }
                    if (outerText.Contains("Program") && outerText.Contains("SLMB"))
                    {
                        patient.Status = "No";
                        patient.MCO = "SLMB";
                    }
                    if (outerText.Contains("Program") && outerText.Contains("QMB"))
                    {
                        patient.Status = "Yes";
                        patient.MCO = "QMB";
                    }
                    if (outerText.Contains("No Recipient match"))
                    {
                        patient.Status = "Verify eligibility-SSN/DOB doesnt match TC records";
                    }
                    if (outerText.Contains("Not Eligible for TennCare"))
                    {
                        patient.Status = "No";
                        patient.MCO = "No MCO on record";
                    }
                    if (outerText.Contains("Part B Begin:"))
                    {
                        patient.Medicare = true;
                    }

                    if (patient.PCP == "")
                    {
                        patient.PCP = GetStringBetweenStrings(outerText, @"Reporting Period PCP Name/Organization (PCP as of the end of the request period)", @"Reporting Period PCP NPIEmail AddressTelephone Number");
                    }
                    patient.DOS = item.DOS.ToString("MM/dd/yyyy");
                    patient.Dob = item.DOB.ToString("MM/dd/yyyy");
                    patient.Ssn = item.SSN;
                    patient.AccountNumber = item.PatientID.ToString();
                    patient.FileName = item.FileName;
             */
            // TNTH735
            int i = 0;
            i++;
        }
    }
}













