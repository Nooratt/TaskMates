using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskDudes.Models
{
    public class Settings
    {
        public Settings() { }
        public Settings(NotificationType type) { this.NotificationType = type; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public NotificationType NotificationType { get; set; }
        //public Coach Coach {get; set;} = new Coach();
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }

    public enum NotificationType
    {
        Email,
        PushNotification,
        IconBatch,
        InAppNotificaton,
        None,
        All = Email + PushNotification + IconBatch + InAppNotificaton
    }
}
