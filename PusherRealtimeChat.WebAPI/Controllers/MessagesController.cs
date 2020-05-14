using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherRealtimeChat.WebAPI.Models;
using PusherServer;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PusherRealtimeChat.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MessagesController : ApiController
    {
        private static List<ChatMessage> messages =
            new List<ChatMessage>()
            {
                new ChatMessage
                {
                    authorTwitterHandle = "ChrisDallaSanta",
                    Text = "Hello there."
                },
                new ChatMessage
                {
                    authorTwitterHandle = "9ine6ix42330261",
                    Text = "Hello back."
                }
            };

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                messages);
        }

        public HttpResponseMessage Post(ChatMessage message)
        {
            if (message == null || !ModelState.IsValid)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    "Invalid Input"
                    );
            }
            messages.Add(message);

            var pusher = new Pusher(
                "1001149",
                "c3645ffe81e6237e79ef",
                "b6848be40e19184e03aa",
                    new PusherOptions
                    {
                        Cluster = "us3"
                    }
                );
            pusher.TriggerAsync(
                channelName: "messages",
                eventName: "new_message",
                data: new
                {
                    authorTwitterHandle = message.authorTwitterHandle,
                    Text = message.Text
                });

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}