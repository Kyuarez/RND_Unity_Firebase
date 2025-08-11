using Firebase.Database;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace TK.Ch02.Firebase
{
    /// <summary>
    /// Firebase Database 기능 서버스 클래스
    /// </summary>
    public class FirebaseDBService : MonoBehaviour, IFirebaseService
    {
        private const string User_KEY = "Users";

        private FirebaseDatabase m_Database;
        private DatabaseReference m_UsersRoot;

        public void Initialize()
        {
            m_Database = FirebaseDatabase.DefaultInstance;
            m_UsersRoot = m_Database.GetReference(User_KEY);
        }

        /// <summary>
        /// UserData의 nickname이 이미 존재하는지 여부
        /// </summary>
        /// <param name="nickname"></param>
        public async Task<bool> ExistUserValue(string nickname)
        {
            var snapshot = await m_UsersRoot.Child(nickname).GetValueAsync();
            return snapshot.Exists;
        }

        /// <summary>
        /// Firebase DB에 Userdata 저장
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveUserData(UserData userdata)
        {
            string json = JsonUtility.ToJson(userdata);
            await m_UsersRoot.Child(userdata.NickName).SetRawJsonValueAsync(json);
            return true;
        }

        /// <summary>
        /// UserData 가져오기
        /// </summary>
        public async Task<UserData> GetUserData(string nickname)
        {
            var snapshot = await m_UsersRoot.Child(nickname).GetValueAsync();
            if (!snapshot.Exists) 
            {
                return default;
            }
            
            string json = snapshot.GetRawJsonValue();
            return JsonUtility.FromJson<UserData>(json);
        }
    }   
}

