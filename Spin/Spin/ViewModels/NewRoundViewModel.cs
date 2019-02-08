using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.ViewModels
{
    public class NewRoundViewModel
    {
        public IEnumerable<CourseModel> CourseModels { get; set; }
        public IEnumerable<TeeModel> TeeModels { get; set; }
        public IEnumerable<HoleModel> HoleModels { get; set; }
        public RoundModel RoundModel { get; set; }
    }
}