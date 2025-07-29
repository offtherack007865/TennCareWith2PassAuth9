using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.ImportConsoleApp
{
    public class GetTodaysCollectionsDunningAndMonthlyFilesClass
    {
        public GetTodaysCollectionsDunningAndMonthlyFilesClass(qy_GetTennCareWith2PassAuthConfigOutputColumns inputqy_GetTennCareWith2PassAuthConfigOutputColumns)
        { 
            MyConfigOptions = inputqy_GetTennCareWith2PassAuthConfigOutputColumns;
        }
        public qy_GetTennCareWith2PassAuthConfigOutputColumns 
                    MyConfigOptions 
                        { get; set; }    
        public List<string>
                    MyCollectionsSourceFileList
                        { get; set; }    
        public List<string> 
                    MyDunningSourceFileList
                        { get; set; }
        public List<string>
                    MyMonthlySourceFileList
                        { get; set; }   

        // DoIt()
        public 
            TodaysCollectionsDunningAndMonthlyFiles 
                DoIt()
        {
            TodaysCollectionsDunningAndMonthlyFiles
                returnOutput =
                    new TodaysCollectionsDunningAndMonthlyFiles();

            returnOutput.TodaysCollectionsFullFilename =
                GetLatestCollectionsFileNotInArchive();
            
            returnOutput.TodaysDunningFullFilename =
                GetLatestDunningFileNotInArchive();
            returnOutput.TodaysMonthlyFullFilenameList =
                GetMonthlyFilesNotInArchive();

            return returnOutput;
        }
        public string GetLatestCollectionsFileNotInArchive()
        {
            string returnOutput = string.Empty;
            MyCollectionsSourceFileList = 
                Directory.GetFiles($"{MyConfigOptions.CollectionsReadDirectory}", $"*{MyConfigOptions.CollectionsFilenameContainsString}*.xlsx", SearchOption.TopDirectoryOnly).ToList();

            foreach (string loopFullFilename in this.MyCollectionsSourceFileList)
            {
                FileInfo 
                    loopFi =
                        new FileInfo(loopFullFilename);
                DateTime currentDateTime = DateTime.Now;
                string MM = currentDateTime.Month.ToString().PadLeft(2, '0');
                string dd = currentDateTime.Day.ToString().PadLeft(2, '0');
                string yyyy = currentDateTime.Year.ToString();

                string candidateArchivedFullFilenameSansExtension =
                    string.Empty;
                if (loopFi.Name.EndsWith(".xlsx"))
                {
                    string currentYearArchiveFolder =
                        Path.Combine(MyConfigOptions.CollectionsInputArchiveDirectory, yyyy);

                    candidateArchivedFullFilenameSansExtension =
                        Path.Combine
                        (
                            currentYearArchiveFolder
                            , $"{loopFi.Name.Substring(0,loopFi.Name.Length - 5)}_{yyyy}{MM}{dd}{loopFi.Extension}"
                        );

                    if (File.Exists(candidateArchivedFullFilenameSansExtension))
                    {
                        File.Delete(loopFi.FullName);
                    }
                }
            }
            MyCollectionsSourceFileList = 
                    Directory.GetFiles($"{MyConfigOptions.CollectionsReadDirectory}", $"*{MyConfigOptions.CollectionsFilenameContainsString}*.xlsx", SearchOption.TopDirectoryOnly).ToList();
            if (MyCollectionsSourceFileList.Count == 0)
            {
                return returnOutput;
            }
            returnOutput =
                MyCollectionsSourceFileList
                .OrderByDescending
                (
                    s => new FileInfo(s).LastWriteTime
                )
                .FirstOrDefault();   
            return returnOutput;
        }
        public string GetLatestDunningFileNotInArchive()
        {
            string returnOutput = string.Empty;
            MyDunningSourceFileList =
                Directory.GetFiles($"{MyConfigOptions.DunningReadDirectory}", $"*{MyConfigOptions.DunningFilenameContainsString}*.xlsx", SearchOption.TopDirectoryOnly).ToList();

            foreach (string loopFullFilename in this.MyDunningSourceFileList)
            {
                FileInfo
                    loopFi =
                        new FileInfo(loopFullFilename);
                DateTime currentDateTime = DateTime.Now;
                string MM = currentDateTime.Month.ToString().PadLeft(2, '0');
                string dd = currentDateTime.Day.ToString().PadLeft(2, '0');
                string yyyy = currentDateTime.Year.ToString();
                string candidateArchivedFullFilenameSansExtension =
                    string.Empty;
                if (loopFi.Name.EndsWith(".xlsx"))
                {
                    string currentYearArchiveFolder =
                        Path.Combine(MyConfigOptions.DunningInputArchiveDirectory, yyyy);

                    candidateArchivedFullFilenameSansExtension =
                        Path.Combine
                        (
                            currentYearArchiveFolder
                            , $"{loopFi.Name.Substring(0, loopFi.Name.Length - 5)}_{yyyy}{MM}{dd}{loopFi.Extension}"
                        );

                    if (File.Exists(candidateArchivedFullFilenameSansExtension))
                    {
                        File.Delete(loopFi.FullName);
                    }
                }
            }
            MyDunningSourceFileList =
                    Directory.GetFiles($"{MyConfigOptions.DunningReadDirectory}", $"*{MyConfigOptions.DunningFilenameContainsString}*.xlsx", SearchOption.TopDirectoryOnly).ToList();
            if (MyDunningSourceFileList.Count == 0)
            {
                return returnOutput;
            }
            returnOutput =
                MyDunningSourceFileList
                .OrderByDescending
                (
                    s => new FileInfo(s).LastWriteTime
                )
                .FirstOrDefault();
            return returnOutput;
        }
        public List<string> GetMonthlyFilesNotInArchive()
        {
            List<string> returnOutput = new List<string>();

            MyMonthlySourceFileList =
                Directory.GetFiles($"{MyConfigOptions.MonthlyReadDirectory}", $"*.xlsx", SearchOption.TopDirectoryOnly).ToList();

            foreach (string loopFullFilename in this.MyMonthlySourceFileList)
            {
                FileInfo
                    loopFi =
                        new FileInfo(loopFullFilename);
                DateTime currentDateTime = DateTime.Now;
                string MM = currentDateTime.Month.ToString().PadLeft(2, '0');
                string dd = currentDateTime.Day.ToString().PadLeft(2, '0');
                string yyyy = currentDateTime.Year.ToString();
                string candidateArchivedFullFilenameSansExtension =
                    string.Empty;
                if (loopFi.Name.EndsWith(".xlsx"))
                {
                    string currentYearArchiveFolder =
                        Path.Combine(MyConfigOptions.MonthlyInputArchiveDirectory, yyyy);
                    string currentBatchFolder =
                        Path.Combine(currentYearArchiveFolder,$"Batch_{yyyy}{MM}{dd}");

                    candidateArchivedFullFilenameSansExtension =
                        Path.Combine
                        (
                            currentBatchFolder
                            , $"{loopFi.Name.Substring(0, loopFi.Name.Length - 5)}_{yyyy}{MM}{dd}{loopFi.Extension}"
                        );

                    if (File.Exists(candidateArchivedFullFilenameSansExtension))
                    {
                        File.Delete(loopFi.FullName);
                    }
                }
            }
            MyMonthlySourceFileList =
                    Directory.GetFiles($"{MyConfigOptions.MonthlyReadDirectory}", $"*.xlsx", SearchOption.TopDirectoryOnly).ToList();
            returnOutput = MyMonthlySourceFileList;
            return returnOutput;
        }
    }
}