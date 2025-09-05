using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TK.Ch02
{
    public enum GameState
    {
        Login,
        InGame,
    }

    public class GameManager : MonoBehaviour
    {
        private static GameManager m_Instance;
        public static GameManager Instance()
        {
            if(m_Instance == null)
            {
                m_Instance = FindFirstObjectByType<GameManager>();
            }

            return m_Instance;
        }

        private GameState m_GameState = GameState.Login;
        public event Action<GameState> OnChangeGameState;

        private void Start()
        {
            SetGameState(GameState.Login);
        }

        public void SetGameState(GameState newState)
        {
            if(m_GameState == newState)
            {
                return;
            }

            m_GameState = newState;
            OnChangeGameState?.Invoke(newState);
        }
    }
}
