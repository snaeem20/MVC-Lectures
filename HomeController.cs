using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Penalty.Models;

namespace Penalty.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      Dictionary<int, string> countryList = new Dictionary<int, string>();
      try
      {
        string constr = ConfigurationManager.ConnectionStrings["LibraryDB"].ToString();
        SqlConnection _con = new SqlConnection(constr);
        SqlDataAdapter _da = new SqlDataAdapter("Select * From Country", constr);
        DataTable _dt = new DataTable();
        _da.Fill(_dt);
      }
      catch (System.Data.SqlClient.SqlException ex)
      {
        LoadHardcodedData(countryList);
      }
      finally
      {
        PenaltyCalculator calc = new PenaltyCalculator();
        calc.CountryId = 1;
        //ViewBag.CountryList = ConvertToList(_dt, "CountryId", "Name");
        ViewBag.CountryList = countryList;
        
      }
      return View();
    }

    private void LoadHardcodedData(Dictionary<int, string> countryList)
    {      
      countryList.Add(1, "Pakistan");
      countryList.Add(2, "KSA");     
    }

    private dynamic ConvertToList(DataTable dt, string v1, string v2)
    {
      throw new NotImplementedException();
    }

    public ActionResult Calculate()
    {
      

      
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}