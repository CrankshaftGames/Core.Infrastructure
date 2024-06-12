using UnityEngine;

namespace Core.Infrastructure.UI
{
    public class RoutineToken<TResult> : CustomYieldInstruction
    {
        public TResult Result { get; private set; }
        private bool _keepWaiting;
        public override bool keepWaiting => _keepWaiting;

        public void Complete(TResult result)
        {
            Result = result;
            _keepWaiting = false;
        }
    }

    public class RoutineToken : CustomYieldInstruction
    {
        private bool _keepWaiting;
        public override bool keepWaiting => _keepWaiting;

        public void Complete()
        {
            _keepWaiting = false;
        }
    }
}