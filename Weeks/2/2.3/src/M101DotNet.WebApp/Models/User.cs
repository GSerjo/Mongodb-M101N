using System;
using MongoDB.Bson;

namespace M101DotNet.WebApp.Models
{
    public class User
    {
        // XXX WORK HERE
        // create an object suitable for insertion into the user collection
        // The homework instructions will tell you the schema that the documents 
        // must follow. Make sure to include Name and Email properties.

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}