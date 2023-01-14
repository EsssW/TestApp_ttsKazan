using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TestApp
{
    [DataContract]
    public class ServerUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }

        [Unique]
        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        public string Login { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public string Email {get; set; }
        [Required]
        [DataMember]
        public string Phone {get; set; }

    }
}
