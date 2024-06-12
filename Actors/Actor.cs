using System;
using System.Collections.Generic;
using Core.Infrastructure.Behaviours;

namespace Core.Infrastructure.Actors
{
	public abstract class Actor
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

			_unityLoopService.AddEventReceiver(behaviour);
		}

		public void RemoveBehaviour<TBehaviour>() where TBehaviour : ActorBehaviour
		{
			var type = typeof(TBehaviour);
			if (!_behaviours.TryGetValue(type, out var behaviour))
			{
				throw new InvalidOperationException($"Component of type {type.Name} does not exist");
			}

			_unityLoopService.RemoveEventReceiver(behaviour);
			_behaviours.Remove(type);
		}
	}
}
