using Firebase;
using Firebase.Analytics;
using System;
using UnityEngine;

namespace TK.Firebase.Ch01
{
    /// <summary>
    /// é�� 1 : ���̾�̽� �ʱ�ȭ Ŭ���� (��θ�ƽ�� ����)
    /// </summary>
    public class FirebaseInitializer : MonoBehaviour
    {
        public Action<FirebaseConnectStatus> OnConnectEvent;

        private void Start()
        {
            OnConnectEvent?.Invoke(FirebaseConnectStatus.OnConnecting);

            //Firebase ���Ӽ� üũ
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    //FirebaseAnalytics �ʱ�ȭ
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

