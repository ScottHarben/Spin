using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class RoundModel
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        private readonly DateTime DateTime = DateTime.Today;

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public int TeeId { get; set; }

        public int HoleId { get; set; }

        public bool FIR { get; set; }

        public bool GIR { get; set; }

        public byte PuttNumber { get; set; }

        public short StrokesAgainstPar { get; set; }
    }
}