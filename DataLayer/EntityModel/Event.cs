﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NagarroTraining.MVC.DataLayer.EntityModel
{
    /// <summary>
    /// this model is used for events for book reading
    /// </summary>
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        public string EventDescription { get; set; }

        public string EventOtherDetails { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Please Enter Duration")]
        public int EventDuration { get; set; }

        [Required(ErrorMessage = "Please Enter Event Type")]
        public int EventType { get; set; }

        [Required(ErrorMessage = "Please Enter Event Date")]
     
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please Enter Event Start Time")]
        [DataType(DataType.Time)]
        public string EventStartTime { get; set; }

        public int EventActive { get; set; }

        public int UserId { get; set; }



        public virtual User User { get; set; }
        
        public virtual IList<Invitation> Invitation { get; set; }
    }
}
