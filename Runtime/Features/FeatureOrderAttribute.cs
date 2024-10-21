using System;

namespace Core.Infrastructure.Features
{
    public class FeatureOrderAttribute : Attribute
    {
        public FeatureOrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; private set; }
    }
}