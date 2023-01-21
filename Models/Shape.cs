using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DrawApi.Models
{
    [Table("shape")]
    public class Shape
    {
        public int id { get; set; }
        public string type { get; set; }
        public float[] points { get; set; }

        [Column("user_id")]
        public int userId { get; set; }

        [JsonIgnore]
        public User? user { get; set; }
    }
}
