using UnityEngine;
using System.Threading.Tasks;
using TK.DI;
using TK.Ch02.Firebase;

namespace TK.Ch02
{
    /// <summary>
    /// 인게임 내의 데이터 관리하는 객체
    /// </summary>
    public class DataManager : MonoBehaviour
    {
        [Inject] FirebaseDBService m_DBService;

        [Header("현재 유저 정보")]
        [SerializeField] UserData m_userData;

        /// <summary>
        /// 해당 파라미터가 이미 등록되어 있으면 바로 씬 이동, 없으면 등록 후 이동
        /// </summary>
        /// <param name="nickname"></param>
        public async Task<bool> RegistPlayerData(string nickname)
        {
            //닉네임이 이미 존재하는지 비동기적으로 확인
            var existResult = await m_DBService.ExistUserValue(nickname);
            if (existResult)
            {
                Debug.Log("DataManager: 닉네임이 이미 존재합니다.");
                LoadUserData(nickname);
                return true;
            }

            //등록하기(score = 0)
            UserData registUserData = new UserData(nickname);
            var registResult = await m_DBService.SaveUserData(registUserData);
            if (registResult == false)
            {
                Debug.LogError("DataManager: 등록이 실패했습니다!");
                return false;
            }

            LoadUserData(nickname);
            return true;
        }

        /// <summary>
        /// DB로부터 data 받아서 로드 처리
        /// </summary>
        /// <param name="nickname"></param>
        private async void LoadUserData(string nickname)
        {
            var data = await m_DBService.GetUserData(nickname);
            m_userData = data;
        }
    }
}
