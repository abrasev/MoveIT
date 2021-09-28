using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MoveProposal
    {        
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string MoveFrom { get; set; }
        [MaxLength(20)]
        public string MoveTo { get; set; }
        public int Distance { get; set; }
        public int LivingArea { get; set; }
        public int AtticArea { get; set; }
        public int CarsNeeded {
        get
            {
                int liv = LivingArea;
                int att = AtticArea;
                int result = ((liv + (att * 2)) / 50) + 1;
                return result;
            }
        }    
        public bool Piano { get; set; }
        public string CreatedBy { get; set; }
    }
}
