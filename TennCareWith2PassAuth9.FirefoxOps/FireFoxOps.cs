using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.FirefoxOps
{
    public class FireFoxOps
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FireFoxOps));
        // Constructor for starting the Firefox browser.
        public FireFoxOps(ConfigOptions inputConfigOptions)
        {
            MyConfigOptions = inputConfigOptions;
        }

        public ConfigOptions MyConfigOptions { get; set; }

        public FirefoxPatientInfoToLookUp MyFirefoxPatientInfoToLookUp { get; set; }
        public List<string> MyTennCareListOfInfoForPatient { get; set; }
        public FirefoxEligInfoForPatient MyFirefoxEligInfoForPatient { get; set; }


        public IWebDriver MyFirefoxBrowser { get; set; }
        public void StartFirefoxBrowser()
        {
            //Give the path of the geckodriver.exe    
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(MyConfigOptions.DbConfigSettingsFireFoxDirectory, "geckodriver.exe");
            service.FirefoxBinaryPath = $"{MyConfigOptions.DbConfigSettingsFireFoxDirectory}\\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();

            TimeSpan time = TimeSpan.FromSeconds(100);

            try
            {
                MyFirefoxBrowser = new FirefoxDriver(service, options, time);
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
            if (MyFirefoxBrowser == null)
            {
                log.Error("The browser is null. Exiting Application.");
                System.Environment.Exit(1);
            }
            MyFirefoxBrowser.Manage().Window.Maximize();
            // This will open up the URL
            MyFirefoxBrowser.Url = "https://mylogin.tenncare.gov/";

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            // If there is an alert, press the OK button of that alert
            try
            {
                IAlert myAlert = MyFirefoxBrowser.SwitchTo().Alert();
                if (myAlert != null)
                {
                    myAlert.Accept();
                }
            }
            catch
            {

            }

        }
        public void LookUpTennCareEligibility()
        {
            if (MyFirefoxBrowser == null)
            {
                log.Error($"Firefox browser seems to have gone missing.");
                return;
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            MyFirefoxBrowser.Url = "https://tcmisweb.tenncare.tn.gov/tcmis/tennessee/Eligibility/ProviderEVSInquiry.asp";

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            string myBrowserUrl = MyFirefoxBrowser.Url;
            // If we logged in successfully, the Reset button would be visible. If it is not, exit the application.
            try
            {
                // Click on reset.
                MyFirefoxBrowser.FindElement(By.Id("btnReset")).Click();
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

            IWebElement ssnInput = null;
            ssnInput = MyFirefoxBrowser.FindElement(By.Id("beneficiary SSN"));
            if (ssnInput != null)
            {
                ssnInput.SendKeys(MyFirefoxPatientInfoToLookUp.SSN);
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement dobInput = null;
            dobInput = MyFirefoxBrowser.FindElement(By.Id("Recipient Date Of Birth"));
            if (dobInput != null)
            {
                dobInput.SendKeys(MyFirefoxPatientInfoToLookUp.DOB.ToString("MM/dd/yyyy"));
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement fromDosInput = null;
            fromDosInput = MyFirefoxBrowser.FindElement(By.Id("from Date of Service"));
            if (fromDosInput != null)
            {
                fromDosInput.SendKeys(MyFirefoxPatientInfoToLookUp.DOS.ToString("MM/dd/yyyy"));
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement toDosInput = null;
            toDosInput = MyFirefoxBrowser.FindElement(By.Id("to Date of Service"));
            if (toDosInput != null)
            {
                toDosInput.SendKeys(MyFirefoxPatientInfoToLookUp.DOS.ToString("MM/dd/yyyy"));
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement saveBtn = null;
            saveBtn = MyFirefoxBrowser.FindElement(By.Id("save"));
            if (saveBtn != null)
            {
                saveBtn.Click();
            }

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement table1Element = MyFirefoxBrowser.FindElement(By.Id("Table1"));
            if (table1Element == null)
            {
                //This is to handle an aborted thread. The DailyReportPage closes successfully. but has an async task still running, and cant be unloaded.
                //When the main thread on Form1 closed, it caused the elementId "Table1" to become orphaned and set to null crashing the program.
                //Checking if the element is not null, then run, if it becomes null for this reason exit the applicaton to the OS.
                Environment.Exit(0);
            }

            MyTennCareListOfInfoForPatient = new List<string>();
            IList<IWebElement> ListOfElements = table1Element.FindElements(By.TagName("tr"));

            foreach (var item in ListOfElements)
            {
                if (item != null && item.Text != null && item.Text.CompareTo("") != 0)
                {
                    MyTennCareListOfInfoForPatient.Add(item.Text);
                }
            }

            // If the look-up found no eligibility info.
            string lineContainingNoRecipientMatch = string.Empty;
            lineContainingNoRecipientMatch =
                MyTennCareListOfInfoForPatient.Where(l => l.Contains("No Recipient match using search criteria")).FirstOrDefault();
            if (lineContainingNoRecipientMatch != null && lineContainingNoRecipientMatch.Length > 0)
            {
                MyTennCareListOfInfoForPatient =
                    new List<string>();
            }

            // If we found some eligibility info to parse,
            // parse it.
            if (MyTennCareListOfInfoForPatient.Count > 0)
            {
                GivenOutputLinesOutputEligInfoForPatient();
            }
        }
        public void GivenOutputLinesOutputEligInfoForPatient()
        {
            MyFirefoxEligInfoForPatient = new FirefoxEligInfoForPatient();
            if (MyTennCareListOfInfoForPatient.Count == 0)
            {
                return;
            }

            // Import Filename
            MyFirefoxEligInfoForPatient.ImportFileName =
                MyFirefoxPatientInfoToLookUp.FileName;

            // SSN
            MyFirefoxEligInfoForPatient.SSN =
                MyFirefoxPatientInfoToLookUp.SSN;

            // DOB
            MyFirefoxEligInfoForPatient.DOB =
                MyFirefoxPatientInfoToLookUp.DOB;

            // DOS
            MyFirefoxEligInfoForPatient.DOS =
                MyFirefoxPatientInfoToLookUp.DOS;

            // AccountNumber
            MyFirefoxEligInfoForPatient.PatientID =
                MyFirefoxPatientInfoToLookUp.PatientID.ToString();

            // ImportFileDate
            MyFirefoxEligInfoForPatient.DateImported =
                MyFirefoxPatientInfoToLookUp.DateImported;

            //"Eligibility - Eligible for TennCare"
            string eligibleForTennCare = null;
            eligibleForTennCare =
                MyTennCareListOfInfoForPatient.Where(e => e.Contains("Eligibility - Eligible for TennCare")).FirstOrDefault();
            if (eligibleForTennCare != null)
            {
                MyFirefoxEligInfoForPatient.Status = "Yes";
            }


            // MCO
            string mcoLine = string.Empty;
            string myMco = string.Empty;
            mcoLine = MyTennCareListOfInfoForPatient.Where(e => e.Contains("MCO:")).FirstOrDefault();
            if (mcoLine != null && mcoLine.Length > 0)
            {
                Regex mcoRegEx = new Regex(@"MCO:\s+(?<mco>.+)");
                Match mcoMatch = mcoRegEx.Match(mcoLine);
                if (mcoMatch.Success)
                {
                    myMco = mcoMatch.Groups["mco"].Value.Trim();
                }
                if (myMco.StartsWith("UNITED"))
                {
                    myMco = "UHC COMMUNITY PLAN";
                }
            }
            
            if (myMco.Length > 0)
            {
                MyFirefoxEligInfoForPatient.MCO = myMco;
            }

            // Determine if "Program" appears in lines.
            string myProgramContainedInLines = null;
            myProgramContainedInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("Program")).FirstOrDefault();

            // Determine if "SLMB" appears in lines.
            string mySLMBContainedInLines = null;
            mySLMBContainedInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("SLMB")).FirstOrDefault();

            // Determine if "QMB" appears in lines.
            string myQMBContainedInLines = null;
            myQMBContainedInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("QMB")).FirstOrDefault();

            // If "Program" and "SLMB" appears lines
            if (myProgramContainedInLines != null && mySLMBContainedInLines != null)
            {
                MyFirefoxEligInfoForPatient.Status = "No";
                MyFirefoxEligInfoForPatient.MCO = "SLMB";
            }

            // If "Program" and "QMB" appears lines
            if (myProgramContainedInLines != null && myQMBContainedInLines != null)
            {
                MyFirefoxEligInfoForPatient.Status = "Yes";
                MyFirefoxEligInfoForPatient.MCO = "QMB";
            }

            // Determine if "No Recipient match" appears in lines.
            string myNoRecipientMatchInLines = null;
            myNoRecipientMatchInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("No Recipient match")).FirstOrDefault();

            // If "No Recipient match" appears in lines.
            if (myNoRecipientMatchInLines != null)
            {
                MyFirefoxEligInfoForPatient.Status = "Verify eligibility-SSN/DOB doesnt match TC records";
            }

            // Determine if "Not Eligible for TennCare" appears in lines
            string myNotEligibleForTennCareInLines = null;
            myNotEligibleForTennCareInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("Not Eligible for TennCare")).FirstOrDefault();

            // If "Not Eligible for TennCare" appears in lines.
            if (myNotEligibleForTennCareInLines != null)
            {
                MyFirefoxEligInfoForPatient.Status = "No";
                MyFirefoxEligInfoForPatient.MCO = "No MCO on record";
            }

            // Determine if "Part B Begin:" appears in lines
            string myPartBBeginInLines = null;
            myPartBBeginInLines =
                MyTennCareListOfInfoForPatient.Where(p => p.Contains("Part B Begin:")).FirstOrDefault();


            // If "Part B Begin:" appears in lines.
            MyFirefoxEligInfoForPatient.Medicare = "False";
            if (myPartBBeginInLines != null)
            {
                MyFirefoxEligInfoForPatient.Medicare = "True";
            }

            // Determine PCP value.
            MyFirefoxEligInfoForPatient.PCP = string.Empty;
            int reportingPeriodPcpNameLineNumber = -1;
            reportingPeriodPcpNameLineNumber =
                MyTennCareListOfInfoForPatient.IndexOf("Reporting Period PCP Name/Organization (PCP as of the end of the request period)");

            if (reportingPeriodPcpNameLineNumber != -1)
            {
                List<string> myPcpLineList = new List<string>();
                int lineNumber = reportingPeriodPcpNameLineNumber;
                lineNumber = reportingPeriodPcpNameLineNumber + 1;
                while (lineNumber < MyTennCareListOfInfoForPatient.Count)
                {
                    string lineContent = MyTennCareListOfInfoForPatient[lineNumber].Trim();
                    if (lineContent.Contains("Reporting Period PCP NPI"))
                    {
                        break;
                    }
                    if (lineContent.Length > 0)
                    {
                        myPcpLineList.Add(MyTennCareListOfInfoForPatient[lineNumber]);
                    }
                    lineNumber++;
                }
                MyFirefoxEligInfoForPatient.PCP = string.Join("\\n", myPcpLineList);
            }

            // If status is NOT 'Yes', tell outside program we have no
            // eligibility info to save.
            if (MyFirefoxEligInfoForPatient.Status.CompareTo("Yes") != 0)
            {
                MyFirefoxEligInfoForPatient = new FirefoxEligInfoForPatient();
                MyTennCareListOfInfoForPatient = new List<string>();                
            }
            else
            {
                BuildTennCareEligibilityString();
            }
            /*  Trying to emulate the old Windows program
             * 
             * if (outerText.Contains("Eligibility - Eligible for TennCare"))
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

                    if (!(patient.Status == "Yes"))
                    {
                        continue;
                    }
                    SetTennCareElligibilityInformation(patient);
                    patients.Add(patient);
             */
           
        }
        public void BuildTennCareEligibilityString()
        {
            string result = string.Empty;
            result = MyFirefoxEligInfoForPatient.PatientID + " 1   DOS " + MyFirefoxEligInfoForPatient.DOS.ToString("MM/dd/yyyy") + "_TennCare_Yes_MCO=" + MyFirefoxEligInfoForPatient.MCO + " ";
            if (MyFirefoxEligInfoForPatient.Medicare.Length > 0)
            {
                result = result + MyFirefoxEligInfoForPatient.PatientID + " 1 As of " + MyFirefoxEligInfoForPatient.DOS.ToString("MM/dd/yyyy") + "_TNANYTIME_Medicare Part B ";
            }
            if (MyFirefoxEligInfoForPatient.PCP.Length > 0)
            {
                result = result + MyFirefoxEligInfoForPatient.PatientID + " 1 As of " + MyFirefoxEligInfoForPatient.DOS.ToString("MM/dd/yyyy") + "_TennCare PCP: " + MyFirefoxEligInfoForPatient.PCP + " ";
            }

            MyFirefoxEligInfoForPatient.TennCareEligibility = result.Replace(@"\r\n", " ").Replace(",", "").Trim();
        }
        public void LogOutOfBrowser()
        {
            // Log off of TennCare site.
            MyFirefoxBrowser.Url = "https://tcmisweb.tenncare.tn.gov/tcmis/tennessee/security/logoff.asp";

            MyFirefoxBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            // Close browser
            MyFirefoxBrowser.Quit();

            MyFirefoxBrowser.Dispose();
        }

    }
}
