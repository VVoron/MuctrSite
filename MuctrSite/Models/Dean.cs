using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Dean
    {
        public Guid Id { get; set; }
        public string surname { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string mediaUrl { get; set; }
    }
}
