using Microsoft.AspNetCore.Mvc;
using PersonEdit.Data;
using PersonEdit.Models;

namespace PersonEdit.Controllers
{
	public class PersonController : Controller
	{
		private readonly ApplicationDbContext _db;

		public PersonController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Person> objPersonList = _db.Persons;
			return View(objPersonList);
		}

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Person obj)
		{
			if(ModelState.IsValid)
			{
			_db.Persons.Add(obj);	
			_db.SaveChanges();
			return RedirectToAction("Index");
			}
			return View();
		}

		//GET
		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0)
			{
				return NotFound();
			}
			var personFromDb = _db.Persons.Find(id);
			if(personFromDb == null)
			{
				return NotFound();
			}
			return View(personFromDb);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Person obj)
		{
			if (ModelState.IsValid)
			{
				_db.Persons.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		//GET
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var personFromDb = _db.Persons.Find(id);
			if (personFromDb == null)
			{
				return NotFound();
			}
			return View(personFromDb);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Persons.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
				_db.Persons.Remove(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			return View();
		}
	}
}
