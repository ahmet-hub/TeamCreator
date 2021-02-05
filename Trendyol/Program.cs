using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.Model;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Trendyol
{
  class Program
  {
    static void Main(string[] args)
    {

      TableCreator tableCreator = new TableCreator();
      tableCreator.CreateTeam();

      //var key = Console.ReadLine();

      //if (key.ToLower() == "yes")
      //{
      //  Environment.Exit(0);
      //}
      //if (key.ToLower() == "no")
      //{


      //  tableCreator.CreateTeam();
      //}

    }

  }
}

