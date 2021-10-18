using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
   public class WorkUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}
