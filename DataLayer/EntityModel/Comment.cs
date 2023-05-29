using System.ComponentModel.DataAnnotations;

namespace NagarroTraining.MVC.DataLayer.EntityModel
{
    /// <summary>
    /// this model is used for adding comments in the book events
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserComment { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }


         
    }
}
