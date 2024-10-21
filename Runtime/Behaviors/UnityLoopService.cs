using System.Collections.Generic;
using UnityEngine;

namespace Core.Infrastructure.Behaviors
{
    public class UnityLoopService : MonoBehaviour
    {
        private static UnityLoopService _instance;
        private readonly List<IFixedUpdateEventReceiver> _fixedUpdateReceivers = new();

        private readonly List<IUpdateEventReceiver> _updateReceivers = new();

        public static UnityLoopService Instance
        {
            get
            {
                if (_instance == null) _instance = CreateInstance();

                return _instance;
            }
        }

        private void Update()
        {
            foreach (var receiver in _updateReceivers) receiver.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            foreach (var receiver in _fixedUpdateReceivers) receiver.FixedUpdate(Time.fixedDeltaTime);
        }

        private static UnityLoopService CreateInstance()
        {
            var go = new GameObject("UnityLoopService");
            DontDestroyOnLoad(go);
            return go.AddComponent<UnityLoopService>();
        }

        public void AddEventReceiver(IEventReceiver receiver)
        {
            if (receiver is IUpdateEventReceiver updateReceiver) _updateReceivers.Add(updateReceiver);
        }

        public void RemoveEventReceiver(IEventReceiver receiver)
        {
            if (receiver is IUpdateEventReceiver updateReceiver) _updateReceivers.Remove(updateReceiver);
        }
    }
}