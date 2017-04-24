using System;

namespace ShadowsOfShadows.Entities
{
	public class Character : Entity, IInteractable, IUpdateable
	{
		public string Name { get; }

		public Character(string name)
		{
			this.Name = name;
		}

		public void Interact()
		{

		}

		public void Update(TimeSpan deltaTime)
		{

		}
	}
}
