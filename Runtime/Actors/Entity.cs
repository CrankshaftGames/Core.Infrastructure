using System;
using System.Collections.Generic;
using Core.Infrastructure.Behaviors;

namespace Core.Infrastructure.Actors
{
    public abstract class Entity : IDisposable
    {
        private readonly Dictionary<Type, EntityBehavior> _behaviours = new();

        protected Entity()
        {
            EntitiesRegistry.RegisterEntity(this);
        }

        protected abstract void BuildEntity();

        void IDisposable.Dispose()
        {
            EntitiesRegistry.UnregisterEntity(this);
        }

        public void AddBehaviour<TBehaviour>() where TBehaviour : EntityBehavior, new()
        {
            var type = typeof(TBehaviour);
            var behaviour = new TBehaviour();
            if (!_behaviours.TryAdd(type, behaviour))
            {
                throw new InvalidOperationException($"Behaviour of type {type.Name} already exist");
            }

            behaviour.AddToEntity(this);
        }

        public void RemoveBehaviour<TBehaviour>() where TBehaviour : EntityBehavior
        {
            var type = typeof(TBehaviour);
            if (!_behaviours.Remove(type, out var behaviour))
            {
                throw new InvalidOperationException($"Component of type {type.Name} does not exist");
            }

            _behaviours.Remove(type);

            behaviour.RemoveFromEntity();
        }

        public void Dispose()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.Value.RemoveFromEntity();
            }

            _behaviours.Clear();
        }
    }
}