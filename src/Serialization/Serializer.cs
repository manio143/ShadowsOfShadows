using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

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

        public static void Save(SaveSlot slot, GameState state)
        {
            // TODO Catch exception
            XmlSerializer xsSubmit = new XmlSerializer(typeof(GameState),
                new Type[] {typeof(RegenerationConsumable), typeof(Apple),
                    typeof(Wall), typeof(Chest)}); // TODO Is it necessary to list all the types here?
            var xml = "";

            using (var sww = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, state);
                    xml = sww.ToString();

				var file = new System.IO.StreamWriter(OpenFile(slot, true));
                    file.Write(xml);

                    file.Close();
                }
        }

        public static GameState Load(SaveSlot slot)
        {
            GameState state = null;

            XmlSerializer serializer = new XmlSerializer(typeof(GameState),
                new Type[] { typeof(RegenerationConsumable), typeof(Apple),
                    typeof(Wall), typeof(Chest) }); // As above

			var reader = new StreamReader(OpenFile(slot));
            state = (GameState)serializer.Deserialize(reader);
            reader.Close();

            return state;
        }
    }
}
