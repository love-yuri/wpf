// ReSharper disable UnusedType.Global

using System;

namespace miniSem.Base.BaseException {
    public class TypeCastException : Exception {
        public TypeCastException(Type type) : base($"转换到类型 {type} 错误!!") {
            
        }
    }
}