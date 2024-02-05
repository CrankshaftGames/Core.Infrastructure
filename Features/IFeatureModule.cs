namespace Core.Infrastructure.Features
{
    public interface IFeatureModule
    {
        void Enable();
        void Disable();
    }
}