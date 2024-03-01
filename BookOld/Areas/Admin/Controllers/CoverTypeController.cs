using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Book.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookOld.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
        return View(objCoverTypeList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();

            TempData["success"] = "Cover Type Created Successfully!";

            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (coverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(coverTypeFromDbFirst);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();

            TempData["success"] = "Category updated successfully";

            return RedirectToAction("Index");
        }

        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (coverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(coverTypeFromDbFirst);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();

        TempData["success"] = "Cover Type deleted successfully";

        return RedirectToAction(nameof(Index));
    }
}