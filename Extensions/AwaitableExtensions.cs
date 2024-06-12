using UnityEngine;

namespace Core.Infrastructure.Extensions
{
	public static class AwaitableExtensions
	{
		public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation operation)
		{
			return new AsyncOperationAwaiter(operation);
		}
	}
}