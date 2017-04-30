using System.ComponentModel.DataAnnotations;

namespace TweetnHash.Models
{
    public class TwitterAccount
    {
        [Key]
        public int TwitterId { get; set; }

        //public string TwitterUserName { get; set; }

        public bool CheckAccount { get; set; }
    }
}