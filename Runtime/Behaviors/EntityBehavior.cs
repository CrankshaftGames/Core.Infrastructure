using Core.Infrastructure.Actors;

namespace Core.Infrastructure.Behaviors
{
    public abstract class EntityBehavior : IEventReceiver
    {
        protected Entity Entity { get; set; }
        
        protected EntityBehavior()
        {
            
        }

        internal void AddToEntity(Entity entity)
        {
            Entity = Entity;
            OnAddedToEntity();
        }

        internal void RemoveFromEntity()
        {
            OnRemovedFromEntity();
        }

        protected virtual void OnAddedToEntity()
        {
        }

        protected virtual void OnRemovedFromEntity()
        {
        }
    }
}