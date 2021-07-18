using UnityEngine;
using Zenject;

namespace GameSateMachine
{
    internal sealed class GameEntryPoint : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Constructor(GameState[] states, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _stateMachine.Init(states);
            foreach (var state in states)
            {
                state.Machine = _stateMachine;
            }
        }

        private void Start()
        {
            _stateMachine.SetState(TypeStates.MainMenu);
        }
    }
}