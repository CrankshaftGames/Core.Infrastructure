using System;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.Extensions
{
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