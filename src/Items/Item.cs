using System;

namespace ShadowsOfShadows.Items
{
	public abstract class Item
	{
	    public abstract AllowedItem Allowed { get; }

	    public virtual bool IsLike(Item item)
	    {
	        return false;
	    }
	}
}
