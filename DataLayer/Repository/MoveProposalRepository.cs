using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class MoveProposalRepository : IMoveProposalsRepository
    {
        private readonly MoveItContext _moveItContext;
        public MoveProposalRepository(MoveItContext moveItContext)
        {
            _moveItContext = moveItContext;
        }
        public MoveProposal Add(MoveProposal entity)
        {
            _moveItContext.MoveProposals.Add(entity);
            _moveItContext.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = _moveItContext.MoveProposals.Find(id);
            _moveItContext.MoveProposals.Remove(entity);
            _moveItContext.SaveChanges();
        }

        public IReadOnlyList<MoveProposal> GetAll()
        {
            return _moveItContext.MoveProposals.ToList();
        }

        public MoveProposal GetById(Guid id)
        {
            return _moveItContext.MoveProposals.Find(id);
        }
    }
}
