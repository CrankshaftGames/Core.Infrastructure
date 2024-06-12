using Core.Infrastructure.Features;

namespace Core.Infrastructure
{
	public abstract class EntryPoint
	{
		private readonly FeatureBootstrapper _featureBootstrapper;

		protected EntryPoint(FeatureBootstrapper featureBootstrapper)
		{
			_featureBootstrapper = featureBootstrapper;
		}

		protected void Initialize()
		{
			_featureBootstrapper.RunFeatures();
		}
	}
}