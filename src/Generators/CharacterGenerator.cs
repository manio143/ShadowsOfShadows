using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using ShadowsOfShadows.Entities;

namespace ShadowsOfShadows.Generators
{
    internal class CharacterGenerator
    {
        private Bernoulli monsterOrNPCDistribution;
        private DiscreteUniform monsterDistribution;
        private DiscreteUniform npcDistribution;

        private Type[] npcTypes;
        private Type[] monsterTypes;

        public CharacterGenerator()
        {
            var assembly = GetType().Assembly;

            monsterTypes = assembly.GetTypes().Where(type => type.IsClass && (type.IsSubclassOf(typeof(Monster)) || type == typeof(Monster)) && !type.IsAbstract).ToArray();
            npcTypes = assembly.GetTypes().Where(type => type.IsClass && (type == typeof(NPC) || type.IsSubclassOf(typeof(NPC))) && !type.IsAbstract).ToArray();

            monsterDistribution = new DiscreteUniform(0, monsterTypes.Length - 1);
            npcDistribution = new DiscreteUniform(0, npcTypes.Length - 1);
            monsterOrNPCDistribution = new Bernoulli(0.80);
        }

        public Character GenerateCharacter()
        {
            var isMonster = monsterOrNPCDistribution.Sample();
            if (isMonster == 1)
                return GenerateMonster();
            else
                return GenerateNPC();
        }

        private Monster GenerateMonster()
        {
            var index = monsterDistribution.Sample();
            return (Monster)Activator.CreateInstance(monsterTypes[index]);
        }

        private NPC GenerateNPC()
        {
            var index = npcDistribution.Sample();
            return (NPC)Activator.CreateInstance(npcTypes[index]);
        }
    }
}
