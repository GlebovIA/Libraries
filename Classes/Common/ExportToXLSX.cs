using Libraries.Contexts;
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
            try
            {
                if (VMTabs.CurrentElement == null)
                {
                    MessageBox.Show("Выберите таблицу для экспорта", "Уведомление");
                    return;
                }
                entity SelectedEntity = (VMTabs.CurrentElement.DataContext as VMTabs).Modell.Entity;
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
                            if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Носители литературы").Count() != 0)
                            {
                                worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Носители литературы").First();
                                worksheet.Cells.Clear();
                            }
                            else
                                worksheet = excelPackage.Workbook.Worksheets.Add("Носители литературы");
                            titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Наименование"
                            };
                            foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                            worksheet.Cells[1, 1, 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                            using (SqlDataReader reader = DbConnection.Query("Select * from Literature_sources order by Id_source;"))
                            {
                                while (reader.Read())
                                {
                                    rowsCount++;
                                    worksheet.Cells[rowsCount, 1].Value = reader[0];
                                    worksheet.Cells[rowsCount, 2].Value = reader[1].ToString();
                                }
                                worksheet.Cells[2, 1, rowsCount, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                            worksheet.Cells.AutoFitColumns();
                            break;
                        case entity.Types:
                            LiteratureTypesContext types = new LiteratureTypesContext();
                            if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Типы литературы").Count() != 0)
                            {
                                worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Типы литературы").First();
                                worksheet.Cells.Clear();
                            }
                            else
                                worksheet = excelPackage.Workbook.Worksheets.Add("Типы литературы");
                            titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Наименование"
                            };
                            foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                            worksheet.Cells[1, 1, 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                            using (SqlDataReader reader = DbConnection.Query("Select Id_type, Type_name from Literature_types order by Id_type;"))
                            {
                                while (reader.Read())
                                {
                                    rowsCount++;
                                    worksheet.Cells[rowsCount, 1].Value = reader[0];
                                    worksheet.Cells[rowsCount, 2].Value = reader[1].ToString();
                                }
                                worksheet.Cells[2, 1, rowsCount, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                            worksheet.Cells.AutoFitColumns();
                            break;
                        case entity.Workers:
                            WorkersContext workers = new WorkersContext();
                            if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Сотрудники").Count() != 0)
                            {
                                worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Сотрудники").First();
                                worksheet.Cells.Clear();
                            }
                            else
                                worksheet = excelPackage.Workbook.Worksheets.Add("Сотрудники");
                            titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Фамилия",
                                "Имя",
                                "Отчество",
                                "Библиотека",
                                "Должность",
                                "Дата рождения",
                                "Дата трудоустройства",
                                "Образование",
                                "Зарплата"
                            };
                            foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                            worksheet.Cells[1, 1, 1, 10].Style.Border.BorderAround(ExcelBorderStyle.Double);
                            using (SqlDataReader reader = DbConnection.Query("Select Id_worker, Worker_name, Worker_surname, Worker_patronymic, Libraries.Library_name, Job, Birth_date, Admission_date, Education, Salary from Workers, Libraries " +
                                "where Libraries.Library_name = Any(" +
                                "Select Library_name from Libraries where Id_library = Library) " +
                                "order by Id_worker;"))
                            {
                                while (reader.Read())
                                {
                                    rowsCount++;
                                    worksheet.Cells[rowsCount, 1].Value = reader[0];
                                    worksheet.Cells[rowsCount, 2].Value = reader[1].ToString();
                                    worksheet.Cells[rowsCount, 3].Value = reader[2].ToString();
                                    worksheet.Cells[rowsCount, 4].Value = reader[3].ToString();
                                    worksheet.Cells[rowsCount, 5].Value = reader[4];
                                    worksheet.Cells[rowsCount, 6].Value = reader[5];
                                    worksheet.Cells[rowsCount, 7].Value = reader[6].ToString();
                                    worksheet.Cells[rowsCount, 8].Value = reader[7].ToString();
                                    worksheet.Cells[rowsCount, 9].Value = reader[8];
                                    worksheet.Cells[rowsCount, 10].Value = reader[9];
                                }
                                worksheet.Cells[2, 1, rowsCount, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                            worksheet.Cells.AutoFitColumns();
                            break;
                        case entity.Replenishments:
                            ReplenishmentsContext replenishments = new ReplenishmentsContext();
                            if (excelPackage.Workbook.Worksheets.Count != 0 && excelPackage.Workbook.Worksheets.Where(x => x.Name == "Пополнения").Count() != 0)
                            {
                                worksheet = excelPackage.Workbook.Worksheets.Where(x => x.Name == "Пополнения").First();
                                worksheet.Cells.Clear();
                            }
                            else
                                worksheet = excelPackage.Workbook.Worksheets.Add("Пополнения");
                            titles = new ObservableCollection<string>
                            {
                                "Код",
                                "Фонд",
                                "Ответственный",
                                "Дата пополнения",
                                "Носитель литературы",
                                "Тип литературы",
                                "Издательство",
                                "Дата издания",
                                "Количество экземпляров"
                            };
                            foreach (string title in titles) { worksheet.Cells[1, titles.IndexOf(title) + 1].Value = title; }
                            worksheet.Cells[1, 1, 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Double);
                            using (SqlDataReader reader = DbConnection.Query("Select Id_replenishment, Fond_name, Workers.Worker_surname, Date, Source_name, Type_name, Publishing_company, Publishing_date, Copy_count " +
                                "from Replenishments, Fonds, Workers, Literature_types, Literature_sources " +
                                "where Fonds.Id_fond = Fond " +
                                "AND Workers.Id_worker = Worker " +
                                "AND Literature_types.Id_type = Literature_type " +
                                "AND Literature_sources.Id_source = Literature_source " +
                                "order by Id_fond;"))
                            {
                                while (reader.Read())
                                {
                                    rowsCount++;
                                    worksheet.Cells[rowsCount, 1].Value = reader[0];
                                    worksheet.Cells[rowsCount, 2].Value = reader[1];
                                    worksheet.Cells[rowsCount, 3].Value = reader[2];
                                    worksheet.Cells[rowsCount, 4].Value = reader[3].ToString();
                                    worksheet.Cells[rowsCount, 5].Value = reader[4];
                                    worksheet.Cells[rowsCount, 6].Value = reader[5];
                                    worksheet.Cells[rowsCount, 7].Value = reader[6].ToString();
                                    worksheet.Cells[rowsCount, 8].Value = reader[7].ToString();
                                    worksheet.Cells[rowsCount, 9].Value = reader[8];
                                }
                                worksheet.Cells[2, 1, rowsCount, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                            worksheet.Cells.AutoFitColumns();
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
                    MessageBox.Show("Экспорт данных успешно завершен.", "Уведомление");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка экспорта.", "Уведомление");
            }
        }
    }
}
