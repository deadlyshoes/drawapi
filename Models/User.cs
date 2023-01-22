using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DrawApi.Models
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        [JsonIgnore]
        public List<Shape>? shapes { get; set; }
    }
}
