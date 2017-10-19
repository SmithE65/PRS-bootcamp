using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class Message
    {
        [Required]
        public int Id { get; set; }

        //[Required]
        public int? SenderId { get; set; }
        public virtual User Sender { get; set; }

        //[Required]
        public int? ReceiverId { get; set; }
        public virtual User Receiver { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public bool IsRead { get; set; }

        /// <summary>
        /// Copies foreign keys and table data to current instance
        /// </summary>
        /// <param name="msg">CopyFrom Message</param>
        public void Copy(Message msg)
        {
            Id = msg.Id;
            Sender.Copy(msg.Sender);
            Receiver.Copy(msg.Receiver);
            SenderId = msg.SenderId;
            ReceiverId = msg.ReceiverId;
            Text = msg.Text;
            TimeStamp = msg.TimeStamp;
            IsRead = msg.IsRead;
        }
    }
}