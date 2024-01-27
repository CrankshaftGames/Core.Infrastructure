using System.Collections.Generic;

namespace Core.Infrastructure.Features
{
    public interface IFeaturesProvider
    {
        IEnumerable<IFeature> GetFeatures();
    }
}
