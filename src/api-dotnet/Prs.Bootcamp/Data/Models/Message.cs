using System.ComponentModel.DataAnnotations;

namespace Prs.Bootcamp.Data.Models;

public class Message
{
    [Required]
    public int Id { get; set; }

    //[Required]
    public int? SenderId { get; set; }
    public User? SenderNavigation { get; set; }

    //[Required]
    public int? ReceiverId { get; set; }
    public User? ReceiverNavigation { get; set; }

    public string Text { get; set; } = string.Empty;

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
        SenderId = msg.SenderId;
        ReceiverId = msg.ReceiverId;
        Text = msg.Text;
        TimeStamp = msg.TimeStamp;
        IsRead = msg.IsRead;

        if (msg.SenderNavigation is not null)
        {
            SenderNavigation?.Copy(msg.SenderNavigation);
        }

        if (msg.ReceiverNavigation is not null)
        {
            ReceiverNavigation?.Copy(msg.ReceiverNavigation);
        }
    }
}
