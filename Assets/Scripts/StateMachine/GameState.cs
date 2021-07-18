using UnityEngine;

namespace GameSateMachine
{
    public abstract class GameState : MonoBehaviour
    {
        public abstract TypeStates Type { get; }
        private StateMachine _machine;

        internal StateMachine Machine
        {
            get => _machine;
            set { _machine ??= value; }
        }

        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}