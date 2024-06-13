using Core.Infrastructure.Features;

namespace Core.Infrastructure
{
	public abstract class EntryPoint
	{
		private readonly FeatureBootstrapper _featureBootstrapper;

		protected EntryPoint(IFeaturesProvider featuresProvider)
		{
			_featureBootstrapper = new FeatureBootstrapper(featuresProvider);
		}

		protected void Initialize()
		{
			_featureBootstrapper.RunFeatures();
		}
	}
}