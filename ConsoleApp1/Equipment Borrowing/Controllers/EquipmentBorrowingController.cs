using Equipment_Borrowing.Models.Domain;
using Equipment_Borrowing.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equipment_Borrowing.Controllers
{
    [Authorize]
    public class EquipmentBorrowingController : Controller
    {
        private readonly IEquipmentBorrowingRepository _repository;

        public EquipmentBorrowingController(IEquipmentBorrowingRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string? searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            var records = _repository.GetAll(searchTerm);
            return View(records);
        }

        [HttpGet]
        public IActionResult Create() => View(new EquipmentBorrowing());

        [HttpPost]
        public IActionResult Create(EquipmentBorrowing model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Status = "Borrowed";
            _repository.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repository.GetById(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(EquipmentBorrowing model)
        {
            if (!ModelState.IsValid) return View(model);

            _repository.Update(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var record = _repository.GetById(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpGet]
        public IActionResult Return(int id)
        {
            var record = _repository.GetById(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost]
        public IActionResult ConfirmReturn(int id, string? notes)
        {
            var record = _repository.GetById(id);
            if (record != null)
            {
                record.Status = "Returned";
                record.ActualReturnDateTime = DateTime.Now;
                if (!string.IsNullOrEmpty(notes))
                {
                    record.Notes = string.IsNullOrEmpty(record.Notes) ? notes : $"{record.Notes} | Return Note: {notes}";
                }
                _repository.Update(record);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}