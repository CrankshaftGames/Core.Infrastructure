using System;
using System.Collections.Generic;
using Core.Infrastructure.Behaviours;

namespace Core.Infrastructure.Actors
{
    public abstract class Actor : IDisposable
    {
        private readonly IDictionary<Type, ActorBehaviour> _behaviours;
        private readonly UnityLoopService _unityLoopService;

        protected Actor(UnityLoopService unityLoopService)
        {
            _behaviours = new Dictionary<Type, ActorBehaviour>();
            _unityLoopService = unityLoopService;
        }

        public void AddBehaviour<TBehaviour>(TBehaviour behaviour) where TBehaviour : ActorBehaviour
        {
            var type = typeof(TBehaviour);
            if (!_behaviours.TryAdd(type, behaviour))
            {
                throw new InvalidOperationException($"Behaviour of type {type.Name} already exist");
            }

            behaviour.AddToActor(this);
        }

        public void RemoveBehaviour<TBehaviour>() where TBehaviour : ActorBehaviour
        {
            var type = typeof(TBehaviour);
            if (!_behaviours.Remove(type, out var behaviour))
            {
                throw new InvalidOperationException($"Component of type {type.Name} does not exist");
            }

            _unityLoopService.RemoveEventReceiver(behaviour);
            _behaviours.Remove(type);

            behaviour.RemoveFromActor();
        }

        public void Dispose()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.Value.RemoveFromActor();
            }

            _behaviours.Clear();
        }
    }
}