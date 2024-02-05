using System;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.Helpers
{
    public static class DisposableExtensions
    {
        public static DisposableObjectWrapper AsDisposable(this Object obj)
        {
            return new DisposableObjectWrapper(obj);
        }
    }

    public class DisposableObjectWrapper : IDisposable
    {
        private Object _obj;

        public DisposableObjectWrapper(Object obj)
        {
            _obj = obj;
        }

        public void Dispose()
        {
            if (_obj == null) return;

            Object.Destroy(_obj);
            _obj = null;
        }
    }
}