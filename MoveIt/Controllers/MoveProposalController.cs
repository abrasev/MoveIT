using BuisnessLayer.Interfaces;
using BuisnessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoveIt.Controllers
{
    public class MoveProposalController : Controller
    {
        private readonly IMoveProposalService _moveProposalService;
        public MoveProposalController(IMoveProposalService moveProposalService)
        {
            _moveProposalService = moveProposalService;
        }
        public IActionResult Index()
        {
            var moveProposalVM = _moveProposalService.GetAllFromUser();

            return View(moveProposalVM);
        }
        public IActionResult Add(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            var moveproposalVM = _moveProposalService.GetById(id);
            return View(moveproposalVM);
        }
        [HttpGet]
        public IActionResult Add(MoveProposalViewModel movePoposalViewModel)
        {
            if (movePoposalViewModel.Id == Guid.Empty)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Add(MoveProposalViewModel movePoposalViewModel, int i)
        {
            if (movePoposalViewModel.Id == Guid.Empty)
            {
                _moveProposalService.Add(movePoposalViewModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
    }
}
