using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Core.Infrastructure.Actors
{
    public static class EntitiesRegistry
    {
        private static readonly HashSet<Entity> Entities = new();

        public static void RegisterEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public static void UnregisterEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public static IEnumerable<Entity> GetEntities()
        {
            return Entities;
        }

        [MenuItem("Tools/Entities/Diagnose")]
        private static void Diagnose()
        {
            Debug.Log($"Total entities count: {Entities.Count}\n{string.Join(", ", Entities.Select(e => e.GetType().Name))}");
        }
    }
}