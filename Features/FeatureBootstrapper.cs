using System.Collections.Generic;
using Assets.Core.Infrastructure.Features;

namespace Core.Infrastructure.Features
{
	public abstract class FeatureBootstrapper
	{
        protected readonly IFeaturesProvider _featureCollectionProvider;

        protected FeatureBootstrapper(IFeaturesProvider featureCollectionProvider)
		{
            _featureCollectionProvider = featureCollectionProvider;
        }

		public void RunFeatures()
		{
			foreach (var feature in _featureCollectionProvider.GetFeatures())
			{
				if (feature.IsAvailable)
				{
					feature.Run();
				}
			}
		}
	}
}