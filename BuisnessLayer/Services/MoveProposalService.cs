using BuisnessLayer.Interfaces;
using BuisnessLayer.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class MoveProposalService : IMoveProposalService
    {
        private readonly IMoveProposalsRepository _moverProposalRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MoveProposalService(IMoveProposalsRepository moverProposalRepository, IHttpContextAccessor httpContextAccessor)
        {
            _moverProposalRepository = moverProposalRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public MoveProposalViewModel Add(MoveProposalViewModel moveProposalViewModel)
        {
            MoveProposal mover = new MoveProposal();
            mover.Id = moveProposalViewModel.Id;
            mover.MoveFrom = moveProposalViewModel.MoveFrom;
            mover.MoveTo = moveProposalViewModel.MoveTo;
            mover.LivingArea = moveProposalViewModel.LivingArea;
            mover.AtticArea = moveProposalViewModel.AtticArea;
            mover.Distance = moveProposalViewModel.Distance;
            mover.CreatedBy = moveProposalViewModel.CreatedBy;
            //mover.CarsNeeded = moveProposalViewModel.CarsNeeded;

            _moverProposalRepository.Add(mover);

            moveProposalViewModel.Id = mover.Id;
            moveProposalViewModel.MoveFrom = mover.MoveFrom;
            moveProposalViewModel.MoveTo = mover.MoveTo;
            moveProposalViewModel.LivingArea = mover.LivingArea;
            moveProposalViewModel.AtticArea = mover.AtticArea;
            moveProposalViewModel.Distance = mover.Distance;
            moveProposalViewModel.CarsNeeded = mover.CarsNeeded;
            moveProposalViewModel.CreatedBy = mover.CreatedBy;

            return moveProposalViewModel;

        }

        public void Delete(MoveProposalViewModel moveProposalViewModel)
        {
            MoveProposal mover = new MoveProposal();
            mover.Id = moveProposalViewModel.Id;

            _moverProposalRepository.Delete(mover.Id);
        }

        public MoveProposalListViewModel GetAll()
        {
            var moveProposals = _moverProposalRepository.GetAll();
            //MoveProposalListViewModel proposalListVM = new MoveProposalListViewModel();

            List<MoveProposalViewModel> listVM = new List<MoveProposalViewModel>();

            foreach (var item in moveProposals)
            {
                MoveProposalViewModel moveProposalVM = new MoveProposalViewModel();
                moveProposalVM.Id = item.Id;
                moveProposalVM.MoveFrom = item.MoveFrom;
                moveProposalVM.MoveTo = item.MoveTo;
                moveProposalVM.LivingArea = item.LivingArea;
                moveProposalVM.AtticArea = item.AtticArea;
                moveProposalVM.Distance = item.Distance;
                moveProposalVM.CreatedBy = item.CreatedBy;
                moveProposalVM.CarsNeeded = (item.LivingArea + item.AtticArea);

                listVM.Add(moveProposalVM);
            }
            //proposalListVM = listVM;
            return new MoveProposalListViewModel()
            {
                MoveProposal = listVM
            };
        }

        public MoveProposalListViewModel GetAllFromUser()
        {
            var moveProposals = _moverProposalRepository.GetAll();
            //MoveProposalListViewModel proposalListVM = new MoveProposalListViewModel();

            List<MoveProposalViewModel> listVM = new List<MoveProposalViewModel>();

            foreach (var item in moveProposals)
            {
                MoveProposalViewModel moveProposalVM = new MoveProposalViewModel();
                moveProposalVM.Id = item.Id;
                moveProposalVM.MoveFrom = item.MoveFrom;
                moveProposalVM.MoveTo = item.MoveTo;
                moveProposalVM.LivingArea = item.LivingArea;
                moveProposalVM.AtticArea = item.AtticArea;
                moveProposalVM.Distance = item.Distance;
                moveProposalVM.CreatedBy = item.CreatedBy;
                moveProposalVM.CarsNeeded = item.CarsNeeded;
                if (_httpContextAccessor?.HttpContext?.User?.Identity?.Name == item.CreatedBy)
                {
                    listVM.Add(moveProposalVM);
                }
            }
            //proposalListVM = listVM;
            return new MoveProposalListViewModel()
            {
                MoveProposal = listVM
            };
        }

        
        public MoveProposalViewModel GetById(Guid id)
        {
            var moveProposal = _moverProposalRepository.GetById(id);

            MoveProposalViewModel moveProposalVm = new MoveProposalViewModel();
            moveProposalVm.Id = moveProposal.Id;
            moveProposalVm.MoveFrom = moveProposal.MoveFrom;
            moveProposalVm.MoveTo = moveProposal.MoveTo;
            moveProposalVm.LivingArea = moveProposal.LivingArea;
            moveProposalVm.AtticArea = moveProposal.AtticArea;
            moveProposalVm.Distance = moveProposal.Distance;
            moveProposalVm.CreatedBy = moveProposal.CreatedBy;
            moveProposalVm.CarsNeeded = (moveProposal.LivingArea + moveProposal.AtticArea);

            return moveProposalVm;
        }
    }
}
