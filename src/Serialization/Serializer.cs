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
        public static void Save(SaveSlot slot, GameState state)
        {
            // TODO Catch exception
            XmlSerializer xsSubmit = new XmlSerializer(typeof(GameState),
                new Type[] { typeof(RegenerationConsumable), typeof(Apple),
                    typeof(Wall), typeof(Chest)}); // TODO Is it necessary to list all the types here?
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, state);
                    xml = sww.ToString();

                    System.IO.StreamWriter file = new System.IO.StreamWriter("../../../savedgames/" + slot + ".sav");
                    file.Write(xml);

                    file.Close();
                }
            }
        }

        public static GameState loadGameState(SaveSlot slot)
        {
            GameState state = null;
            string path = "../../../savedgames/" + slot + ".sav";

            XmlSerializer serializer = new XmlSerializer(typeof(GameState),
                new Type[] { typeof(RegenerationConsumable), typeof(Apple),
                    typeof(Wall), typeof(Chest) }); // As above

            StreamReader reader = new StreamReader(path);
            state = (GameState)serializer.Deserialize(reader);
            reader.Close();

            return state;
        }
    }
}
