using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PusherRealtimeChat.WebAPI.Models
{
    public class ChatMessage
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}