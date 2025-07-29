using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TennCareWith2PassAuth9.CallWebApiLand;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.DunningLookUpConsoleApp
{
    public class MainOps
    {
        public MainOps
                (
                    ConfigOptions inputFileConfigOptions
                    ,qy_GetTennCareWith2PassAuthConfigOutputColumns inputqy_GetTennCareWith2PassAuthConfigOutputColumns
                )
        {
            MyFileConfigOptions = inputFileConfigOptions;
            MyConfigOptions =
                inputqy_GetTennCareWith2PassAuthConfigOutputColumns;
        }

        // MyConfigOptions
        public
            qy_GetTennCareWith2PassAuthConfigOutputColumns
                MyConfigOptions
        { get; set; }

        // MyFileConfigOptions
        public
            ConfigOptions
                MyFileConfigOptions
        { get; set; }

        public MainOpsOutput MyMain()
        {
            MainOpsOutput returnOutput =
                new MainOpsOutput();

            // Get all Dunning needing to be looked up.
            qy_GetDunningToLookUpOutput
                myqy_GetDunningToLookUpOutput =
                    GetDunningToLookUp();
            if (!myqy_GetDunningToLookUpOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDunningToLookUpOutput.ErrorMessage;
                return returnOutput;
            }
            if (
                    myqy_GetDunningToLookUpOutput
                    .qy_GetDunningToLookUpOutputColumnsList
                    .Count == 0
                )
            {
                Console.WriteLine("There are no Dunning entries today.  Program is Ending.");
                return returnOutput;
            }

            // Given there are entries to look up, Truncate the Eligibility Info Output table.
            dd_DunningEligibilityOutput
                mydd_DunningEligibilityOutput =
                    TruncateDunningEligibility();
            if (!mydd_DunningEligibilityOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydd_DunningEligibilityOutput.ErrorMessage;
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

            for (int entryCtr = 0; entryCtr < myqy_GetDunningToLookUpOutput.qy_GetDunningToLookUpOutputColumnsList.Count; entryCtr++)
            {
                qy_GetDunningToLookUpOutputColumns
                    loopEntry =
                        myqy_GetDunningToLookUpOutput
                        .qy_GetDunningToLookUpOutputColumnsList[entryCtr];
                int oneBasedEntryCtr = entryCtr + 1;
                Console.WriteLine($"Dunning Patient Appt {oneBasedEntryCtr} of {myqy_GetDunningToLookUpOutput.qy_GetDunningToLookUpOutputColumnsList.Count} being looked up.");
                if (loopEntry.PatientID == 1189234)
                {
                    int i = 0;
                    i++;
                }
                FirefoxPatientInfoToLookUp
                    myEntryToLookUp =
                        new FirefoxPatientInfoToLookUp
                        {
                            FileName = loopEntry.FileName,
                            PatientID = loopEntry.PatientID,
                            DOB = loopEntry.DOB,
                            DOS = loopEntry.DOS,
                            SSN = loopEntry.SSN,
                            DateImported = loopEntry.DateImported
                        };
                myFirefoxOps.MyFirefoxPatientInfoToLookUp =
                    myEntryToLookUp;
                myFirefoxOps.LookUpTennCareEligibility();

                // Update the look-up entry as Looked Up.
                du_MarkDunningToLookUpAsLookedUpOutput
                    mydu_MarkDunningToLookUpAsLookedUpOutput =
                        MarkDunningEntryLookedUpTodayAsLookedUp
                        (
                            loopEntry.DunningToLookUpID
                        );
                if (!mydu_MarkDunningToLookUpAsLookedUpOutput.IsOk)
                {
                    returnOutput.IsOk = false;
                    returnOutput.ErrorMessage =
                        mydu_MarkDunningToLookUpAsLookedUpOutput.ErrorMessage;
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

                // Insert DunningEntriesYieldingEligInfoToday with the 
                // Eligibility Info from the Firefox Look-Up
                di_InsertDunningEligibilityOutput
                    mydi_InsertDunningEligibilityOutput =
                        InsertDunningEntriesYieldingEligInfoToday
                        (
                            myFirefoxOps.MyFirefoxEligInfoForPatient
                        );
                if (!mydi_InsertDunningEligibilityOutput.IsOk)
                {
                    returnOutput.IsOk = false;
                    returnOutput.ErrorMessage =
                        mydi_InsertDunningEligibilityOutput.ErrorMessage;
                    return returnOutput;
                }
            }
            myFirefoxOps.LogOutOfBrowser();


            qy_GetDunningEligibilityOutput
                myqy_GetDunningEligibilityOutput =
                    qy_GetDunningEligibility();
            if (!myqy_GetDunningEligibilityOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDunningEligibilityOutput
                    .ErrorMessage;
                return returnOutput;
            }

            if (myqy_GetDunningEligibilityOutput
                .qy_GetDunningEligibilityOutputColumnsList
                .Count > 0)
            {
                CreateOutputFile
                (
                    myqy_GetDunningEligibilityOutput
                    .qy_GetDunningEligibilityOutputColumnsList
                );

                string outputFilename =
                    myqy_GetDunningEligibilityOutput
                    .qy_GetDunningEligibilityOutputColumnsList[0]
                    .OutputFileName;

                returnOutput.MailBodyLineList.Add
                (
                    $"Created Output File:  {outputFilename} with {myqy_GetDunningEligibilityOutput.qy_GetDunningEligibilityOutputColumnsList.Count} Dunning Patient Eligibility Entry(ies)."
                );
            }

            return returnOutput;
        }

        public void CreateOutputFile
            (
                List<qy_GetDunningEligibilityOutputColumns>
                    inputqy_GetDunningEntriesYieldingEligInfoTodayOutputColumnsList
            )
        {
            if (inputqy_GetDunningEntriesYieldingEligInfoTodayOutputColumnsList.Count == 0)
            {
                return;
            }
            string outputFullFilename =
                inputqy_GetDunningEntriesYieldingEligInfoTodayOutputColumnsList[0].OutputFileName;

            string returnOutput = string.Empty;
            List<string> fileStringList = new List<string>();
            fileStringList.Add("AccountNumber, Dob, DOS, FileDate, FileName, MCO, Medicare, PCP, Ssn, Status, TennCareElligibility");
            foreach (qy_GetDunningEligibilityOutputColumns loopEntry in inputqy_GetDunningEntriesYieldingEligInfoTodayOutputColumnsList)
            {
                fileStringList.Add($"{loopEntry.PatientID}, {loopEntry.DOB.ToString("MM/dd/yyyy")}, {loopEntry.DOS.ToString("MM/dd/yyyy")}, {loopEntry.OutputFileDate.ToString("MM/dd/yyyy")}, TennCareCollections, {loopEntry.MCO},  {loopEntry.Medicare}, {loopEntry.PCP}, {loopEntry.SSN}, {loopEntry.Status}, {loopEntry.TennCareEligibility}");
            }

            if (File.Exists(outputFullFilename))
            {
                File.Delete(outputFullFilename);
            }
            File.WriteAllLines(outputFullFilename, fileStringList);
        }
        public qy_GetDunningEligibilityOutput qy_GetDunningEligibility()
        {
            qy_GetDunningEligibilityOutput returnOutput =
                new qy_GetDunningEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDunningEligibility();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        public qy_GetDunningToLookUpOutput GetDunningToLookUp()
        {
            qy_GetDunningToLookUpOutput returnOutput =
                new qy_GetDunningToLookUpOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDunningToLookUp();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }
        public du_MarkDunningToLookUpAsLookedUpOutput MarkDunningEntryLookedUpTodayAsLookedUp(int inputDunningEntryID)
        {
            du_MarkDunningToLookUpAsLookedUpOutput returnOutput =
                new du_MarkDunningToLookUpAsLookedUpOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .du_MarkDunningToLookUpAsLookedUp(inputDunningEntryID);
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        public dd_DunningEligibilityOutput TruncateDunningEligibility()
        {
            dd_DunningEligibilityOutput returnOutput =
                new dd_DunningEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .dd_DunningEligibility();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        public di_InsertDunningEligibilityOutput
            InsertDunningEntriesYieldingEligInfoToday
            (
                FirefoxEligInfoForPatient inputFirefoxEligInfoForPatient
            )
        {
            inputFirefoxEligInfoForPatient =
                CompleteEligInfo(inputFirefoxEligInfoForPatient);

            di_InsertDunningEligibilityOutput
                returnOutput =
                    new di_InsertDunningEligibilityOutput();
            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyConfigOptions.BaseWebApiUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_InsertDunningEligibility
                (
                    inputFirefoxEligInfoForPatient.ImportFileName
                    , inputFirefoxEligInfoForPatient.PatientID.ToString()
                    , inputFirefoxEligInfoForPatient.DOB.ToString("yyyyMMdd")
                    , inputFirefoxEligInfoForPatient.SSN
                    , inputFirefoxEligInfoForPatient.DOS.ToString("yyyyMMdd")
                    , inputFirefoxEligInfoForPatient.DateImported.ToString("yyyyMMdd")
                    , inputFirefoxEligInfoForPatient.MCO
                    , inputFirefoxEligInfoForPatient.Medicare
                    , (inputFirefoxEligInfoForPatient.PCP.CompareTo("MT") == 0) ? "" : inputFirefoxEligInfoForPatient.PCP
                    , inputFirefoxEligInfoForPatient.Status
                    , inputFirefoxEligInfoForPatient.TennCareEligibility
                    , inputFirefoxEligInfoForPatient.OutputFileDate.ToString("yyyyMMdd")
                    , inputFirefoxEligInfoForPatient.OutputFileName
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
                        MyConfigOptions.DunningOutputArchiveDirectory
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
