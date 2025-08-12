using Firebase.Auth;
using System.Threading.Tasks;
using UnityEngine;
using Firebase;

namespace TK.Ch03.Firebase
{
    /// <summary>
    /// 유저 인증 / 로그인 지원 서비스
    /// (이메일 방식)
    /// </summary>
    public class FirebaseAuthService : MonoBehaviour, IFirebaseService
    {
        private FirebaseAuth m_Auth;
        private FirebaseUser m_User; //Current User

        public void Initialize()
        {
            m_Auth = FirebaseAuth.DefaultInstance;
        }

        /// <summary>
        /// 이메일/비번 방식 계정 생성 메소드
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async Task<bool> CreateAccoutWayEmailAsync(string email, string password)
        {
            try
            {
                var task = await m_Auth.CreateUserWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseException ex)
            {
                var errorCode = (AuthError)ex.ErrorCode;

                switch (errorCode)
                {
                    case AuthError.EmailAlreadyInUse:
                        Debug.LogWarning("계정생성 실패::이메일이 이미 존재함");
                        break;
                    case AuthError.InvalidEmail:
                        Debug.LogWarning("계정생성 실패::이메일 형식이 안 맞음");
                        break;
                    case AuthError.WeakPassword:
                        Debug.LogWarning("계정생성 실패::패스워드가 6자리 미만임");
                        break;
                    default:
                        Debug.LogWarning("계정생성 실패");
                        break;
                }

                return false;
            }
        }

        /// <summary>
        /// 이메일 방식 로그인 메소드
        /// </summary>
        public async Task<bool> SigninWayEmailAsync(string email, string password)
        {
            try
            {
                var task = await m_Auth.SignInWithEmailAndPasswordAsync(email, password);
                m_User = task.User;
                Debug.LogWarning("로그인 성공");
                return true;

            }
            catch (FirebaseException ex)
            {
                var errorCode = (AuthError)ex.ErrorCode;
                switch (errorCode)
                {
                    case AuthError.UserNotFound:
                        Debug.LogWarning("로그인 실패::존재하지 않은 사용자입니다.");
                        break;
                    case AuthError.WrongPassword:
                        Debug.LogWarning("로그인 실패::계정 또는 비밀번호가 틀렸습니다.");
                        break;
                    default:
                        Debug.LogWarning("로그인 실패 실패");
                        break;
                }
                return false;
            }
        }

        /// <summary>
        /// 로그 아웃 메소드
        /// </summary>
        public void SignOut() 
        {
            m_Auth.SignOut();
            Debug.Log($"{m_User.ProviderId}'s logout");
            m_User = null;
        }
    }

}
