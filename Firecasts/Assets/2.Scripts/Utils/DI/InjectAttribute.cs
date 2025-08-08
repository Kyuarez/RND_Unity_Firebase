using System;

namespace TK.DI
{
    /// <summary>
    /// Inject 할 클래스 지정 어트리뷰트
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {

    }
}
