using System.Collections.Generic;
using UnityEngine;

namespace Core.Infrastructure.Behaviours
{
	public class UnityLoopService : MonoBehaviour
	{
		private static UnityLoopService _instance;

		public static UnityLoopService Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = CreateInstance();
				}

				return _instance;
			}
		}

		private List<IUpdateReceiver> _updateReceivers = new List<IUpdateReceiver>();

		private static UnityLoopService CreateInstance()
		{
			var go = new GameObject("UnityLoopService");
			DontDestroyOnLoad(go);
			return go.AddComponent<UnityLoopService>();
		}

		public void AddEventReceiver(IEventReceiver receiver)
		{
			if (receiver is IUpdateReceiver updateReceiver)
			{
				_updateReceivers.Add(updateReceiver);
			}
		}

		public void RemoveEventReceiver(IEventReceiver receiver)
		{
			if (receiver is IUpdateReceiver updateReceiver)
			{
				_updateReceivers.Remove(updateReceiver);
			}
		}

		private void Update()
		{
			foreach (var updateReceiver in _updateReceivers)
			{
				updateReceiver.Update(Time.deltaTime);
			}
		}
	}
}
