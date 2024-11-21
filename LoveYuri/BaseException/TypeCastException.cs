namespace LoveYuri.BaseException;


public class TypeCastException(Type type): Exception(
    $"转换到类型 {type} 错误!!"
);