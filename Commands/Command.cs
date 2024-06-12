using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Infrastructure.Commands
{
	public abstract class AsyncCommand
	{
		public Task Execute()
		{
			try
			{
				return ExecuteInternal();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				throw;
			}
		}

		protected abstract Task ExecuteInternal();
	}
	
	public abstract class AsyncCommand<T>
	{
		public Task<T> Execute()
		{
			try
			{
				return ExecuteInternal();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				throw;
			}
		}
		
		protected abstract Task<T> ExecuteInternal();
	}

	public abstract class Command
	{
		public void Execute()
		{
			try
			{
				ExecuteInternal();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				throw;
			}
		}

		protected abstract void ExecuteInternal();
	}
}