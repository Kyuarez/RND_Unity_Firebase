
using System;

namespace TK
{
    /// <summary>
    /// 데이터 필드 값이 변경될 때, 이벤트 지원하기 위해 만든 클래스
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableField<T> : INotifyFieldChanged<T>
    {
        private T data;

        public event Action<object, T> FieldChaneged;
    
        public T Data
        {
            get => data;
            set
            {
                if (data.Equals(value))
                {
                    return;
                }

                data = value;
                FieldChaneged?.Invoke(this, value);
            }
        }
    }

    public interface INotifyFieldChanged<T>
    {
        event Action<object, T> FieldChaneged;
    }
}
