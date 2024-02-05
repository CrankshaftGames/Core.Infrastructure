using System;

namespace Core.Infrastructure.Features
{
    public interface IFeature : IDisposable
    {
        bool IsAvailable { get; }
        void Run();
    }
}