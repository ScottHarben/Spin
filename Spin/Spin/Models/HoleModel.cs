namespace Spin.Models
{
    public class HoleModel
    {
        public int Id { get; set; }
        public byte HoleNumber { get; set; }
        public byte HolePar { get; set; }
        public short HoleDistance { get; set; }
        public TeeModel TeeModel { get; set; }
        public int TeeModelId { get; set; }
    }
}