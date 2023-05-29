using OfficeOpenXml;
using QLD_THD.Helper;
using System.Data;
using System.IO;
using System;
using System.Linq;

namespace QLD_THD.CustomImport
{
    public class ImportExcel : ExcelHelper
    {
        public static DataTable ReadFromExcelFileForMonHoc(string path, int headerRow, out string messageError)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path)!.ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorkbook workbook = excelPackage.Workbook;
                    if (workbook == null || workbook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }

                    ExcelWorksheet excelWorksheet = workbook.Worksheets.First();
                    int num = 0;
                    foreach (ExcelRangeBase item in excelWorksheet.Cells[headerRow, 1, headerRow, excelWorksheet.Dimension.End.Column])
                    {
                        string value = item.Text.Trim() ?? "";
                        if (string.IsNullOrEmpty(value))
                        {
                            break;
                        }

                        num++;
                        dataTable.Columns.Add(item.Text.Trim());
                    }

                    for (int i = headerRow + 1; i <= excelWorksheet.Dimension.End.Row; i++)
                    {
                        ExcelRange excelRange = excelWorksheet.Cells[i, 1, i, num];
                        DataRow dataRow = dataTable.NewRow();
                        bool flag = false;
                        string text = "";
                        foreach (ExcelRangeBase item2 in excelRange)
                        {
                            if (item2 != null)
                            {
                                flag = true;
                            }

                            dataRow[item2.Start.Column - 1] = item2.Value;
                            text += ((item2.Value != null) ? item2.Value : "");
                        }

                        if (flag && !string.IsNullOrEmpty(text.Trim()))
                        {
                            dataTable.Rows.Add(dataRow);
                        }

                        if (string.IsNullOrEmpty(text.Trim()))
                        {
                            break;
                        }
                    }
                }

                messageError = "";
            }
            catch (Exception ex)
            {
                messageError = "ERROR:" + ex.Message;
            }

            return dataTable;
        }
    }
}
