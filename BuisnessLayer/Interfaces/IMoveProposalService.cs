using BuisnessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface IMoveProposalService
    {
        MoveProposalViewModel Add(MoveProposalViewModel moveProposalViewModel);
        MoveProposalListViewModel GetAll();
        MoveProposalListViewModel GetAllFromUser();
        MoveProposalViewModel GetById(Guid id);
        void Delete(MoveProposalViewModel moveProposalViewModel);
    }
}
