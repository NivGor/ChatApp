using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatApp.Data;
using ChatApp.Models.Ratings;

namespace ChatApp.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingService service;

        public RatingsController(ChatAppContext context)
        {
            service = new RatingService();
        }

        // GET: Ratings
        public IActionResult Index()
        {
            ViewData["AverageRate"] = RatingService.AverageRate;
              return View(service.GetAll());
        }

        public IActionResult Search()
        {
            ViewData["AverageRate"] = RatingService.AverageRate;
            return View(service.GetAll());
        }

        [HttpPost]
        public IActionResult Search(string query)
        {

            ViewData["AverageRate"] = RatingService.AverageRate;
            var ratings = service.GetAll();
            List<Rating> results = new List<Rating>();
            if (query == null)
            {
                return View(results);
            }
            foreach (Rating rating in ratings)
            {
                if (rating.Name.Contains(query) || (rating.Text != null && rating.Text.Contains(query)))
                {
                    results.Add(rating);
                }
            }
            return View(results);
        }

        // GET: Ratings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = service.Get((int)id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Rate,Text,Date")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                service.Create(rating.Name, rating.Rate, rating.Text);
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = service.Get((int) id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Rate,Text,Date")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    service.Edit(rating.Id, rating.Rate, rating.Text);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = service.Get((int)id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rating = service.Get((int) id);
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
