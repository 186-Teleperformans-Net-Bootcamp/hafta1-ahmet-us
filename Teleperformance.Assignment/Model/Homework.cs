using System.ComponentModel.DataAnnotations;

namespace Teleperformance.Assignment.Model
{
    public class Homework
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public int AssignmentWeek { get; set; }
        public float Result { get; set; }
    }
}
