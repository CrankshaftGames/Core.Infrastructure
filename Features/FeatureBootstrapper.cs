using System.Collections.Generic;

namespace Core.Infrastructure.Features
{
	public abstract class FeatureBootstrapper
	{
		private readonly IEnumerable<IFeature> _features;

		protected FeatureBootstrapper(IFeaturesProvider featuresProvider)
		{
			_features = featuresProvider.GetFeatures();
		}

		public async void RunFeatures()
		{
			foreach (var feature in _features)
			{
				var isAvailable = await feature.Initialize();
				if (isAvailable)
				{
					feature.Run();
				}
			}
		}
	}
}