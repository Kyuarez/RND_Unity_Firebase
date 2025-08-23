using TK.Ch03.Firebase;
using TK.DI;
using TK.Firebase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK
{
    /// <summary>
    /// 파이어베이스 Auth 로그인 패널 + OAuth 지원
    /// </summary>
    public class UIOAuthLogin : MonoBehaviour
    {
        [Inject] FirebaseAuthService m_Service;
        [Inject] FirebaseOAuthService m_OAuthService;

        [SerializeField] TMP_InputField m_EmailField;
        [SerializeField] TMP_InputField m_PasswordField;
        [SerializeField] Button m_CreateAccountButton;
        [SerializeField] Button m_LoginButton;
        [SerializeField] Button m_LogoutButton;
        [SerializeField] Button m_GoogleOAuthButton;
        [SerializeField] Button m_NaverOAuthButton;
        [SerializeField] Button m_KakaoOAuthButton;

        private void Awake()
        {
            m_CreateAccountButton.onClick.AddListener(OnClickCreateAccountButton);
            m_LoginButton.onClick.AddListener(OnClickLoginButton);
            m_LogoutButton.onClick.AddListener(OnClickLogoutButton);
        }

        public async void OnClickCreateAccountButton()
        {
            await m_Service.CreateAccoutWayEmailAsync(m_EmailField.text, m_PasswordField.text);
        }
        public async void OnClickLoginButton()
        {
            await m_Service.SigninWayEmailAsync(m_EmailField.text, m_PasswordField.text);
        }
        public void OnClickLogoutButton()
        {
            m_Service.SignOut();
        }
    }
}
