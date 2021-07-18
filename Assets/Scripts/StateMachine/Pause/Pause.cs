using UnityEngine;

namespace GameSateMachine
{
    internal sealed class Pause : GameState
    {
        public override TypeStates Type => TypeStates.Pause;

        protected override void OnEnable()
        {
            Time.timeScale = 0;
        }

        protected override void OnDisable()
        {

        }

        public void DisablePause()
        {
            Machine.SetState(TypeStates.Gameplay);
        }
    }
}