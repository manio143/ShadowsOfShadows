using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

using Microsoft.Xna.Framework;

using YamlDotNet.Serialization;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Serialization
{
    public static class Serializer
    {

        private readonly static string SaveFolder = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "ShadowsOfShadows",
                        "savedgames");

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
                var serializer = new SerializerBuilder()
                    .EnsureRoundtrip()  //save type info
                    .EmitDefaults()     //save default values
                    .WithTypeConverter(new PrimitivesConverter())
                    .Build();

                using (var compression = new GZipStream(OpenFile(slot, true), CompressionMode.Compress))
                using (var writer = new StreamWriter(compression))
                    serializer.Serialize(writer, state);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}\n{1}", e.GetType(), e.Message);
            }
        }

        public static GameState Load(SaveSlot slot)
        {
            var deserializer = new DeserializerBuilder()
                .WithTypeConverter(new PrimitivesConverter())
                .Build();

            using (var compression = new GZipStream(OpenFile(slot), CompressionMode.Decompress))            
            using (var reader = new StreamReader(compression))
                return deserializer.Deserialize<GameState>(reader);
        }

        public static bool SaveExists(SaveSlot slot)
        {
            return File.Exists(SaveFolder + "/" + slot + ".sav");
        }
    }
}
