using TK.DI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK.Ch02
{
    /// <summary>
    /// 챕터2 인게임 UI :: 버튼을 누르면 점수 실시간으로 DB 반영
    /// </summary>
    public class UIGetScore : ConUI
    {
        [Inject] private DataManager m_DataManager;

        [SerializeField] TextMeshProUGUI m_NicknameText;
        [SerializeField] TextMeshProUGUI m_ScoreText;
        [SerializeField] Button m_GetScoreButton;
        [SerializeField] Button m_LogoutButton;

        protected override void Awake()
        {
            base.Awake();
            m_GetScoreButton.onClick.AddListener(OnClickGetScoreButton);
            m_LogoutButton.onClick.AddListener(OnClickLogoutButton);

            GameManager.Instance().OnChangeGameState += (newState) => 
            {
                switch (newState)
                {
                    case GameState.Login:
                        SetActivePanel(false);
                        break;
                    case GameState.InGame:
                        SetActivePanel(true);
                        break;
                    default:
                        break;
                }
            };
        }

        public async void OnClickGetScoreButton()
        {
            m_GetScoreButton.interactable = false;

            bool success = await m_DataManager.SaveUserData();

            if(success == true)
            {
                Debug.Log("점수 늘리기 : 성공"); 
            }
            else
            {
                Debug.Log("점수 늘리기 : 실패");
            }

            m_GetScoreButton.interactable = true;
        }

        public void OnClickLogoutButton()
        {

        }
    }

}
