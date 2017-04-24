using System;

namespace ShadowsOfShadows.Entities
{
	public interface IUpdateable
	{
		void Update(TimeSpan DeltaTime);
	}
}
