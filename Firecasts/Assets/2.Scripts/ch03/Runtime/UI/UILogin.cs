using TK.Ch03.Firebase;
using TK.DI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TK.Ch03
{
    /// <summary>
    /// 파이어베이스 Auth 로그인 패널
    /// </summary>
    public class UILogin : MonoBehaviour
    {
        [Inject] FirebaseAuthService m_Service;

        [SerializeField] TMP_InputField m_EmailField;
        [SerializeField] TMP_InputField m_PasswordField;
        [SerializeField] Button m_CreateAccountButton;
        [SerializeField] Button m_LoginButton;
        [SerializeField] Button m_LogoutButton;

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
