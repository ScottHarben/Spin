﻿using System;
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
        public readonly DateTime DateTime = DateTime.Today;

        public CourseModel CourseModel { get; set; }
        [Display(Name = "Course")]
        public int CourseModelId { get; set; }

        public TeeModel TeeModel { get; set; }
        [Display(Name = "Tees")]
        public int TeeModelId { get; set; }

        public HoleModel HoleModel { get; set; }
        [Display(Name = "Hole")]
        public int HoleModelId { get; set; }

        public int FairwayInRegulation { get; set; }
        public int GreenInRegulation { get; set; }
        public byte NumberOfPutts { get; set; }
        public short StrokesAgainstPar { get; set; }
    }
}