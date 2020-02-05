using System;

namespace Twitter.BL.Objects
{
    public class Tweet
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public string ShortDateString { get; set; }

    }
}
