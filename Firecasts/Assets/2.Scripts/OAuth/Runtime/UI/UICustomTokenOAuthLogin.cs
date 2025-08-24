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
    [Tooltip("파이어베이스 OAuth 지원 클래스 :: CustomToken 방식")]
    public class UICustomTokenOAuthLogin : MonoBehaviour
    {
        [Inject] FirebaseOAuthService m_Service;

        [SerializeField] Button m_GoogleOAuthButton;
        [SerializeField] Button m_NaverOAuthButton;
        [SerializeField] Button m_KakaoOAuthButton;



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
