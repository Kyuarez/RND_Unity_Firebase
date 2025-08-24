using Firebase;
using Firebase.Extensions;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace TK
{
    public class FirebaseInitializer : MonoBehaviour
    {
        private void Awake()
        {
            //TODO :: 메모리적 관점에서 더 좋은 방법 찾기
            List<IFirebaseService> serviceList = new List<IFirebaseService>();
            foreach (var mono in GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if(mono is IFirebaseService)
                {
                    serviceList.Add(mono as IFirebaseService);
                }
            }

            //파이어베이스 초기화 후에, 서비스 객체들 초기화 하기. (DefaultInstance 주입)
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if(task.Exception != null)
                {
                    Debug.Log($"Failed to initialized FIrebase with {task.Exception}");
                    return;
                }

                foreach (var service in serviceList)
                {
                    service.Initialize();
                }
            });

        }
    }

}
