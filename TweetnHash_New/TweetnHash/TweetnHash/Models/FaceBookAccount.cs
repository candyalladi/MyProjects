using System.ComponentModel.DataAnnotations;

namespace TweetnHash.Models
{
    public class FaceBookAccount
    {
        [Key]
        public int FaceBookId { get; set; }

       // public string FaceBook UserName{ get; set; }

        public bool CheckAccount { get; set; }
    }
}