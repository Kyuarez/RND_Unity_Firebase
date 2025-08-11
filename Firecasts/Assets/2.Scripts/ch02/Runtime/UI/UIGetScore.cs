using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK.Ch02
{
    /// <summary>
    /// 챕터2 인게임 UI :: 버튼을 누르면 점수 실시간으로 DB 반영
    /// </summary>
    public class UIGetScore : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_NicknameText;
        [SerializeField] Button m_GetScoreButton;
        [SerializeField] Button m_LogoutButton;

        private void Awake()
        {
            m_GetScoreButton.onClick.AddListener(OnClickGetScoreButton);
            m_LogoutButton.onClick.AddListener(OnClickLogoutButton);
        }

        public void OnClickGetScoreButton()
        {

        }

        public void OnClickLogoutButton()
        {

        }
    }

}
