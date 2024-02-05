namespace Core.Infrastructure.Features
{
    public sealed class FeaturesBootstrapper
    {
        protected readonly IFeaturesProvider _featuresProvider;

        protected FeaturesBootstrapper(IFeaturesProvider featureCollectionProvider)
        {
            _featuresProvider = featureCollectionProvider;
        }

        public void RunFeatures()
        {
            foreach (var feature in _featuresProvider.GetFeatures())
                if (feature.IsAvailable)
                    feature.Run();
        }
    }
}