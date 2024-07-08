using System;
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

        private readonly List<IUpdateReceiver> _updateReceivers = new();
        private readonly List<IFixedUpdateReceiver> _fixedUpdateReceivers = new();

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
            foreach (var receiver in _updateReceivers)
            {
                receiver.Update(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            foreach (var receiver in _fixedUpdateReceivers)
            {
                receiver.FixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}