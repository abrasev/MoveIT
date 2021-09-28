using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ViewModels
{
    public class MoveProposalViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Move From")]
        [MaxLength(20)]        
        public string MoveFrom { get; set; }
        [Required]
        [Display(Name = "Move To")]
        [MaxLength(20)]
        public string MoveTo { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        [Display(Name = "Living Area")]
        public int LivingArea { get; set; }
        [Required]
        [Display(Name = "Attic Area")]
        public int AtticArea { get; set; }
        [Display(Name = "Cars Needed")]
        public int CarsNeeded { get; set; }
        [Required]
        public bool Piano { get; set; }
        public string CreatedBy { get; set; }
    }
}
