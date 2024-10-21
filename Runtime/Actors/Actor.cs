using System;
using UnityEngine;

namespace Core.Infrastructure.Actors
{
    public abstract class Actor<TEntity> : MonoBehaviour where TEntity : Entity, new()
    {
        protected TEntity Entity;

        private void Awake()
        {
            Entity = new TEntity();
        }

        private void OnDestroy()
        {
            (Entity as IDisposable)?.Dispose();
        }
    }
}