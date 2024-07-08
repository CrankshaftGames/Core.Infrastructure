using System;

namespace Core.Infrastructure.Features
{
    public class FeatureOrderAttribute : Attribute
    {
        public int Order { get; private set; }

        public FeatureOrderAttribute(int order)
        {
            Order = order;
        }
    }
}