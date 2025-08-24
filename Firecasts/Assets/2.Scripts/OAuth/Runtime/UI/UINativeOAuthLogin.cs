using TK.Ch03.Firebase;
using TK.DI;
using TK.Firebase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK
{
    /// <summary>
    /// 파이어베이스 OAuth 지원 :: Native 방식
    /// </summary>
    [Tooltip("파이어베이스 OAuth 지원 클래스 :: Native 방식")]
    public class UINativeOAuthLogin : MonoBehaviour
    {
        [Inject] FirebaseOAuthService m_Service;

        [SerializeField] Button m_GoogleOAuthButton;

        private void Awake()
        {
            m_GoogleOAuthButton.onClick.AddListener(OnClickOpenAuthWithGoogle);
        }

        public async void OnClickOpenAuthWithGoogle()
        {
            //await m_OAuthService.LoginByGoogleOAuth(m_EmailField.text, m_PasswordField.text);
        }
    }
}
