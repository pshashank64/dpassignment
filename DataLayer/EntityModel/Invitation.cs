using System.ComponentModel.DataAnnotations;

namespace NagarroTraining.MVC.DataLayer.EntityModel
{
    /// <summary>
    /// this model is used for invitation addition in the database
    /// </summary>
    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InvitationActive { get; set; }

        public int EventId { get; set; }
        public int UserId { get; set; }

        public virtual Event Event { get; set; }
  
    }
}
