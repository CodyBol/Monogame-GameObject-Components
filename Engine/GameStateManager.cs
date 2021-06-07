using System.Collections.Generic;

namespace Engine
{
    public class GameStateManager
    {
        private string _currentState;
        private Dictionary<string, GameState> _gameStates;

        public GameStateManager()
        {
            _gameStates = new Dictionary<string, GameState>();
        }

        public GameState CurrentState
        {
            get { return _gameStates[_currentState]; }
        }

        public void AddState(string stateName, GameState gameState)
        {
            _gameStates.Add(stateName, gameState);
        }

        public void ChangeState(string toState, bool resetState = false, bool initialize = false)
        {
            if (resetState)
            {
                CurrentState.Reset();
            }

            _currentState = toState;
            
            if (initialize || !CurrentState.initialized)
            {
                CurrentState.Initialize();
            }
        }
    }
}