using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Thought
    {
        public static List<Thought> Thoughts = new List<Thought>
        {
            new Thought
                {
                    Id = 1, Name = "Learn C# 4.0", Topic = Topic.Topics.Find(topic => topic.Name == "Work")
                },
            new Thought
                {
                    Id = 2, Name = "Build a Killer Web App", Topic = Topic.Topics.Find(topic => topic.Name == "Home")
                }
        };

        public int Id { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }
    }
}