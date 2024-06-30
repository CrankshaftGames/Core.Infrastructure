using System.Threading.Tasks;

namespace Core.Infrastructure.Features
{
    public abstract class FeatureBase : IFeature
    {
        async Task IFeature.Run()
        {
            var isAvailable = await ValidateInternal();
            if (isAvailable)
            {
                OnStart();
            }
        }

        void IFeature.Terminate()
        {
            OnTerminate();
        }

        protected abstract Task<bool> ValidateInternal();

        protected virtual void OnStart()
        {
        }

        protected virtual void OnTerminate()
        {
        }
    }
}