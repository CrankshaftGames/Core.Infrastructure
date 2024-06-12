using System;
using UnityEngine;

namespace Core.Infrastructure.Helpers
{
	public class CoroutineHandle
	{
		private readonly Coroutine _coroutine;
		private readonly MonoContext _context;
		private Action _onStopped;

		internal CoroutineHandle(Coroutine coroutine, MonoContext context, Action onStopped = null)
		{
			_coroutine = coroutine;
			_context = context;
			_onStopped = onStopped;
		}

		public CoroutineHandle OnStopped(Action action)
		{
			_onStopped = action;
			return this;
		}

		public void Stop()
		{
			_context.StopCoroutine(_coroutine);
			_onStopped?.Invoke();
		}
	}
}