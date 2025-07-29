using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class qy_GetTennCareWith2PassAuthConfigOutputColumns
    {
		public string CollectionsReadDirectory {  get; set; }
        public string DunningReadDirectory { get; set; }
        public string MonthlyReadDirectory { get; set; }
        public string CollectionsInputArchiveDirectory {  get; set; }
		public string DunningInputArchiveDirectory {  get; set; }
        public string MonthlyInputArchiveDirectory { get; set; }
        public string CollectionsOutputArchiveDirectory {  get; set; }
		public string DunningOutputArchiveDirectory {  get; set; }
        public string MonthlyOutputArchiveDirectory { get; set; }
        public string CollectionsFilenameContainsString {  get; set; }
		public string DunningFilenameContainsString {  get; set; }
        public string MonthlyAgencyFilenameContainsString { get; set; }
        public string MonthlyDeceasedFilenameContainsString { get; set; }
        public string MonthlyInHouseFilenameContainsString { get; set; }
        public string MonthlyCollectionsFilenameContainsString { get; set; }
        public string MonthlyDunningFilenameContainsString { get; set; }

        public int CollectionsLineWhereDataStarts {  get; set; }
		public int DunningLineWhereDataStarts {  get; set; }
        public int MonthlyAgencyLineWhereDataStarts { get; set; }
        public int MonthlyDeceasedLineWhereDataStarts { get; set; }
        public int MonthlyInHouseLineWhereDataStarts { get; set; }
        public int MonthlyCollectionsLineWhereDataStarts { get; set; }
        public int MonthlyDunningLineWhereDataStarts { get; set; }
        public string BaseWebApiUrl {  get; set; }
		public string BulkInsertBaseWebApiUrl {  get; set; }
		public string BulkInsertConnectionString {  get; set; }
		public string BulkInsertDbName {  get; set; }
		public string CollectionsBulkInsertDbTableName {  get; set; }
		public string DunningBulkInsertDbTableName {  get; set; }
        public string MonthlyBulkInsertDbTableName { get; set; }
        public string ToEmailAddressList {  get; set; }
		public string EmailBaseWebApiUrl {  get; set; }
		public string EmailFromAddress {  get; set; }
    }
}
