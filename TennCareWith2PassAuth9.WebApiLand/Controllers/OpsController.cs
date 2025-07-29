using System.Data;
using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.WebApiLand.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpsController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OpsController));

        public OpsController(TennCareEligibilityContext inputDsSummitLifeContext)
        {
            MyContext = inputDsSummitLifeContext;

            log.Info($"Start of OpsController Connection String:  {MyContext.MyConnectionString}");

        }
        public TennCareEligibilityContext MyContext { get; set; }

        // GET /api/Ops/dd_CollectionsComparison
        [HttpGet]
        public dd_CollectionsComparisonOutput
                    dd_CollectionsComparison()
        {
            dd_CollectionsComparisonOutput
                returnOutput =
                    new dd_CollectionsComparisonOutput();

            string sql = $"tc.dd_CollectionsComparison";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_CollectionsComparisonOutputColumnsList =
                    MyContext
                    .dd_CollectionsComparisonOutputColumnsList
                    .FromSqlRaw<dd_CollectionsComparisonOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/dd_CollectionsEligibility
        [HttpGet]
        public dd_CollectionsEligibilityOutput
                    dd_CollectionsEligibility()
        {
            dd_CollectionsEligibilityOutput
                returnOutput =
                    new dd_CollectionsEligibilityOutput();

            string sql = $"tc.dd_CollectionsEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_CollectionsEligibilityOutputColumnsList =
                    MyContext
                    .dd_CollectionsEligibilityOutputColumnsList
                    .FromSqlRaw<dd_CollectionsEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/dd_DunningComparison
        [HttpGet]
        public dd_DunningComparisonOutput
                    dd_DunningComparison()
        {
            dd_DunningComparisonOutput
                returnOutput =
                    new dd_DunningComparisonOutput();

            string sql = $"tc.dd_DunningComparison";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_DunningComparisonOutputColumnsList =
                    MyContext
                    .dd_DunningComparisonOutputColumnsList
                    .FromSqlRaw<dd_DunningComparisonOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/dd_DunningEligibility
        [HttpGet]
        public dd_DunningEligibilityOutput
                    dd_DunningEligibility()
        {
            dd_DunningEligibilityOutput
                returnOutput =
                    new dd_DunningEligibilityOutput();

            string sql = $"tc.dd_DunningEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_DunningEligibilityOutputColumnsList =
                    MyContext
                    .dd_DunningEligibilityOutputColumnsList
                    .FromSqlRaw<dd_DunningEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/dd_MonthlyEligibility
        [HttpGet]
        public dd_MonthlyEligibilityOutput
                    dd_MonthlyEligibility()
        {
            dd_MonthlyEligibilityOutput
                returnOutput =
                    new dd_MonthlyEligibilityOutput();

            string sql = $"tc.dd_MonthlyEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_MonthlyEligibilityOutputColumnsList =
                    MyContext
                    .dd_MonthlyEligibilityOutputColumnsList
                    .FromSqlRaw<dd_MonthlyEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }



        // GET /api/Ops/dd_MonthlyToLookUp
        [HttpGet]
        public dd_MonthlyToLookUpOutput
                    dd_MonthlyToLookUp()
        {
            dd_MonthlyToLookUpOutput
                returnOutput =
                    new dd_MonthlyToLookUpOutput();

            string sql = $"tc.dd_MonthlyToLookUp";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.dd_MonthlyToLookUpOutputColumnsList =
                    MyContext
                    .dd_MonthlyToLookUpOutputColumnsList
                    .FromSqlRaw<dd_MonthlyToLookUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_FinalizeCollectionsComparison
        [HttpGet]
        public di_FinalizeCollectionsComparisonOutput
                    di_FinalizeCollectionsComparison()
        {
            di_FinalizeCollectionsComparisonOutput
                returnOutput =
                    new di_FinalizeCollectionsComparisonOutput();

            string sql = $"tc.di_FinalizeCollectionsComparison";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_FinalizeCollectionsComparisonOutputColumnsList =
                    MyContext
                    .di_FinalizeCollectionsComparisonOutputColumnsList
                    .FromSqlRaw<di_FinalizeCollectionsComparisonOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_FinalizeDunningComparison
        [HttpGet]
        public di_FinalizeDunningComparisonOutput
                    di_FinalizeDunningComparison()
        {
            di_FinalizeDunningComparisonOutput
                returnOutput =
                    new di_FinalizeDunningComparisonOutput();

            string sql = $"tc.di_FinalizeDunningComparison";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_FinalizeDunningComparisonOutputColumnsList =
                    MyContext
                    .di_FinalizeDunningComparisonOutputColumnsList
                    .FromSqlRaw<di_FinalizeDunningComparisonOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_FinalizeMonthlyToLookUp
        [HttpGet]
        public di_FinalizeMonthlyToLookUpOutput
                    di_FinalizeMonthlyToLookUp()
        {
            di_FinalizeMonthlyToLookUpOutput
                returnOutput =
                    new di_FinalizeMonthlyToLookUpOutput();

            string sql = $"tc.di_FinalizeMonthlyToLookUp";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_FinalizeMonthlyToLookUpOutputColumnsList =
                    MyContext
                    .di_FinalizeMonthlyToLookUpOutputColumnsList
                    .FromSqlRaw<di_FinalizeMonthlyToLookUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/di_InsertCollectionsEligibility?inputImportFileName=C:\temp\importFile.xlsx&inputPatientIDString=777777&inputDOBInyyyyMMdd=19620913&inputSSN=444444444&inputDOSInyyyyMMdd=20250418&inputDateImportedInyyyyMMdd=20250418&inputMCO=myMCO&inputMedicare=MyMedicare&inputPCP=myPCP&inputStatus=myStatus&inputTennCareEligibility=myTennCareEligibility&inputOutputFileDateInyyyyMMdd=20250418&inputOutputFileName=MyFilename
        [HttpGet]
        public di_InsertCollectionsEligibilityOutput
                    di_InsertCollectionsEligibility
                    (
                        [FromQuery] string inputImportFileName
                        , [FromQuery] string inputPatientIDString
                        , [FromQuery] string inputDOBInyyyyMMdd
                        , [FromQuery] string inputSSN
                        , [FromQuery] string inputDOSInyyyyMMdd
                        , [FromQuery] string inputDateImportedInyyyyMMdd
                        , [FromQuery] string inputMCO
                        , [FromQuery] string inputMedicare
                        , [FromQuery] string inputPCP
                        , [FromQuery] string inputStatus
                        , [FromQuery] string inputTennCareEligibility
                        , [FromQuery] string inputOutputFileDateInyyyyMMdd
                        , [FromQuery] string inputOutputFileName
                    )
        {
            di_InsertCollectionsEligibilityOutput
                returnOutput =
                    new di_InsertCollectionsEligibilityOutput();

            string sql = $"tc.di_InsertCollectionsEligibility   @inputImportFileName, @inputPatientID, @inputDOB, @inputSSN, @inputDOS, @inputDateImported, @inputMCO, @inputMedicare, @inputPCP, @inputStatus, @inputTennCareEligibility, @inputOutputFileDate, @inputOutputFileName";

            List<SqlParameter> parms = new List<SqlParameter>();
            /*@inputImportFileName [varchar](300)
  ,@inputPatientID [int]
  ,@inputDOB [datetime]
  ,@inputSSN [varchar](10)
  ,@inputDOS [datetime]
  ,@inputDateImported [datetime]
  ,@inputMCO [nvarchar](100)
  ,@inputMedicare [nvarchar](100)
  ,@inputPCP [nvarchar](100)
  ,@inputStatus [nvarchar](100)
  ,@inputTennCareEligibility [nvarchar](300)
  ,@inputOutputFileDate [datetime]
  ,@inputOutputFileName [varchar](300)
             */

            // @inputImportFileName [varchar](300)
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputImportFileName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputImportFileName
                };
            parms.Add(parm);

            // @inputPatientID [int]

            int tempInt = 0;
            if (inputPatientIDString.Length > 0)
            {
                Int32.TryParse(inputPatientIDString, out tempInt);
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPatientID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = tempInt
                };
            parms.Add(parm);

            string yyyyString = string.Empty;
            string MMString = string.Empty;
            string ddString = string.Empty;
            int yyyy = 0;
            int MM = 0;
            int dd = 0;
            DateTime tempDateTime = new DateTime(1900, 1, 1);

            // @inputDOB [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOBInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOBInyyyyMMdd.Substring(0, 4);
                MMString = inputDOBInyyyyMMdd.Substring(4, 2);
                ddString = inputDOBInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOB",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputSSN [varchar](10)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputSSN",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 10,
                    Value = inputSSN
                };
            parms.Add(parm);

            // @inputDOS [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOSInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOSInyyyyMMdd.Substring(0, 4);
                MMString = inputDOSInyyyyMMdd.Substring(4, 2);
                ddString = inputDOSInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOS",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputDateImported [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDateImportedInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDateImportedInyyyyMMdd.Substring(0, 4);
                MMString = inputDateImportedInyyyyMMdd.Substring(4, 2);
                ddString = inputDateImportedInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDateImported",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputMCO [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMCO",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMCO
                };
            parms.Add(parm);

            // @inputMedicare [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMedicare",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMedicare
                };
            parms.Add(parm);

            // @inputPCP [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPCP",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputPCP
                };
            parms.Add(parm);

            // @inputStatus [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputStatus",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputStatus
                };
            parms.Add(parm);

            // @inputTennCareEligibility [nvarchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputTennCareEligibility",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputTennCareEligibility
                };
            parms.Add(parm);

            // @inputOutputFileDate [datetime]
            tempDateTime = new DateTime(1900, 1, 1);

            if (inputOutputFileDateInyyyyMMdd.Length == 8)
            {
                yyyyString = inputOutputFileDateInyyyyMMdd.Substring(0, 4);
                MMString = inputOutputFileDateInyyyyMMdd.Substring(4, 2);
                ddString = inputOutputFileDateInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileDate",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputOutputFileName [varchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputOutputFileName
                };
            parms.Add(parm);

            try
            {
                returnOutput.di_InsertCollectionsEligibilityOutputColumnsList =
                    MyContext
                    .di_InsertCollectionsEligibilityOutputColumnsList
                    .FromSqlRaw<di_InsertCollectionsEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_InsertDunningEligibility?inputImportFileName=C:\temp\importFile.xlsx&inputPatientIDString=777777&inputDOBInyyyyMMdd=19620913&inputSSN=444444444&inputDOSInyyyyMMdd=20250418&inputDateImportedInyyyyMMdd=20250418&inputMCO=myMCO&inputMedicare=MyMedicare&inputPCP=myPCP&inputStatus=myStatus&inputTennCareEligibility=myTennCareEligibility&inputOutputFileDateInyyyyMMdd=20250418&inputOutputFileName=MyFilename
        [HttpGet]
        public di_InsertDunningEligibilityOutput
                    di_InsertDunningEligibility
                    (
                        [FromQuery] string inputImportFileName
                        , [FromQuery] string inputPatientIDString
                        , [FromQuery] string inputDOBInyyyyMMdd
                        , [FromQuery] string inputSSN
                        , [FromQuery] string inputDOSInyyyyMMdd
                        , [FromQuery] string inputDateImportedInyyyyMMdd
                        , [FromQuery] string inputMCO
                        , [FromQuery] string inputMedicare
                        , [FromQuery] string inputPCP
                        , [FromQuery] string inputStatus
                        , [FromQuery] string inputTennCareEligibility
                        , [FromQuery] string inputOutputFileDateInyyyyMMdd
                        , [FromQuery] string inputOutputFileName
                    )
        {
            di_InsertDunningEligibilityOutput
                returnOutput =
                    new di_InsertDunningEligibilityOutput();

            string sql = $"tc.di_InsertDunningEligibility   @inputImportFileName, @inputPatientID, @inputDOB, @inputSSN, @inputDOS, @inputDateImported, @inputMCO, @inputMedicare, @inputPCP, @inputStatus, @inputTennCareEligibility, @inputOutputFileDate, @inputOutputFileName";

            List<SqlParameter> parms = new List<SqlParameter>();
            /*@inputImportFileName [varchar](300)
  ,@inputPatientID [int]
  ,@inputDOB [datetime]
  ,@inputSSN [varchar](10)
  ,@inputDOS [datetime]
  ,@inputDateImported [datetime]
  ,@inputMCO [nvarchar](100)
  ,@inputMedicare [nvarchar](100)
  ,@inputPCP [nvarchar](100)
  ,@inputStatus [nvarchar](100)
  ,@inputTennCareEligibility [nvarchar](300)
  ,@inputOutputFileDate [datetime]
  ,@inputOutputFileName [varchar](300)
             */

            // @inputImportFileName [varchar](300)
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputImportFileName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputImportFileName
                };
            parms.Add(parm);

            // @inputPatientID [int]

            int tempInt = 0;
            if (inputPatientIDString.Length > 0)
            {
                Int32.TryParse(inputPatientIDString, out tempInt);
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPatientID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = tempInt
                };
            parms.Add(parm);

            string yyyyString = string.Empty;
            string MMString = string.Empty;
            string ddString = string.Empty;
            int yyyy = 0;
            int MM = 0;
            int dd = 0;
            DateTime tempDateTime = new DateTime(1900, 1, 1);

            // @inputDOB [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOBInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOBInyyyyMMdd.Substring(0, 4);
                MMString = inputDOBInyyyyMMdd.Substring(4, 2);
                ddString = inputDOBInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOB",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputSSN [varchar](10)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputSSN",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 10,
                    Value = inputSSN
                };
            parms.Add(parm);

            // @inputDOS [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOSInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOSInyyyyMMdd.Substring(0, 4);
                MMString = inputDOSInyyyyMMdd.Substring(4, 2);
                ddString = inputDOSInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOS",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputDateImported [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDateImportedInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDateImportedInyyyyMMdd.Substring(0, 4);
                MMString = inputDateImportedInyyyyMMdd.Substring(4, 2);
                ddString = inputDateImportedInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDateImported",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputMCO [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMCO",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMCO
                };
            parms.Add(parm);

            // @inputMedicare [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMedicare",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMedicare
                };
            parms.Add(parm);

            // @inputPCP [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPCP",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputPCP
                };
            parms.Add(parm);

            // @inputStatus [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputStatus",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputStatus
                };
            parms.Add(parm);

            // @inputTennCareEligibility [nvarchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputTennCareEligibility",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputTennCareEligibility
                };
            parms.Add(parm);

            // @inputOutputFileDate [datetime]
            tempDateTime = new DateTime(1900, 1, 1);

            if (inputOutputFileDateInyyyyMMdd.Length == 8)
            {
                yyyyString = inputOutputFileDateInyyyyMMdd.Substring(0, 4);
                MMString = inputOutputFileDateInyyyyMMdd.Substring(4, 2);
                ddString = inputOutputFileDateInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileDate",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputOutputFileName [varchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputOutputFileName
                };
            parms.Add(parm);

            try
            {
                returnOutput.di_InsertDunningEligibilityOutputColumnsList =
                    MyContext
                    .di_InsertDunningEligibilityOutputColumnsList
                    .FromSqlRaw<di_InsertDunningEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_InsertMonthlyEligibility?inputPatientIDString=234254&inputDOSInyyyyMMdd=20250430&inputPatientName=MIckey&inputDOBInyyyyMMdd=19620913&inputSSN=444444444&inputImportFullFileName=C:\temp\importFile.xlsx&inputDateImportedInyyyyMMdd=20250430&inputMCO=MCO&inputMedicare=Medicare&inputPCP=PCP&inputStatus=Status&inputTennCareEligibility=Elig&inputOutputFileDateInyyyyMMdd=20250430&inputOutputFileName=Output.txt
        [HttpGet]
        public di_InsertMonthlyEligibilityOutput
                    di_InsertMonthlyEligibility
                    (
                         [FromQuery] string inputPatientIDString
                        , [FromQuery] string inputDOSInyyyyMMdd
                        , [FromQuery] string inputPatientName
                        , [FromQuery] string inputDOBInyyyyMMdd
                        , [FromQuery] string inputSSN
                        , [FromQuery] string inputImportFullFileName
                        , [FromQuery] string inputDateImportedInyyyyMMdd
                        , [FromQuery] string inputMCO
                        , [FromQuery] string inputMedicare
                        , [FromQuery] string inputPCP
                        , [FromQuery] string inputStatus
                        , [FromQuery] string inputTennCareEligibility
                        , [FromQuery] string inputOutputFileDateInyyyyMMdd
                        , [FromQuery] string inputOutputFileName
                    )
        {
            di_InsertMonthlyEligibilityOutput
                returnOutput =
                    new di_InsertMonthlyEligibilityOutput();

            string sql = $"tc.di_InsertMonthlyEligibility   " +
                $"@inputPatientID" +
                $", @inputDOS" +
                $", @inputPatientName" +
                $", @inputDOB" +
                $", @inputSSN" +
                $", @inputImportFullFileName" +
                $", @inputDateImported" +
                $", @inputMCO" +
                $", @inputMedicare" +
                $", @inputPCP" +
                $", @inputStatus" +
                $", @inputTennCareEligibility" +
                $", @inputOutputFileDate" +
                $", @inputOutputFileName";

            List<SqlParameter> parms = new List<SqlParameter>();
            /* @inputPatientID [int]
	,@inputDOS [datetime]
    ,@inputPatientName [varchar](300)
	,@inputDOB [datetime]
	,@inputSSN [varchar](10)
	,@inputImportFullFilename [varchar] (1000)
    ,@inputDateImported [datetime]
	,@inputMCO [nvarchar] (100)
	,@inputMedicare [nvarchar] (100)
	,@inputPCP [nvarchar] (100)
	,@inputStatus [nvarchar] (100)
    ,@inputTennCareEligibility [nvarchar] (300)
	,@inputOutputFileDate  [datetime]
	,@inputOutputFileName [varchar](300)
             */

            // @inputPatientID [int]

            int tempInt = 0;
            if (inputPatientIDString.Length > 0)
            {
                Int32.TryParse(inputPatientIDString, out tempInt);
            }
            SqlParameter
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPatientID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = tempInt
                };
            parms.Add(parm);

            string yyyyString = string.Empty;
            string MMString = string.Empty;
            string ddString = string.Empty;
            int yyyy = 0;
            int MM = 0;
            int dd = 0;
            DateTime tempDateTime = new DateTime(1900, 1, 1);

            // @inputDOS [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOSInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOSInyyyyMMdd.Substring(0, 4);
                MMString = inputDOSInyyyyMMdd.Substring(4, 2);
                ddString = inputDOSInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOS",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputPatientName [varchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPatientName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputPatientName
                };
            parms.Add(parm);

            // @inputDOB [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDOBInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDOBInyyyyMMdd.Substring(0, 4);
                MMString = inputDOBInyyyyMMdd.Substring(4, 2);
                ddString = inputDOBInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDOB",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputSSN [varchar](10)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputSSN",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 10,
                    Value = inputSSN
                };
            parms.Add(parm);

            // @inputImportFullFilename [varchar] (1000)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputImportFullFilename",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 1000,
                    Value = inputImportFullFileName
                };
            parms.Add(parm);

            // @inputDateImported [datetime]
            tempDateTime = new DateTime(1900, 1, 1);
            if (inputDateImportedInyyyyMMdd.Length == 8)
            {
                yyyyString = inputDateImportedInyyyyMMdd.Substring(0, 4);
                MMString = inputDateImportedInyyyyMMdd.Substring(4, 2);
                ddString = inputDateImportedInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputDateImported",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputMCO [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMCO",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMCO
                };
            parms.Add(parm);

            // @inputMedicare [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputMedicare",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputMedicare
                };
            parms.Add(parm);

            // @inputPCP [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputPCP",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputPCP
                };
            parms.Add(parm);

            // @inputStatus [nvarchar](100)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputStatus",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Value = inputStatus
                };
            parms.Add(parm);

            // @inputTennCareEligibility [nvarchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputTennCareEligibility",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputTennCareEligibility
                };
            parms.Add(parm);

            // @inputOutputFileDate [datetime]
            tempDateTime = new DateTime(1900, 1, 1);

            if (inputOutputFileDateInyyyyMMdd.Length == 8)
            {
                yyyyString = inputOutputFileDateInyyyyMMdd.Substring(0, 4);
                MMString = inputOutputFileDateInyyyyMMdd.Substring(4, 2);
                ddString = inputOutputFileDateInyyyyMMdd.Substring(6, 2);
                yyyy = 0;
                MM = 0;
                dd = 0;
                Int32.TryParse(yyyyString, out yyyy);
                Int32.TryParse(MMString, out MM);
                Int32.TryParse(ddString, out dd);

                if (yyyy != 0 && MM != 0 && dd != 0)
                {
                    DateTime.TryParse($"{MM}/{dd}/{yyyy}", out tempDateTime);
                }
            }
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileDate",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Size = 1,
                    Value = tempDateTime
                };
            parms.Add(parm);

            // @inputOutputFileName [varchar](300)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputOutputFileName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 300,
                    Value = inputOutputFileName
                };
            parms.Add(parm);

            try
            {
                returnOutput.di_InsertMonthlyEligibilityOutputColumnsList =
                    MyContext
                    .di_InsertMonthlyEligibilityOutputColumnsList
                    .FromSqlRaw<di_InsertMonthlyEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/du_MarkCollectionsToLookUpAsLookedUp?inputCollectionsEntriesLookedUpTodayID=1
        [HttpGet]
        public du_MarkCollectionsToLookUpAsLookedUpOutput
                    du_MarkCollectionsToLookUpAsLookedUp
                    (
                        [FromQuery] int inputCollectionsEntriesLookedUpTodayID
                    )
        {
            du_MarkCollectionsToLookUpAsLookedUpOutput
                returnOutput =
                    new du_MarkCollectionsToLookUpAsLookedUpOutput();

            string sql = $"tc.du_MarkCollectionsToLookUpAsLookedUp @inputCollectionsEntriesLookedUpTodayID";

            List<SqlParameter> parms = new List<SqlParameter>();

            // @inputApplicationName
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputCollectionsEntriesLookedUpTodayID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = inputCollectionsEntriesLookedUpTodayID
                };
            parms.Add(parm);

            try
            {
                returnOutput.du_MarkCollectionsToLookUpAsLookedUpOutputColumnsList =
                    MyContext
                    .du_MarkCollectionsToLookUpAsLookedUpOutputColumnsList
                    .FromSqlRaw<du_MarkCollectionsToLookUpAsLookedUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/du_MarkDunningToLookUpAsLookedUp?inputDunningEntriesLookedUpTodayID=1
        [HttpGet]
        public du_MarkDunningToLookUpAsLookedUpOutput
                    du_MarkDunningToLookUpAsLookedUp
                    (
                        [FromQuery] int inputDunningEntriesLookedUpTodayID
                    )
        {
            du_MarkDunningToLookUpAsLookedUpOutput
                returnOutput =
                    new du_MarkDunningToLookUpAsLookedUpOutput();

            string sql = $"tc.du_MarkDunningToLookUpAsLookedUp @inputDunningEntriesLookedUpTodayID";

            List<SqlParameter> parms = new List<SqlParameter>();

            // @inputApplicationName
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputDunningEntriesLookedUpTodayID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = inputDunningEntriesLookedUpTodayID
                };
            parms.Add(parm);

            try
            {
                returnOutput.du_MarkDunningToLookUpAsLookedUpOutputColumnsList =
                    MyContext
                    .du_MarkDunningToLookUpAsLookedUpOutputColumnsList
                    .FromSqlRaw<du_MarkDunningToLookUpAsLookedUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/du_MarkMonthlyToLookUpAsLookedUp?inputMonthlyEntriesLookedUpTodayID=1
        [HttpGet]
        public du_MarkMonthlyToLookUpAsLookedUpOutput
                    du_MarkMonthlyToLookUpAsLookedUp
                    (
                        [FromQuery] int inputMonthlyEntriesLookedUpTodayID
                    )
        {
            du_MarkMonthlyToLookUpAsLookedUpOutput
                returnOutput =
                    new du_MarkMonthlyToLookUpAsLookedUpOutput();

            string sql = $"tc.du_MarkMonthlyToLookUpAsLookedUp @inputMonthlyEntriesLookedUpTodayID";

            List<SqlParameter> parms = new List<SqlParameter>();

            // @inputApplicationName
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputMonthlyEntriesLookedUpTodayID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 1,
                    Value = inputMonthlyEntriesLookedUpTodayID
                };
            parms.Add(parm);

            try
            {
                returnOutput.du_MarkMonthlyToLookUpAsLookedUpOutputColumnsList =
                    MyContext
                    .du_MarkMonthlyToLookUpAsLookedUpOutputColumnsList
                    .FromSqlRaw<du_MarkMonthlyToLookUpAsLookedUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/qy_GetCollectionsEligibility
        [HttpGet]
        public qy_GetCollectionsEligibilityOutput
                    qy_GetCollectionsEligibility()
        {
            qy_GetCollectionsEligibilityOutput
                returnOutput =
                    new qy_GetCollectionsEligibilityOutput();

            string sql = $"tc.qy_GetCollectionsEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetCollectionsEligibilityOutputColumnsList =
                    MyContext
                    .qy_GetCollectionsEligibilityOutputColumnsList
                    .FromSqlRaw<qy_GetCollectionsEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetCollectionsToLookUp
        [HttpGet]
        public qy_GetCollectionsToLookUpOutput
                    qy_GetCollectionsToLookUp()
        {
            qy_GetCollectionsToLookUpOutput
                returnOutput =
                    new qy_GetCollectionsToLookUpOutput();

            string sql = $"tc.qy_GetCollectionsToLookUp";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetCollectionsToLookUpOutputColumnsList =
                    MyContext
                    .qy_GetCollectionsToLookUpOutputColumnsList
                    .FromSqlRaw<qy_GetCollectionsToLookUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDunningEligibility
        [HttpGet]
        public qy_GetDunningEligibilityOutput
                    qy_GetDunningEligibility()
        {
            qy_GetDunningEligibilityOutput
                returnOutput =
                    new qy_GetDunningEligibilityOutput();

            string sql = $"tc.qy_GetDunningEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDunningEligibilityOutputColumnsList =
                    MyContext
                    .qy_GetDunningEligibilityOutputColumnsList
                    .FromSqlRaw<qy_GetDunningEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }








        // GET /api/Ops/qy_GetDunningToLookUp
        [HttpGet]
        public qy_GetDunningToLookUpOutput
                    qy_GetDunningToLookUp()
        {
            qy_GetDunningToLookUpOutput
                returnOutput =
                    new qy_GetDunningToLookUpOutput();

            string sql = $"tc.qy_GetDunningToLookUp";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDunningToLookUpOutputColumnsList =
                    MyContext
                    .qy_GetDunningToLookUpOutputColumnsList
                    .FromSqlRaw<qy_GetDunningToLookUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetMonthlyEligibility
        [HttpGet]
        public qy_GetMonthlyEligibilityOutput
                    qy_GetMonthlyEligibility()
        {
            qy_GetMonthlyEligibilityOutput
                returnOutput =
                    new qy_GetMonthlyEligibilityOutput();

            string sql = $"tc.qy_GetMonthlyEligibility";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetMonthlyEligibilityOutputColumnsList =
                    MyContext
                    .qy_GetMonthlyEligibilityOutputColumnsList
                    .FromSqlRaw<qy_GetMonthlyEligibilityOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetMonthlyToLookUp
        [HttpGet]
        public qy_GetMonthlyToLookUpOutput
                    qy_GetMonthlyToLookUp()
        {
            qy_GetMonthlyToLookUpOutput
                returnOutput =
                    new qy_GetMonthlyToLookUpOutput();

            string sql = $"tc.qy_GetMonthlyToLookUp";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetMonthlyToLookUpOutputColumnsList =
                    MyContext
                    .qy_GetMonthlyToLookUpOutputColumnsList
                    .FromSqlRaw<qy_GetMonthlyToLookUpOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }














        // GET /api/Ops/qy_GetTennCareWith2PassAuthConfig?inputApplicationName=TennCareEligibility&inputType=Default&inputProcessName=Import&inputNameFilter=NULL&inputUser=AppUser
        [HttpGet]
        public qy_GetTennCareWith2PassAuthConfigOutput
                    qy_GetTennCareWith2PassAuthConfig
                    (
                        [FromQuery] string inputApplicationName
                        , [FromQuery] string inputType
                        , [FromQuery] string inputProcessName
                        , [FromQuery] string inputNameFilter
                        , [FromQuery] string inputUser
                    )
        {
            qy_GetTennCareWith2PassAuthConfigOutput 
                returnOutput =
                    new qy_GetTennCareWith2PassAuthConfigOutput();

            string sql = $"tc.qy_GetTennCareWith2PassAuthConfig @inputApplicationName, @inputType, @inputProcessName, @inputNameFilter, @inputUser";

            List<SqlParameter> parms = new List<SqlParameter>();

            // @inputApplicationName
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputApplicationName",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 128,
                    Value = inputApplicationName
                };
            parms.Add( parm );

            // @inputType
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputType",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = inputType
                };
            parms.Add( parm );

            // @inputProcessName
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputProcessName",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 128,
                    Value = inputProcessName
                };
            parms.Add( parm );

            // @inputNameFilter
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputNameFilter",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 128,
                    Value = inputNameFilter
                };
            parms.Add( parm );

            // @inputUser [varchar] (50)
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputUser",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = inputUser
                };
            parms.Add( parm );

            try
            {
                returnOutput.qy_GetTennCareWith2PassAuthConfigOutputColumnsList =
                    MyContext
                    .qy_GetTennCareWith2PassAuthConfigOutputColumnsList
                    .FromSqlRaw<qy_GetTennCareWith2PassAuthConfigOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }
    }
}