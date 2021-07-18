using UnityEngine.SceneManagement;
using UnityEngine;

namespace GameSateMachine
{
    internal sealed class GameEnd : GameState
    {
        public override TypeStates Type => TypeStates.EndGame;

        protected override void OnEnable()
        {
            Time.timeScale = 0;
        }

        protected override void OnDisable()
        {

        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}