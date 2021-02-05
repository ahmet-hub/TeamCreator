using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Trendyol.Model;
using System.IO;

namespace Trendyol
{
  public class ExcelReader
  {
    public void ReadExcel(Tuple<List<Employee>, List<Employee>, List<Employee>, List<Employee>> paletteAndSort, Tuple<List<Employee>, List<Employee>> teamOneAndTeamTwo, Employee Joker)
    {
     
      var path = Directory.GetCurrentDirectory();
      var filePath = path + @"\Trendyol.xlsx";
         Excel.Application Excel;
      Excel.Workbook ExcelBook;
      Excel.Worksheet ExcelSheet;
      Excel = new Excel.Application();
      ExcelBook = Excel.Workbooks.Open(filePath);
      ExcelSheet = (Excel.Worksheet)ExcelBook.Worksheets.get_Item(1);
      ExcelSheet.Cells[1, 1] = DateTime.Today.ToShortDateString() + " - " + DateTime.Today.AddDays(7).ToShortDateString() + "  ÇALIŞMA PLANI";

      ExcelSheet.Cells[6, 3] = Joker.Name;

      int counterTeamOne = 3;
      foreach (var item in teamOneAndTeamTwo.Item1)
      {

        ExcelSheet.Cells[counterTeamOne, 1] = item.Name;
        counterTeamOne++;
      }

      int counterTeamTwo = 3;

      foreach (var item in teamOneAndTeamTwo.Item2)
      {
        ExcelSheet.Cells[counterTeamTwo, 2] = item.Name;
        counterTeamTwo++;

      }

      int counterPaletOne = 9;
      foreach (var item in paletteAndSort.Item1)
      {

        ExcelSheet.Cells[counterPaletOne, 1] = item.Name;
        counterPaletOne++;
      }

      int counterPaletTwo = 9;

      foreach (var item in paletteAndSort.Item2)
      {
        ExcelSheet.Cells[counterPaletTwo, 2] = item.Name;
        counterPaletTwo++;

      }

      int counterSortOne = 9;
      foreach (var item in paletteAndSort.Item3)
      {
        ExcelSheet.Cells[counterSortOne, 3] = item.Name;
        counterSortOne++;
      }

      int counterSortTwo = 9;
      foreach (var item in paletteAndSort.Item4)
      {
        ExcelSheet.Cells[counterSortTwo, 4] = item.Name;
        counterSortTwo++;

      }
      Excel.Visible = true;
          

    }

  }
}
