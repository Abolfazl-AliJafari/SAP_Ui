using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Data.SqlClient;
using OfficeOpenXml;

namespace DataAccessLayer
{
    public class ExportImport
    {
        public static OperationResult ExportToExcel(string Address)
        {
            //var students = Student.Select();
            //var gheybats = Gheybat.Select();
            //var takhirs = Takhir.Select();
            //var tazakors= Tazakor.Select();
            //var tashvighs = Tashvigh.Select();
            //var mavared = Mored.Select();
            List<string> tblNames = new List<string>
            {
                "Student_Tbl",
                "Gheybat_Tbl",
                "Mavared_Tbl",
                "Takhir_Tbl",
                "Tazakor_Tbl",
                "User_Tbl",
                "Tashvigh_Tbl"
            };
            string connectionString = "Data Source=.;Initial Catalog=SAP_Db;Integrated Security=True";
            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook workbook = xlApp.Workbooks.Open(Address);
            try
        {
            // ایجاد یک شیء از کلاس SqlConnection با استفاده از رشته اتصال
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // باز کردن اتصال
                connection.Open();
                    for (int i = 0; i < 6; i++)
                    {
                        // تعریف دستور SQL برای دریافت داده‌ها
                        string sqlQuery = "SELECT * FROM " + tblNames[i];

                        // ایجاد یک شیء از کلاس SqlCommand با استفاده از دستور SQL و اتصال
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            // ایجاد یک شیء از کلاس SqlDataReader برای خواندن نتیجه
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                              

                                    ExcelWorksheet worksheet = workbook.Worksheets.Add(tblNames[i]);
                                    for (int col = 0; col < reader.FieldCount; col++)
                                    {
                                        // نوشتن نام ستون‌ها در سطر اول فایل Excel
                                        worksheet.Cells[1, col + 1].Value = reader.GetName(col);
                                    }

                                    int row = 2;

                                    while (reader.Read())
                                    {
                                        for (int col = 0; col < reader.FieldCount; col++)
                                        {
                                            worksheet.Cells[row, col + 1].Value = reader[col];
                                        }
                                        row++;
                                    }


                                
                            }
                        }
                    }
                connection.Close();
            }
                workbook.SaveAs(Address);

                return new OperationResult
                {
                    Success = true,
                    Message = "خروجی موفقیت آمیز بود"
                };
        }
        catch (Exception ex)
        {
                return new OperationResult
                {
                    Success = false,
                    Message = "خروجی موفقیت آمیز نبود"
                };
        }

        }
    }
}
