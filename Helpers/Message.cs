using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Helpers
{
    public enum MessageType
    {
        success = 0
              ,
        info = 1
              ,
        error = 2
            ,
        warning = 3
    }

    public class Message
    {


        public Message()
        {

        }
        public Message(string title, string description, MessageType type)
        {
            Title = title;
            Description = description;
            Type = type;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public MessageType Type { get; set; }
    }
}