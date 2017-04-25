using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public class Door : Openable
    {
        public Door(IRenderable rendarable, int lockDificulty) : base(rendarable, lockDificulty)
        {
        }

        public override void Interact()
        {
            if(CheckOpened())
            {
                // generation of new Room TODO: generetion including door position
                // Generator.RoomGenerator.Generate(this.GetHashCode()
                Transform.Collision.TurnOff();
            }
        }
    }
}
