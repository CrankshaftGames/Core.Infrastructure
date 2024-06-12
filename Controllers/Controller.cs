using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Infrastructure.Controllers
{
	public abstract class Controller
	{
		private readonly List<Controller> _children = new();
		private readonly List<IDisposable> _disposablesList = new();
		private Task _controllerTask;

		protected Task Run()
		{
			_controllerTask = Running();
			return _controllerTask;
		}

		protected abstract Task Running();
		
		protected void Terminate()
		{
			foreach (var disposable in _disposablesList)
			{
				disposable.Dispose();
			}

			_disposablesList.Clear();

			foreach (var child in _children)
			{
				child.Terminate();
			}

			_children.Clear();
			_controllerTask.Dispose();
			OnTerminate();
		}

		protected void AddDisposable(IDisposable disposable)
		{
			if (!_disposablesList.Contains(disposable))
			{
				_disposablesList.Add(disposable);
			}
		}

		protected void AddChildController<TController>(TController controller)
			where TController : Controller
		{
			_children.Add(controller);
			controller.Run();
			Debug.LogWarning($"Added {controller.GetType().Name}");
		}

		protected void RemoveChildController<T>(T controller) where T : Controller
		{
			controller.Terminate();
			_children.Remove(controller);
		}

		protected virtual void OnTerminate()
		{
		}
	}
}