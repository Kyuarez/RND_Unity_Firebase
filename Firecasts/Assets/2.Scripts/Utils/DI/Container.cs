using System;
using System.Collections.Generic;
using UnityEngine;

namespace TK.DI
{
    public class Container
    {
        private Dictionary<Type, object> m_registDict;

        public Container()
        {
            m_registDict = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Monobehaviour 객체를 생성해서 추가
        /// </summary>
        public void RegisterMonoBehaviour<T>() where T : MonoBehaviour
        {
            T obj = new GameObject(typeof(T).Name).AddComponent<T>();
            m_registDict[typeof(T)] = obj;
        }

        /// <summary>
        /// Hierarchy 에 존재하는 객체를 추가
        /// </summary>
        public void RegisterMonoBehaviour(MonoBehaviour monobehaviour)
        {
            m_registDict[monobehaviour.GetType()] = monobehaviour;
        }

        public T Resolve<T>()
        {
            return (T)m_registDict[typeof(T)];
        }

        public object Resolve(Type type)
        {
            if (m_registDict.TryGetValue(type, out object obj))
            {
                return obj;
            }

            return null;
        }
    }
}
