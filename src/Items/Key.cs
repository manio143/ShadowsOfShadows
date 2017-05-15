using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class Key : QuestItem
    {
        public Key(string name, string description) : base(name, "Description " + description)
        {
        }
    }
}
