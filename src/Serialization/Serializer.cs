using System;
using System.IO;
using System.Linq;

using Microsoft.Xna.Framework;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Serialization
{
    public static class Serializer
    {

        private static Wire.Serializer serializer;
        private static string SaveFolder = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "ShadowsOfShadows",
                        "savedgames");

        static Serializer()
        {
            var renderableSurrogate = Wire.Surrogate.Create<ConsoleRenderable, Tuple<int, Color>>(r => new Tuple<int, Color>(r.symbol, r.color), tup => new ConsoleRenderable(tup.Item1, tup.Item2));
            var options = new Wire.SerializerOptions(versionTolerance: true, preserveObjectReferences: true, surrogates: new [] {renderableSurrogate});
            serializer = new Wire.Serializer(options);
        }

        private static FileStream OpenFile(SaveSlot slot, bool create = false)
        {
            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);
            if (File.Exists(SaveFolder + "/" + slot + ".sav") && create)
                File.WriteAllText(SaveFolder + "/" + slot + ".sav", String.Empty);
            return File.Open(SaveFolder + "/" + slot + ".sav", create ? FileMode.OpenOrCreate : FileMode.Open);
        }

        public static void Save(SaveSlot slot, GameState state)
        {
            try
            {
                using (var stream = OpenFile(slot, true))
                    serializer.Serialize(state, stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}\n{1}", e.GetType(), e.Message);
            }
        }

        public static GameState Load(SaveSlot slot)
        {
            using (var stream = OpenFile(slot))
                return serializer.Deserialize<GameState>(stream);
        }
    }
}
