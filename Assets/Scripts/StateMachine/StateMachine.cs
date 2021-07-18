namespace GameSateMachine
{
    internal sealed class StateMachine
    {
        private GameState[] _gameStates;
        private GameState _currentState;

        public void Init(GameState[] gameStates)
        {
            _gameStates = gameStates;
        }

        public void SetState(TypeStates type)
        {
            if (_currentState is { }) DisableState();
            foreach (var state in _gameStates)
            {
                if (state.Type != type) continue;
                _currentState = state;
                _currentState.gameObject.SetActive(true);
            }
        }

        private void DisableState()
        {
            _currentState.gameObject.SetActive(false);
        }
    }

    public enum TypeStates
    {
        Null,
        MainMenu,
        Gameplay,
        Pause,
        EndGame,
    }
}