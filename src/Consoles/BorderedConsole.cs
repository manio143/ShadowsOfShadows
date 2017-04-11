using System;

using SadConsole;

using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Consoles
{
	public class BorderedConsole : SadConsole.Console
	{
		SadConsole.Surfaces.BasicSurface borderSurface;

		public BorderedConsole (int width, int height)
			:base(width-2, height-2)
		{
			borderSurface = new SadConsole.Surfaces.BasicSurface (width, height);

			var editor = new SadConsole.Surfaces.SurfaceEditor (borderSurface);
			var box = SadConsole.Shapes.Box.GetDefaultBox ();
			box.Width = borderSurface.Width;
			box.Height = borderSurface.Height;
			box.Draw (editor);

			base.Renderer.Render(borderSurface);
		}

		public string Header { get; set; }

		public override void Draw(System.TimeSpan delta)
		{
			Global.DrawCalls.Add(new DrawCallSurface(borderSurface, this.relativePosition - new Point(1), UsePixelPositioning));

			base.Draw (delta);
		}
	}
}

