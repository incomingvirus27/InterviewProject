using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
    public class Batches
    {
        public int Id { get; set; }
        public string Batch { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
    }
}
