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

        public CourseModel CourseModel { get; set; }
        public int CourseModelId { get; set; }

        public TeeModel TeeModel { get; set; }
        public int TeeModelId { get; set; }

        public HoleModel HoleModel { get; set; }
        public int HoleModelId { get; set; }

        public bool FairwayInRegulation { get; set; }
        public bool GreenInRegulation { get; set; }
        public byte NumberOfPutts { get; set; }
        public short StrokesAgainstPar { get; set; }
    }
}