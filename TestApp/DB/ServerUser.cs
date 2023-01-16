
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestApp
{
    [DataContract]
    public class ServerUser
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email {get; set; }

        [DataMember]
        public string Phone {get; set; }

        [DataMember]
        public int IsAdmin { get; set; }

        [DataMember]
        public List<MousEvent> mousEvents { get; set; }



    }
}
