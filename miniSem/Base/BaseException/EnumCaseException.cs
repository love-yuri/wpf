// ReSharper disable UnusedType.Global
namespace miniSem.Base.BaseException {

    /// <summary>
    /// 用户处理枚举转换失败的错误
    /// </summary>
    public class EnumCaseException : System.Exception {
        public EnumCaseException() : base("枚举类型转换失败!!") { }
        public EnumCaseException(string message) : base(message) { }
        public EnumCaseException(string message, System.Exception inner) : base(message, inner) { }
    }
}