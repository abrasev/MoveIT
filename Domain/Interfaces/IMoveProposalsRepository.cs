using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMoveProposalsRepository
    {
        MoveProposal GetById(Guid id);
        IReadOnlyList<MoveProposal> GetAll();
        MoveProposal Add(MoveProposal entity);
        void Delete(Guid id);
    }
}
