using UnityEngine;

namespace Core.Infrastructure.Extensions
{
	public static class DisposableExtensions
	{
		public static DisposableObjectWrapper AsDisposable(this Object obj)
		{
			return new DisposableObjectWrapper(obj);
		}
	}
}