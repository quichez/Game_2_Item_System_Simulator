using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace AbilityFactoryReflection
{
    public abstract class Ability
    {
        public Sprite Icon { get; protected set; }
        public abstract string Name { get; }

    }

    public abstract class AbilityActive: Ability
    {
        public abstract void Process();
        public abstract void End();
    }

    public static class AbilityFactory
    {
        private static Dictionary<string, Type> activeAbilitiesByName;

        private static bool IsInitialized => activeAbilitiesByName != null;

        public static void InitializeFactory()
        {
            if (IsInitialized)
                return;

            activeAbilitiesByName = new Dictionary<string, Type>();

            var activeAbilityTypes = Assembly.GetAssembly(typeof(AbilityActive)).GetTypes()
                .Where(myType => !myType.IsAbstract && myType.IsSubclassOf(typeof(AbilityActive)));

            foreach (var type in activeAbilityTypes)
            {
                var temp = Activator.CreateInstance(type) as AbilityActive;
                activeAbilitiesByName.Add(temp.Name, type);
            }


        }

        public static AbilityActive GetAbilityActive(string abilityType)
        {
            InitializeFactory();
            if(activeAbilitiesByName.ContainsKey(abilityType))
            {
                Type type = activeAbilitiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as AbilityActive;
                return ability;
            }
            return null;
        }

        public static void BuffSkill(AbilityActive target, int mult)
        {

        }

        internal static IEnumerable<string> GetAbilityActiveNames()
        {
            InitializeFactory();
            return activeAbilitiesByName.Keys;
        }
    }

}
