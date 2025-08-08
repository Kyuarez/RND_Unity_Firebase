using System;
using TK.DI;
using TMPro;
using UnityEngine;

namespace TK.Firebase.Ch01
{
    /// <summary>
    /// 파이어베이스 연결 상태 보여주는 UI
    /// </summary>
    public class UIFirebaseConnectStatus : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_statusText;

        [Inject] FirebaseInitializer m_initializer;

        private void Awake()
        {
            m_statusText.text = string.Empty;
            m_initializer.OnConnectEvent += OnConnectedStatus;
        }

        public void OnConnectedStatus(FirebaseConnectStatus status)
        {
            string desc = string.Empty;
            switch (status)
            {
                case FirebaseConnectStatus.None:
                    desc = "[Firebase ConnectStatus] :: None";
                    break;
                case FirebaseConnectStatus.OnConnecting:
                    desc = "[Firebase ConnectStatus] :: Start Firebase Connecting";
                    break;
                case FirebaseConnectStatus.Connected:
                    desc = "[Firebase ConnectStatus] :: Success to Firebase Connecting";
                    break;
                case FirebaseConnectStatus.Failed:
                    desc = "[Firebase ConnectStatus] :: Fail to Firebase Connecting";
                    break;
                default:
                    break;
            }

            m_statusText.text = desc;
        } 
    }

}
