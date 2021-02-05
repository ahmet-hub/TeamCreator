using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.Model;

namespace Trendyol
{
  public class TableCreator
  {
    EmployeeManager employeeManager = new EmployeeManager();
    ExcelReader excelReader = new ExcelReader();

    public List<Employee> GetAll()
    {
      return employeeManager.GetAll();

    }
    private List<Employee> MixEmployee(List<Employee> employees)
    {
      //List<Employee> employees = employeeManager.GetAll();
      List<Employee> MixEmployees = employees.OrderBy(a => Guid.NewGuid()).ToList();

      return MixEmployees;
    }

    public void CreateTeam()
    {

      List<Employee> employees = GetAll();

      List<Employee> mixemployees = MixEmployee(employees);

      var data = TeamOneAndTeamTwo(mixemployees);

      var teamOneTwo = data.Item1.Concat(data.Item2);

      var result = mixemployees.Except(teamOneTwo).ToList();

      var Joker = result.Where(e => e.LastWork != 10).FirstOrDefault();

      result.Remove(Joker);

      var paletteAndSort = CreatePaletteAndSort(result);

      excelReader.ReadExcel(paletteAndSort, data, Joker);

      //employeeManager.UpdateRange(data.Item1, 1);
      //employeeManager.UpdateRange(data.Item2, 2);
      //employeeManager.UpdateRange(paletteAndSort.Item1, 3);
      //employeeManager.UpdateRange(paletteAndSort.Item2, 4);
      //employeeManager.UpdateRange(paletteAndSort.Item3, 5);
      //employeeManager.UpdateRange(paletteAndSort.Item4, 6);


    }

    private List<Employee> GetStatusZeroEmployees(List<Employee> mixEmployees)
    {
      List<Employee> StatusZeroEmployees = new List<Employee>();

      foreach (var employee in mixEmployees)
      {
        if (employee.Status == 0 && employee.Team < 3)
        {
          StatusZeroEmployees.Add(employee);
        }
      }
      return StatusZeroEmployees;

    }

    private Tuple<List<Employee>, List<Employee>> TeamOneAndTeamTwo(List<Employee> employees)
    {

      var statusZeroEmployees = GetStatusZeroEmployees(employees); //statusu 0 olanlari getir

      List<Employee> result = employees.Except(statusZeroEmployees).ToList(); // olmayanlari getir


      List<Employee> team1 = new List<Employee>();
      List<Employee> team2 = new List<Employee>();


      Employee employeeTeam1 = (Employee)statusZeroEmployees.Where(e => e.LastWork == 1).FirstOrDefault();
      Employee employeeTeam2 = (Employee)statusZeroEmployees.Where(e => e.LastWork == 2).FirstOrDefault();

      team1.Add(employeeTeam2);
      statusZeroEmployees.Remove(employeeTeam2);
      team2.Add(employeeTeam1);
      statusZeroEmployees.Remove(employeeTeam1);

      


      bool status = true;

      foreach (var employee in statusZeroEmployees)
      {

        if (status)
        {
          team1.Add(employee);
        }
        else
        {
          team2.Add(employee);
        }
        status = !status;
      } // statusu 0 olanlardan bi takim olustur

      // rastgele iki kisi ekle

      Employee employee1 = (Employee)result.Where(e => e.LastWork == 5).FirstOrDefault();
      result.Remove(employee1);
      Employee employee2 = (Employee)result.Where(e => e.LastWork == 6).FirstOrDefault();
      result.Remove(employee2);


      team1.Add(employee1);
      team2.Add(employee2);
      return Tuple.Create(team1, team2);

    }


    private Tuple<List<Employee>, List<Employee>, List<Employee>, List<Employee>> CreatePaletteAndSort(List<Employee> employees)
    {
      List<Employee> palet1 = new List<Employee>();
      List<Employee> palet2 = new List<Employee>();
      List<Employee> sort1 = new List<Employee>();
      List<Employee> sort2 = new List<Employee>();
      List<Employee> result = employees;
      List<Employee> newPalet = result.Where(e => e.LastWork >4).ToList();

      var mixNewPalet = MixEmployee(newPalet);

      bool statusPalet = true;

      foreach (var item in mixNewPalet)
      {

        if (statusPalet && palet1.Count < 3)
        {
          palet1.Add(item);
        }
        if (statusPalet == false && palet2.Count < 3)
        {
          palet2.Add(item);
        }

        statusPalet = !statusPalet;
      }

      var total = palet1.Concat(palet2);

      var remaining = result.Except(total).ToList();

      bool statusSort = false;
      foreach (var item in remaining)
      {
        if (statusSort && sort1.Count<4)
        {
          sort1.Add(item);
        }
        if(!statusSort && sort2.Count<4)
        {
          sort2.Add(item);

        }
        statusSort = !statusSort;

      }

      return Tuple.Create(palet1, palet2, sort1, sort2);

    }

    private Employee GetJoker(List<Employee> employees)
    {

      var Joker = employees.Where(e => e.LastWork != 10).FirstOrDefault();

      return Joker;
    }
    private void Yazdir(List<Employee> employees)
    {
      foreach (var item in employees)
      {
        Console.WriteLine(item.Name);

      }

    }

  }
}
