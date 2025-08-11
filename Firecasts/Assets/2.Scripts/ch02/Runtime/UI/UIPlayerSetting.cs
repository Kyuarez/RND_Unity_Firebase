using System.Threading.Tasks;
using TK.DI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK.Ch02
{
    /// <summary>
    /// 챕터2 :: 닉네임을 Firebase Realtime DB에 등록 및 인증
    /// </summary>
    public class UIPlayerSetting : MonoBehaviour
    {
        [Inject] private DataManager m_DataManager;

        [SerializeField] TMP_InputField m_NicknameField;
        [SerializeField] Button m_RegisterButton;

        private void Awake()
        {
            m_RegisterButton.onClick.AddListener(OnClickRegisterButton);
        }

        /// <summary>
        /// DataManager를 통해, 닉네임 등록
        /// </summary>
        /// <returns></returns>
        public async void OnClickRegisterButton()
        {
            m_RegisterButton.interactable = false;

            if (string.IsNullOrEmpty(m_NicknameField.text))
            {
                //TODO : 값이 없다는 걸 팝업으로 알림
                m_RegisterButton.interactable = true;
                return;
            }

            bool success = await m_DataManager.RegistPlayerData(m_NicknameField.text);

            if (success) 
            {
                //TODO : UI 이동
            }
            else
            {
                //TODO : 등록 실패
            }

            m_RegisterButton.interactable = true;
        }
    }

}
