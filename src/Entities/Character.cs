using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Entities
{
	public class Character : Entity, IInteractable, IUpdateable
	{
		public string Name { get; }

		public List<Item> Equipment { get; }

		public Character(string name)
		{
			this.Name = name;
			this.Equipment = new List<Item>();
		}

		public Character(string name, List<Item> equipment) : this(name)
		{
			this.Equipment = equipment;
		}


		public void Interact()
		{

		}

		public void Update(TimeSpan deltaTime)
		{

		}
	}
}
