namespace Spin.Models
{
    public class TeeModel
    {
        public int Id { get; set; }
        public string TeeName { get; set; }
        public byte TeePar { get; set; }
        public short TeeDistance { get; set; }
        public CourseModel CourseModel { get; set; }
        public int CourseModelId { get; set; }
    }
}