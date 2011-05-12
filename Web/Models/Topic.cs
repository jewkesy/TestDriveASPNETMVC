using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public Color Colour { get; set; }
        public string Name { get; set; }

        public static List<Topic> Topics = new List<Topic>
        {
            new Topic {Id = 1, Colour = Color.Red, Name = "Work"},                                          
            new Topic {Id = 2, Colour = Color.Blue, Name = "Home"}
        };

        public override bool Equals(object obj)
        {
            //reference equality check
            //if (ReferenceEquals(this, obj)) return true;
            //type equality check
            //if (obj.GetType() != typeof (Topic)) return false;

            var other = obj as Topic;

            return other.Id == Id
                   && other.Colour.Equals(Colour)
                   && Equals(other.Name, Name);
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id; //required for assisting with collections
        }

        public string ColourInWebHex()
        {
            return ColorTranslator.ToHtml(Colour);
            throw new NotImplementedException();
        }
    }
}