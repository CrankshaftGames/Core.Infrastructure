using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Infrastructure.Controllers
{
    public abstract class Controller
    {
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
            foreach (var disposable in _disposablesList) disposable.Dispose();

            _disposablesList.Clear();

            _controllerTask?.Dispose();
            OnTerminate();
        }

        protected void AddDisposable(IDisposable disposable)
        {
            if (!_disposablesList.Contains(disposable)) _disposablesList.Add(disposable);
        }

        protected virtual void OnTerminate()
        {
        }
    }
}