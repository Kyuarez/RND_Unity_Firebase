using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using UnityEngine;

namespace TK.Firebase
{
    /// <summary>
    /// Firebase OAuth 지원 (구글, 네이버, 카카오)
    /// </summary>
    public class FirebaseOAuthService : MonoBehaviour, IFirebaseService
    {
        private FirebaseAuth m_Auth;
        private FirebaseUser m_User;

        public void Initialize()
        {
            m_Auth = FirebaseAuth.DefaultInstance;
        }

        /// <summary>
        /// 구글 이메일을 통한 Open Auth 메소드
        /// </summary>
        public async Task<bool> LoginByGoogleOAuth(string idToken, string accessToken)
        {
            try
            {
                Credential credential = GoogleAuthProvider.GetCredential(idToken, accessToken);
                var result = await m_Auth.SignInAndRetrieveDataWithCredentialAsync(credential);
                return true;
            }
            catch(FirebaseException ex)
            {
                var errorCode = (AuthError)ex.ErrorCode; 
                switch (errorCode)
                {
                    case AuthError.CredentialAlreadyInUse:
                        Debug.LogWarning("로그인 실패:: 이미 등록된 계정입니다.");
                        break;
                    case AuthError.InvalidAppCredential:
                        Debug.LogWarning("로그인 실패::InvalidAppCredential");
                        break;
                    case AuthError.InvalidCredential:
                        Debug.LogWarning("로그인 실패::InvalidCredential");
                        break;
                    case AuthError.RejectedCredential:
                        Debug.LogWarning("로그인 실패::외부 제공 업체 거절");
                        break;
                    default:
                        Debug.LogWarning("로그인 실패 실패");
                        break;
                }
                return false;
            }
        }
    }
}
