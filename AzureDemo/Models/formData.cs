using System.ComponentModel.DataAnnotations;

namespace AzureDemo.Models
{
    public class formData
    {
        [Key]
        public Guid AzId { get; set; }
        public string FName { get; set; }
        public string Email { get; set; }
        public string Meg { get; set; }
    }
}
