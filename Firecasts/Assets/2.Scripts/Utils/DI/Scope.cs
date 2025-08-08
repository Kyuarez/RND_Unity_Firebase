using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TK.DI
{
    [DefaultExecutionOrder(-100)]
    public abstract class Scope : MonoBehaviour
    {
        [SerializeField] List<MonoBehaviour> m_MonoBehaviours;

        protected Container container;

        protected virtual void Awake()
        {
            container = new Container();
            Register();
            InjectAll();
        }

        public virtual void Register()
        {
            foreach (var monoBehaviour in m_MonoBehaviours)
            {
                container.RegisterMonoBehaviour(monoBehaviour);
            }
        }

        /// <summary>
        /// 현재 존재하는 씬의 모든 Mono들 끌고와서 inject하기
        /// </summary>
        protected virtual void InjectAll()
        {
            MonoBehaviour[] monobehaviours = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

            foreach (var monoBehaviour in monobehaviours)
            {
                Inject(monoBehaviour);
            }
        }

        /// <summary>
        /// 의존성을 주입함
        /// </summary>
        /// <param name="target"> 주입할 대상</param>
        protected virtual void Inject(object target)
        {
            Type type = target.GetType();

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.GetCustomAttribute<InjectAttribute>() != null)
                {
                    object value = container.Resolve(fieldInfo.FieldType);

                    if (value != null)
                        fieldInfo.SetValue(target, value);
                }
            }
        }
    }
}
