using Core.Infrastructure.Actors;

namespace Core.Infrastructure.Behaviours
{
    public abstract class ActorBehaviour : IEventReceiver
    {
        protected Actor Actor { get; private set; }

        internal void AddToActor(Actor actor)
        {
            Actor = Actor;
            OnAddedToActor();
        }

        internal void RemoveFromActor()
        {
            OnRemovedFromActor();
        }
        
        protected virtual void OnAddedToActor()
        {
        }

        protected virtual void OnRemovedFromActor()
        {
        }
    }
}