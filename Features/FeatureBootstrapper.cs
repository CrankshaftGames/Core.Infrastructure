using System;
using System.Collections.Generic;
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
			foreach (var feature in _features)
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
		}
	}
}