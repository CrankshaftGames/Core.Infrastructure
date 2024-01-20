using System.Collections.Generic;
using Core.Infrastructure.Features;

namespace Assets.Core.Infrastructure.Features
{
    public interface IFeaturesProvider
    {
        IEnumerable<IFeature> GetFeatures();
    }
}
