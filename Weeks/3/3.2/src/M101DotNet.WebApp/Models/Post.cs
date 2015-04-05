using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace M101DotNet.WebApp.Models
{
    public class Post
    {

        public Post()
        {
            Tags = new List<string>();
            Comments = new List<Comment>();
        }

        // XXX WORK HERE
        // add in the appropriate properties for a post
        // The homework instructions contain the schema.
        public ObjectId Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public List<Comment> Comments { get; set; }
    }
}