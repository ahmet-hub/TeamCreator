using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.Model;

namespace Trendyol
{
  public class EmployeeManager
  {
    TrendyolContext trendyolContext = new TrendyolContext();

    public List<Employee> GetAll()
    {
      return trendyolContext.Employee.ToList();

    }

    public void UpdateRange(List<Employee> employees,int lastWork)
    {
      foreach (var item in employees)
      {
        item.LastWork = lastWork;

      }

      trendyolContext.UpdateRange(employees);
      trendyolContext.SaveChanges();
    }

  }
}
