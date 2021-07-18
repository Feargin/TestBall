using UnityEngine;

namespace GameSateMachine
{
    internal sealed class Gameplay : GameState
    {
        public override TypeStates Type => TypeStates.Gameplay;

        protected override void OnEnable()
        {
            Time.timeScale = 1;
        }

        protected override void OnDisable()
        {

        }

        public void EnablePause()
        {
            Machine.SetState(TypeStates.Pause);
        }
    }
}