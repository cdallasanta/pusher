using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherRealtimeChat.WebAPI.Models;
using PusherServer;
using System.Net.Http;
using System.Web.Http;

namespace PusherRealtimeChat.WebAPI.Controllers
{
    public class MessagesController : ApiController
    {
        private static List<ChatMessage> messages =
            new List<ChatMessage>()
            {
                new ChatMessage
                {
                    AuthorName = "Chris",
                    Text = "Hello there."
                },
                new ChatMessage
                {
                    AuthorName = "Kristin",
                    Text = "Hello back."
                }
            };

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                messages);
        }
    }
}