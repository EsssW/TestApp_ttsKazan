using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp
{
    [DataContract]
    public  class MousEvent
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public int UserId { get; set; }

        [DataMember]
        [Required]
        public string eventName { get; set; }

        [DataMember]
        public ushort? mousX_pos { get; set; }
        [DataMember]
        public ushort? mousY_pos { get; set; }

        [DataMember]
        public DateTime eventTime { get; set; }




    }
}
