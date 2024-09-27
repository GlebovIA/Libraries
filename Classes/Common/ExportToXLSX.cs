using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using static Libraries.Modell.TabsModell;
using DbConnection = Libraries.Classes.Db.DbConnection;

namespace Libraries.Classes.Common
{
    public class ExportToXLSX
    {
        public static void Export()
        {
            entity SelectedEntity = (VMTabs.CurrentElement.DataContext as VMTabs).Modell.Entity;
            MessageBox.Show(SelectedEntity.ToString());
            string fileName = $"Отчет от {DateTime.Now.ToString("yyyy-MM-dd")}.xlsx";
            FileInfo fileInfo = new FileInfo(Environment.CurrentDirectory + "\\" + fileName);
            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;
                int rowsCount = 1;
                ObservableCollection<string> titles;
                switch (SelectedEntity)
                {
                    case entity.Libraries:
                        LibrariesContext libraries = new LibrariesContext();
                        if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Библиотеки").Count() != 0)
                        {
                            worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Библиотеки").First();
                            worksheet.Cells.Clear();
                        }
                        else
                            worksheet = excelPackage.Workbook.Worksheets.Add("Библиотеки");
                        titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Наименование",
                                "Адрес",
                                "Город",
                            };
                        foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                        using (SqlDataReader reader = DbConnection.Query("Select * from Libraries order by Id_library"))
                        {
                            while (reader.Read())
                            {
                                rowsCount++;
                                worksheet.Cells[rowsCount, 1].Value = reader[0];
                                worksheet.Cells[rowsCount, 2].Value = reader[1].ToString();
                                worksheet.Cells[rowsCount, 3].Value = reader[2].ToString();
                                worksheet.Cells[rowsCount, 4].Value = reader[3].ToString();
                            }
                            worksheet.Cells[2, 1, rowsCount, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }
                        worksheet.Cells[1, 1, 1, 4].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        worksheet.Cells.AutoFitColumns();
                        break;
                    case entity.Fonds:
                        FondsContext fonds = new FondsContext();
                        MessageBox.Show(fonds.Fonds.Count().ToString());
                        if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Фонды").Count() != 0)
                        {
                            worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Фонды").First();
                            worksheet.Cells.Clear();
                        }
                        else
                            worksheet = excelPackage.Workbook.Worksheets.Add("Фонды");
                        titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Наименование",
                                "Библиотека",
                                "Кол-во книг",
                                "Кол-во журналов",
                                "Кол-во газет",
                                "Кол-во сборников",
                                "Кол-во диссертаций",
                                "Кол-во рефератов"
                            };
                        foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                        worksheet.Cells[1, 1, 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        using (SqlDataReader reader = DbConnection.Query("Select Id_fond, Fond_name, Libraries.Library_name, Book_count, Journal_count, Newspaper_count, Collection_count, Dissertation_count, Report_count from Fonds, Libraries " +
                            "where Libraries.Library_name = Any(" +
                            "Select Library_name from Libraries where Id_library = Library) " +
                            "order by Id_fond;"))
                        {
                            while (reader.Read())
                            {
                                rowsCount++;
                                worksheet.Cells[rowsCount, 1].Value = reader[0];
                                worksheet.Cells[rowsCount, 2].Value = reader[1].ToString();
                                worksheet.Cells[rowsCount, 3].Value = reader[2].ToString();
                                worksheet.Cells[rowsCount, 4].Value = reader[3];
                                worksheet.Cells[rowsCount, 5].Value = reader[4];
                                worksheet.Cells[rowsCount, 6].Value = reader[5];
                                worksheet.Cells[rowsCount, 7].Value = reader[6];
                                worksheet.Cells[rowsCount, 8].Value = reader[7];
                                worksheet.Cells[rowsCount, 9].Value = reader[8];
                            }
                            worksheet.Cells[2, 1, rowsCount, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }
                        worksheet.Cells.AutoFitColumns();
                        break;
                    case entity.Sources:
                        LiteratureSourcesContext sources = new LiteratureSourcesContext();
                        foreach (Literature_sourcesModell source in sources.Literature_sources)
                        {

                        }
                        break;
                    case entity.Types:
                        LiteratureTypesContext types = new LiteratureTypesContext();
                        foreach (Literature_typesModell type in types.Literature_types)
                        {

                        }
                        break;
                    case entity.Workers:
                        WorkersContext workers = new WorkersContext();
                        foreach (WorkersModell worker in workers.Workers)
                        {

                        }
                        break;
                    case entity.Replenishments:
                        ReplenishmentsContext replenishments = new ReplenishmentsContext();
                        foreach (ReplenishmentsModell replenishment in replenishments.Replenishments)
                        {

                        }
                        break;
                }
                if (fileInfo.Exists)
                {
                    excelPackage.Save();
                }
                else
                {
                    excelPackage.SaveAs(fileInfo);
                }

            }
        }
    }
}
