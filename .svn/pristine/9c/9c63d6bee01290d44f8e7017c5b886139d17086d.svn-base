using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennCareWith2PassAuth9.Data.Models;

namespace TennCareWith2PassAuth9.ImportConsoleApp
{
    public class MonthlyExcelCellStringValue
    {
        public MonthlyExcelCellStringValue
        (
            Worksheet inputWorksheet
            , qy_GetTennCareWith2PassAuthConfigOutputColumns inputConfigOptions
            , string inputColumnName
            , int inputRowNumber
            , int inputColumnNumber
        )
        {
            MyWorksheet = inputWorksheet;
            MyConfigOptions = inputConfigOptions;
            MyColumnName = inputColumnName;
            MyRowNumber = inputRowNumber;
            MyColumnNumber = inputColumnNumber;
            if (MyColumnNumber == 14)
            {
                int i = 0;
                i++;
            }
        }
        public Worksheet MyWorksheet { get; set; }
        public qy_GetTennCareWith2PassAuthConfigOutputColumns MyConfigOptions { get; set; }
        public string MyColumnName { get; set; }
        public int MyRowNumber { get; set; }
        public int MyColumnNumber { get; set; }
        public string MyColumnDesignation
        {
            get
            {
                switch (MyColumnNumber)
                {
                    case 1:
                        return "A";
                    case 2:
                        return "B";
                    case 3:
                        return "C";
                    case 4:
                        return "D";
                    case 5:
                        return "E";
                    case 6:
                        return "F";
                    case 7:
                        return "G";
                    case 8:
                        return "H";
                    case 9:
                        return "I";
                    case 10:
                        return "J";
                    case 11:
                        return "K";
                    case 12:
                        return "L";
                    case 13:
                        return "M";
                    case 14:
                        return "N";
                    case 15:
                        return "O";
                    case 16:
                        return "P";
                    case 17:
                        return "Q";
                    case 18:
                        return "R";
                    case 19:
                        return "S";
                    case 20:
                        return "T";
                    case 21:
                        return "U";
                    case 22:
                        return "V";
                    case 23:
                        return "W";
                    case 24:
                        return "X";
                    case 25:
                        return "Y";
                    default:
                        return string.Empty;
                }
            }
        }
        public string MyCellDesignation
        {
            get
            {
                if (MyColumnDesignation.Length == 0)
                {
                    return string.Empty;
                }
                return $"{MyColumnDesignation}{MyRowNumber.ToString()}";
            }
        }


        public GetMonthlyExcelCellStringValueOutput GetExcelCellStringValue()
        {
            GetMonthlyExcelCellStringValueOutput returnOutput = new GetMonthlyExcelCellStringValueOutput();
            string? cellValue = null;

            // If we have run out of columns to get return.
            if (MyCellDesignation.Length == 0)
            {
                return returnOutput;
            }
            cellValue = MyWorksheet.Range[MyCellDesignation].Text;

            // If text value is not available, get numeric value
            if (cellValue == null)
            {
                cellValue = MyWorksheet.Range[MyCellDesignation].NumberValue.ToString();
            }

            // If cell value is empty
            //    If 1st column we are done.
            //    Else Omit this line.
            if (cellValue == null || cellValue.Length == 0 || cellValue.CompareTo("NaN") == 0)
            {
                if (MyColumnNumber == 1)
                {
                    returnOutput.OutputStringValue = "BlankLine";
                    return returnOutput;
                }

                // If this is NOT the first column and it is null or emptystring, return empty string.
                if (MyColumnNumber != 1)
                {
                    cellValue = string.Empty;
                    returnOutput.OutputStringValue =
                        "OmitLine";
                    return returnOutput;
                }
            }

            cellValue = cellValue.Trim().Replace(',', '^');
            if (MyColumnNumber == 2 || MyColumnNumber == 4)
            {
                cellValue =
                    ConvertDateToMMSlashddSlashyyyy(cellValue);
            }

            returnOutput.OutputStringValue = cellValue;

            return returnOutput;
        }
        public string ConvertDateToMMSlashddSlashyyyy(string inputMSlashdSlashyyyy)
        {
            string returnOutput = string.Empty;
            string[] partsArray =
                inputMSlashdSlashyyyy
                .Split('/');
            if (partsArray.Length == 3)
            {
                string MM =
                    partsArray[0].PadLeft(2, '0');
                string dd =
                    partsArray[1].PadLeft(2, '0');
                string yyyy =
                    partsArray[2];
                returnOutput =
                    $"{MM}/{dd}/{yyyy}";
            }

            return returnOutput;
        }
    }
}
