using System;
using System.Collections.Generic;

namespace Core.Infrastructure.Events
{
	public abstract class GameEvent
	{
	}

	public abstract class GameEvent<T> : GameEvent
	{
		private readonly List<Action<T>> _listeners;

		protected GameEvent()
		{
			_listeners = new List<Action<T>>(64);
		}

		public void AddListener(Action<T> listener)
		{
			if (!_listeners.Contains(listener))
			{
				_listeners.Add(listener);
			}
		}

		public void RemoveListener(Action<T> listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}

		public void Dispatch(T eventData)
		{
			foreach (var listener in _listeners)
			{
				listener?.Invoke(eventData);
			}
		}
	}

	public abstract class GameEvent<T1, T2> : GameEvent
	{
		private readonly List<Action<T1, T2>> _listeners;

		protected GameEvent()
		{
			_listeners = new List<Action<T1, T2>>(64);
		}

		public void AddListener(Action<T1, T2> listener)
		{
			if (!_listeners.Contains(listener))
			{
				_listeners.Add(listener);
			}
		}

		public void RemoveListener(Action<T1, T2> listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}

		public void Dispatch(T1 eventData1, T2 eventData2)
		{
			foreach (var listener in _listeners)
			{
				listener?.Invoke(eventData1, eventData2);
			}
		}
	}

	public abstract class GameEvent<T1, T2, T3> : GameEvent
	{
		private readonly List<Action<T1, T2, T3>> _listeners;

		protected GameEvent()
		{
			_listeners = new List<Action<T1, T2, T3>>(64);
		}

		public void AddListener(Action<T1, T2, T3> listener)
		{
			if (!_listeners.Contains(listener))
			{
				_listeners.Add(listener);
			}
		}

		public void RemoveListener(Action<T1, T2, T3> listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}

		public void Dispatch(T1 eventData1, T2 eventData2, T3 eventData3)
		{
			foreach (var listener in _listeners)
			{
				listener?.Invoke(eventData1, eventData2, eventData3);
			}
		}
	}
}