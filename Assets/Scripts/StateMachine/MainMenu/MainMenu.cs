using UnityEngine;

namespace GameSateMachine
{
    internal sealed class MainMenu : GameState
    {
        public override TypeStates Type => TypeStates.MainMenu;

        protected override void OnEnable()
        {
            Time.timeScale = 0;
        }

        protected override void OnDisable()
        {

        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Play()
        {
            Machine.SetState(TypeStates.Gameplay);
        }
    }
}