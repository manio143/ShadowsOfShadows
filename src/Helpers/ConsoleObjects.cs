using System;
using System.Linq;
using Microsoft.Xna.Framework;
using SadConsole.GameHelpers;
using SadConsole.Surfaces;
using SadConsole;


namespace ShadowsOfShadows.Helpers
{
    public static class ConsoleObjects
    {
        public static GameObject CreateFromString(string s, Color color = new Color())
        {
            if (color == new Color()) color = Color.White;
            var lines = s.Split('\n');

            var text = new AnimatedSurface("deafult", lines.Max(ss => ss.Length), lines.Length);
            var editor = new SurfaceEditor(text.CreateFrame());
            for (int i = 0; i < lines.Length; i++)
                editor.Print(0, i, lines[i], color);
            return new GameObject(text);
        }

        public static GameObject CreateFromChar(char c, Color color = new Color())
        {
            return CreateFromString(c.ToString());
        }

        public static GameObject CreateBlinkingFromGlyph(int glyph, float duration, Color color = new Color())
        {
            if (color == new Color()) color = Color.White;

            var animation = new AnimatedSurface("anim", 1, 1);
            var editor = new SurfaceEditor(animation.CreateFrame());
            editor.SetGlyph(0, 0, glyph, color);
            animation.CreateFrame();    //empty frame
            animation.AnimationDuration = duration;
            animation.Repeat = true;
            animation.Start();
            return new GameObject(animation);
        }

        public static GameObject CreateFromGlyph(int glyph, Color color = new Color())
        {
            if (color == new Color()) color = Color.White;

            var animation = new AnimatedSurface("anim", 1, 1);
            var editor = new SurfaceEditor(animation.CreateFrame());
            editor.SetGlyph(0, 0, glyph, color);
            return new GameObject(animation);
        }
    }
}

