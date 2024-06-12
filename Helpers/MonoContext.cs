using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Infrastructure.Helpers
{
	public class MonoContext : MonoBehaviour
	{
		private static MonoContext _context;

		static MonoContext()
		{
			EnsureContext();
		}

		internal static CoroutineHandle Execute(IList<YieldInstruction> instructions, Action onSuccess,
			Action onStopped)
		{
			EnsureContext();
			return new CoroutineHandle(_context.StartCoroutine(Routine(instructions, onSuccess)), _context, onStopped);
		}

		private static IEnumerator Routine(IList<YieldInstruction> instructions, Action onSuccess)
		{
			foreach (var instruction in instructions)
			{
				yield return instruction;
			}

			onSuccess?.Invoke();
		}

		private static void EnsureContext()
		{
			if (_context == null)
			{
				_context = new GameObject("MonoContextHelper").AddComponent<MonoContext>();
			}
		}
	}
}