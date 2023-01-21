using System.ComponentModel.DataAnnotations.Schema;

namespace DrawApi.Models
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public String login { get; set; }
        public String password { get; set; }

        public List<Shape> shapes { get; set; }
    }
}
