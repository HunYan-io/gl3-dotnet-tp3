using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        Personal_info personal_info = new Personal_info();

        [Route("Person/{id:int}")]
        public IActionResult index(int id)
        {
            return View(personal_info.GetPerson(id));
        }
        [Route("Person/")]
        public IActionResult all()
        {
            return View(personal_info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult search(String first_name, String country)
        {
            List<Person> persons = personal_info.GetAllPerson();
            foreach (Person person in persons)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect(person.id.ToString());
                }
            }
            return Redirect("404");
        }
    }
}
