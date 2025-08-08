using Firebase;
using Firebase.Analytics;
using System;
using UnityEngine;

namespace TK.Firebase.Ch01
{
    /// <summary>
    /// 챕터 1 : 파이어베이스 초기화 클래스 (어널리틱스 연동)
    /// </summary>
    public class FirebaseInitializer : MonoBehaviour
    {
        public Action<FirebaseConnectStatus> OnConnectEvent;

        private void Start()
        {
            OnConnectEvent?.Invoke(FirebaseConnectStatus.OnConnecting);

            //Firebase 종속성 체크
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    //FirebaseAnalytics 초기화
                    OnConnectEvent?.Invoke(FirebaseConnectStatus.Connected);
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                }
                else
                {
                    OnConnectEvent?.Invoke(FirebaseConnectStatus.Failed);
                    Debug.LogError($"Firebase dependencies not resolved: {dependencyStatus}");
                }
            });
        }
    }

}

