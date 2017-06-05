using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Linq;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Serialization
{
    public static class Serializer
    {
        private static string SaveFolder = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "ShadowsOfShadows",
                        "savedgames");

		private static FileStream OpenFile(SaveSlot slot, bool create = false)
		{
			if (!Directory.Exists (SaveFolder))
				Directory.CreateDirectory (SaveFolder);
			return File.Open (SaveFolder + "/" + slot + ".sav", create ? FileMode.OpenOrCreate : FileMode.Open);
		}

		private static Type[] GetAllTypes()
		{
            return typeof(Serializer).Assembly.GetTypes()
                .Where(t => t.Namespace.Contains("Entities")
                    || t.Namespace.Contains("Item")
                    || t.Namespace.Contains("Physics")
                    || t.Namespace.Contains("Helpers")
                    || t == typeof(TestItem)
				).Where(t => !t.IsSealed)
				.Where(t => !t.IsGenericTypeDefinition)
				.Where(t => !t.IsInterface)
				.Where(t => !typeof(System.Attribute).IsAssignableFrom(t)).ToArray ();
		}

        public static void Save(SaveSlot slot, GameState state)
        {
            // TODO Catch exception
			XmlSerializer serializer = new XmlSerializer(typeof(GameState), GetAllTypes());
            var xml = "";

            using (var sww = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
					serializer.Serialize(writer, state);
                    xml = sww.ToString();

				var file = new System.IO.StreamWriter(OpenFile(slot, true));
                    file.Write(xml);

                    file.Close();
                }
        }

        public static GameState Load(SaveSlot slot)
        {
            GameState state = null;

			XmlSerializer serializer = new XmlSerializer(typeof(GameState), GetAllTypes());

			var reader = new StreamReader(OpenFile(slot));
            state = (GameState)serializer.Deserialize(reader);
            reader.Close();

            return state;
        }
    }
}
