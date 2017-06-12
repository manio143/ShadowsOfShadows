using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Helpers;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Entities
{
    public class Door : Openable
    {
		public Door() : this(Point.Zero) { }

		public bool generateRoom {get;set;}

		public Door(Point position, bool generateRoom = false) : base(new ConsoleRenderable('|'), 0)
        {
			Transform.Position = position;
			if(!generateRoom)
				Transform.Collision.TurnOff();
			this.generateRoom = generateRoom;
        }

        public override void Interact()
        {
			if(generateRoom && CheckOpened())
            {
				generateRoom = false;
				var room = Screen.MainConsole.RoomGenerator.GenerateRoom ();
				Screen.MainConsole.CurrentRooms.Add (room);
                Transform.Collision.TurnOff();
            }
        }
    }
}
