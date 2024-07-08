using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Infrastructure.Features
{
    internal class FeatureBootstrapper
    {
        private readonly IEnumerable<IFeature> _features;

        internal FeatureBootstrapper(IFeaturesProvider featuresProvider)
        {
            _features = featuresProvider.GetFeatures();
        }

        internal async void RunFeatures()
        {
            var groups = _features.GroupBy(
                GetOrder,
                p => p,
                (order, features) => new { Features = features });

            foreach (var group in groups)
            {
                await Task.WhenAll(group.Features.Select(RunFeature));
            }
        }

        private static async Task RunFeature(IFeature feature)
        {
            try
            {
                await feature.Run();
            }
            catch (Exception e)
            {
                feature.Terminate();
                Debug.LogException(e);
            }
        }

        private static int GetOrder(IFeature feature)
        {
            var attribute = feature.GetType().GetCustomAttribute<FeatureOrderAttribute>();
            return attribute?.Order ?? 0;
        }
    }
}