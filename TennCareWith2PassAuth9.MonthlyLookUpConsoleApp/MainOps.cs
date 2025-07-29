using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TennCareWith2PassAuth9.CallWebApiLand;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.MonthlyLookUpConsoleApp
{
    public class MainOps
    {
        public MainOps
                (
                    ConfigOptions inputFileConfigOptions
                    ,qy_GetTennCareWith2PassAuthConfigOutputColumns inputqy_GetTennCareWith2PassAuthConfigOutputColumns
                )
        {
            MyFileConfigOptions =
                inputFileConfigOptions;

            MyConfigOptions =
                inputqy_GetTennCareWith2PassAuthConfigOutputColumns;
        }

        // MyConfigOptions
        public
            qy_GetTennCareWith2PassAuthConfigOutputColumns
                MyConfigOptions
        { get; set; }

        // MyConfigOptions
        public
            ConfigOptions
                MyFileConfigOptions
        { get; set; }

        public MainOpsOutput MyMain()
        {
            MainOpsOutput returnOutput =
                new MainOpsOutput();

            // Get all Monthly needing to be looked up.
            qy_GetMonthlyToLookUpOutput
                myqy_GetMonthlyToLookUpOutput =
                    GetAllMonthlyEntriesLookedUpToday();
            if (!myqy_GetMonthlyToLookUpOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetMonthlyToLookUpOutput.ErrorMessage;
                return returnOutput;
            }
            if (
                    myqy_GetMonthlyToLookUpOutput
                    .qy_GetMonthlyToLookUpOutputColumnsList
                    .Count == 0
                )
            {
                Console.WriteLine("There are no Monthly entries today.  Program is Ending.");
                return returnOutput;
            }

            // Given there are entries to look up, Truncate the Eligibility Info Output table.
            dd_MonthlyEligibilityOutput
                mydd_MonthlyEligibilityOutput =
                    TruncateMonthlyEntriesYieldingEligInfoToday();
            if (!mydd_MonthlyEligibilityOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydd_MonthlyEligibilityOutput.ErrorMessage;
                return returnOutput;
            }


            FirefoxOps.FireFoxOps
                myFirefoxOps =
                    new FirefoxOps.FireFoxOps(MyFileConfigOptions);
            myFirefoxOps.StartFirefoxBrowser();
            if (myFirefoxOps.MyFirefoxBrowser == null)
            {
                Console.WriteLine("Something went wrong with the Firefox browser.  Program is exiting.");
                return returnOutput;
            }

            // Ask user to log into the TennCare site
            // and to navigate to the TennCare Eligibility
            // screen.
            Console.WriteLine("\r\nYour firefox Browser should have started at the TennCare LogIn screen.  Please log in and navigate to the TennCare Eligibility screen.  Is your browser on the TennCare Eligibility screen (y/n)?");
            string onEligibilityScreenAnswer =
                Console.ReadLine();

            // If user does not answer that they've got their Firefox browser ready to perform
            // the mass-lookup, exit.
            if (onEligibilityScreenAnswer.ToUpper().CompareTo("Y") != 0)
            {
                Console.WriteLine("You must navigate to the TennCare Eligibility screen so that this program can determine the eligibility of many patients.  Exiting the program.");
                return returnOutput;
            }

            for (int entryCtr = 0; entryCtr < myqy_GetMonthlyToLookUpOutput.qy_GetMonthlyToLookUpOutputColumnsList.Count; entryCtr++)
            {
                qy_GetMonthlyToLookUpOutputColumns
                    loopEntry =
                        myqy_GetMonthlyToLookUpOutput
                        .qy_GetMonthlyToLookUpOutputColumnsList[entryCtr];
                int oneBasedEntryCtr = entryCtr + 1;
                Console.WriteLine($"Monthly Patient Appt {oneBasedEntryCtr} of {myqy_GetMonthlyToLookUpOutput.qy_GetMonthlyToLookUpOutputColumnsList.Count} being looked up.");
                if (loopEntry.PatientID == 1189234)
                {
                    int i = 0;
                    i++;
                }
                FirefoxPatientInfoToLookUp
                    myEntryToLookUp =
                        new FirefoxPatientInfoToLookUp
                        {
                            FileName = loopEntry.ImportFullFilename,
                            PatientID = loopEntry.PatientID,
                            DOB = loopEntry.DOB,
                            DOS = loopEntry.DOS,
                            SSN = loopEntry.SSN,
                            DateImported = loopEntry.DateImported,
                            PatientName = (loopEntry.PatientName.Length == 0) ? "MT" : loopEntry.PatientName
                        };
                myFirefoxOps.MyFirefoxPatientInfoToLookUp =
                    myEntryToLookUp;
                myFirefoxOps.LookUpTennCareEligibility();

                // Update the look-up entry as Looked Up.
                du_MarkMonthlyToLookUpAsLookedUpOutput
                    mydu_MarkMonthlyToLookUpAsLookedUpOutput =
                        MarkMonthlyEntryLookedUpTodayAsLookedUp
                        (
                            loopEntry.MonthlyToLookUpID
                        );
                if (!mydu_MarkMonthlyToLookUpAsLookedUpOutput.IsOk)
                {
                    returnOutput.IsOk = false;
                    returnOutput.ErrorMessage =
                        mydu_MarkMonthlyToLookUpAsLookedUpOutput.ErrorMessage;
                    return returnOutput;
                }

                // If we don't have Status='Y', we're done.
                if (
                        myFirefoxOps.MyTennCareListOfInfoForPatient.Count == 0
                        ||
                        myFirefoxOps.MyFirefoxEligInfoForPatient == null
                        ||
                        myFirefoxOps.MyFirefoxEligInfoForPatient.Status.CompareTo("Yes") != 0
                   )
                {
                    continue;
                }

                // Insert MonthlyEntriesYieldingEligInfoToday with the 
                // Eligibility Info from the Firefox Look-Up
                di_InsertMonthlyEligibilityOutput
                    mydi_InsertMonthlyEligibilityOutput =
                        InsertMonthlyEntriesYieldingEligInfoToday
                        (
                            myFirefoxOps.MyFirefoxEligInfoForPatient
                        );
                if (!mydi_InsertMonthlyEligibilityOutput.IsOk)
                {
                    returnOutput.IsOk = false;
                    returnOutput.ErrorMessage =
                        mydi_InsertMonthlyEligibilityOutput.ErrorMessage;
                    return returnOutput;
                }
            }
            myFirefoxOps.LogOutOfBrowser();


            qy_GetMonthlyEligibilityOutput
                myqy_GetMonthlyEligibilityOutput =
                    qy_GetMonthlyEligibility();
            if (!myqy_GetMonthlyEligibilityOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetMonthlyEligibilityOutput
                    .ErrorMessage;
                return returnOutput;
            }

            if (myqy_GetMonthlyEligibilityOutput
                .qy_GetMonthlyEligibilityOutputColumnsList
                .Count > 0)
            {
                CreateOutputFile
                (
                    myqy_GetMonthlyEligibilityOutput
                    .qy_GetMonthlyEligibilityOutputColumnsList
                );

                string outputFilename =
                    myqy_GetMonthlyEligibilityOutput
                    .qy_GetMonthlyEligibilityOutputColumnsList[0]
                    .OutputFileName;

                returnOutput.MailBodyLineList.Add
                (
                    $"Created Output File:  {outputFilename} with {myqy_GetMonthlyEligibilityOutput.qy_GetMonthlyEligibilityOutputColumnsList.Count} Monthly Patient Eligibility Entry(ies)."
                );
            }

            return returnOutput;
        }

        public void CreateOutputFile
            (
                List<qy_GetMonthlyEligibilityOutputColumns>
                    inputqy_GetMonthlyEligibilityOutputColumnsList
            )
        {
            if (inputqy_GetMonthlyEligibilityOutputColumnsList.Count == 0)
            {
                return;
            }
            DateTime myCurrentDateTime = DateTime.Now;
            string MM = myCurrentDateTime.Month.ToString().PadLeft(2, '0');
            string dd = myCurrentDateTime.Day.ToString().PadLeft(2, '0');
            string yyyy = myCurrentDateTime.Year.ToString();

            string outputFullFilename =
                Path.Combine
                (
                    MyConfigOptions.MonthlyOutputArchiveDirectory
                    , $"TennCareMonthlyElligibilityReport_{MM}{dd}{yyyy}.csv"
                );

            string returnOutput = string.Empty;
            List<string> fileStringList = new List<string>();
            fileStringList.Add("AccountNumber, Dob, DOS, FileDate, FileName, MCO, Medicare, PCP, Ssn, Status, TennCareElligibility");
            foreach (qy_GetMonthlyEligibilityOutputColumns loopEntry in inputqy_GetMonthlyEligibilityOutputColumnsList)
            {
                fileStringList.Add($"{loopEntry.PatientID}, {loopEntry.DOB.ToString("MM/dd/yyyy")}, {loopEntry.DOS.ToString("MM/dd/yyyy")}, {loopEntry.OutputFileDate.ToString("MM/dd/yyyy")}, , {loopEntry.MCO},  {loopEntry.Medicare}, {loopEntry.PCP}, {loopEntry.SSN}, {loopEntry.Status}, {loopEntry.TennCareEligibility}");
            }

            if (File.Exists(outputFullFilename))
            {
                File.Delete(outputFullFilename);
            }
            File.WriteAllLines(outputFullFilename, fileStringList);
        }
        public qy_GetMonthlyEligibilityOutput qy_GetMonthlyEligibility()
        {
            qy_GetMonthlyEligibilityOutput returnOutput =
                new qy_GetMonthlyEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetMonthlyEligibility();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        public qy_GetMonthlyToLookUpOutput GetAllMonthlyEntriesLookedUpToday()
        {
            qy_GetMonthlyToLookUpOutput returnOutput =
                new qy_GetMonthlyToLookUpOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetMonthlyToLookUp();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }
        public du_MarkMonthlyToLookUpAsLookedUpOutput MarkMonthlyEntryLookedUpTodayAsLookedUp(int inputMonthlyEntryID)
        {
            du_MarkMonthlyToLookUpAsLookedUpOutput returnOutput =
                new du_MarkMonthlyToLookUpAsLookedUpOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .du_MarkMonthlyToLookUpAsLookedUp(inputMonthlyEntryID);
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        public dd_MonthlyEligibilityOutput TruncateMonthlyEntriesYieldingEligInfoToday()
        {
            dd_MonthlyEligibilityOutput returnOutput =
                new dd_MonthlyEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .dd_MonthlyEligibility();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        public di_InsertMonthlyEligibilityOutput
            InsertMonthlyEntriesYieldingEligInfoToday
            (
                FirefoxEligInfoForPatient inputFirefoxEligInfoForPatient
            )
        {
            inputFirefoxEligInfoForPatient =
                CompleteEligInfo(inputFirefoxEligInfoForPatient);

            di_InsertMonthlyEligibilityOutput
                returnOutput =
                    new di_InsertMonthlyEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_InsertMonthlyEligibility
                (
                    inputFirefoxEligInfoForPatient.PatientID.ToString()
                    , inputFirefoxEligInfoForPatient.DOS.ToString("yyyyMMdd")
                    , (inputFirefoxEligInfoForPatient.PatientName.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.PatientName
                    , inputFirefoxEligInfoForPatient.DOB.ToString("yyyyMMdd")
                    , inputFirefoxEligInfoForPatient.SSN
                    , (inputFirefoxEligInfoForPatient.ImportFileName.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.ImportFileName
                    , inputFirefoxEligInfoForPatient.DateImported.ToString("yyyyMMdd")
                    , (inputFirefoxEligInfoForPatient.MCO.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.MCO
                    , (inputFirefoxEligInfoForPatient.Medicare.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.Medicare
                    , (inputFirefoxEligInfoForPatient.PCP.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.PCP
                    , (inputFirefoxEligInfoForPatient.Status.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.Status
                    , (inputFirefoxEligInfoForPatient.TennCareEligibility.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.TennCareEligibility
                    , inputFirefoxEligInfoForPatient.OutputFileDate.ToString("yyyyMMdd")
                    , (inputFirefoxEligInfoForPatient.OutputFileName.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.OutputFileName
                );

            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;

        }
        public FirefoxEligInfoForPatient CompleteEligInfo(FirefoxEligInfoForPatient inputFirefoxEligInfoForPatient)
        {
            DateTime myOutputFileDate = new DateTime(1900, 1, 1);
            string myOutputFileName = string.Empty;
            FileInfo importFilenameFi =
                new FileInfo(inputFirefoxEligInfoForPatient.ImportFileName);
            Regex regex = new Regex(@"(?<prefix>.+)_(?<yyyy>\d{4})(?<MM>\d{2})(?<dd>\d{2})");
            Match match = regex.Match(importFilenameFi.Name);
            if (match.Success)
            {
                string prefix = match.Groups["prefix"].Value;
                string yyyyString = match.Groups["yyyy"].Value;
                string MMString = match.Groups["MM"].Value;
                string ddString = match.Groups["dd"].Value;

                int yyyy = -1;
                int MM = -1;
                int dd = -1;

                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                DateTime.TryParse($"{MM}/{dd}/{yyyy}", out myOutputFileDate);

                myOutputFileName =
                    Path.Combine
                    (
                        MyConfigOptions.MonthlyOutputArchiveDirectory
                        , $"{prefix}_{yyyyString}{MMString}{ddString}.csv"
                    );

            }

            FirefoxEligInfoForPatient returnOutput =
                new FirefoxEligInfoForPatient
                {
                    ImportFileName = (inputFirefoxEligInfoForPatient.ImportFileName.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.ImportFileName,
                    PatientID = inputFirefoxEligInfoForPatient.PatientID,
                    DOB = inputFirefoxEligInfoForPatient.DOB,
                    SSN = (inputFirefoxEligInfoForPatient.SSN.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.SSN,
                    DOS = inputFirefoxEligInfoForPatient.DOS,
                    DateImported = inputFirefoxEligInfoForPatient.DateImported,
                    MCO = (inputFirefoxEligInfoForPatient.MCO.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.MCO,
                    Medicare = (inputFirefoxEligInfoForPatient.Medicare.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.Medicare,
                    PCP = (inputFirefoxEligInfoForPatient.PCP.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.PCP,
                    Status = (inputFirefoxEligInfoForPatient.Status.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.Status,
                    TennCareEligibility = (inputFirefoxEligInfoForPatient.TennCareEligibility.Length == 0) ? "MT" : inputFirefoxEligInfoForPatient.TennCareEligibility,
                    OutputFileDate = myOutputFileDate,
                    OutputFileName = myOutputFileName
                };
            return returnOutput;
        }
    }

}
