using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using TP3.Models;
//using System.Data.SQLite;
namespace TP3.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            Debug.WriteLine("testestes");
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=D:\\Temp\\database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine("Id: " + (int)reader["id"]);
                        Debug.WriteLine("First name: " + (string)reader["first_name"]);
                        Debug.WriteLine("Last name: " + (string)reader["last_name"]);
                        Debug.WriteLine("Email: " + (string)reader["email"]);
                        Debug.WriteLine("Image: " + (string)reader["image"]);
                        Debug.WriteLine("Country: " + (string)reader["country"]);
                    }


                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}