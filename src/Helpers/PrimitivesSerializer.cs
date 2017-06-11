namespace ShadowsOfShadows.Helpers
{
    using YamlDotNet.Core;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;
    using Microsoft.Xna.Framework;
    using System.Linq;
    public class PrimitivesConverter : IYamlTypeConverter
    {
        private readonly bool jsonCompatible;

        public PrimitivesConverter()
        {
            this.jsonCompatible = false;
        }

        public bool Accepts(System.Type type)
        {
            return type == typeof(Point) || type == typeof(Rectangle);
        }
        private string GetScalarValue(IParser parser)
        {
            var value = ((Scalar)parser.Current).Value;
            parser.MoveNext();
            return value;
        }
        public object ReadYaml(IParser parser, System.Type type)
        {
            var str = GetScalarValue(parser);
            var arr = str.Split(new[] { ';' }).Select(s => int.Parse(s)).ToArray();
            if (type == typeof(Point))
            {
                return new Point(arr[0], arr[1]);
            }
            else if (type == typeof(Rectangle))
            {
                return new Rectangle(arr[0], arr[1], arr[2], arr[3]);
            }
            throw new System.ApplicationException("Invalid parser usage");
        }

        public void WriteYaml(IEmitter emitter, object value, System.Type type)
        {
            if (type == typeof(Point))
            {
                var point = (Point)value;
                emitter.Emit(new Scalar(null, null, $"{point.X};{point.Y}", jsonCompatible ? ScalarStyle.DoubleQuoted : ScalarStyle.Any, true, false));
            }
            else if (type == typeof(Rectangle))
            {
                var rect = (Rectangle)value;
                emitter.Emit(new Scalar(null, null, $"{rect.X};{rect.Y};{rect.Width};{rect.Height}", jsonCompatible ? ScalarStyle.DoubleQuoted : ScalarStyle.Any, true, false));
            }

        }
    }
}