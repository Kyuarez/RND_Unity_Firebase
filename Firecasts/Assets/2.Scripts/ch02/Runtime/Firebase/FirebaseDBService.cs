using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using UnityEngine;
using System;

namespace TK.Ch02.Firebase
{
    /// <summary>
    /// Firebase Database 기능 서버스 클래스
    /// </summary>
    public class FirebaseDBService : MonoBehaviour, IFirebaseService
    {
        private const string User_KEY = "Users";
        private DatabaseReference m_UsersRoot;


        public void Initialize()
        {
            m_UsersRoot = FirebaseDatabase.DefaultInstance.GetReference(User_KEY);
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

