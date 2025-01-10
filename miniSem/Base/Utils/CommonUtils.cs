using System;
using System.Windows;
using miniSem.Base.BaseException;

namespace miniSem.Base.Utils {
    
    public static class CommonUtils {
        /// <summary>
        /// 返回当前Window
        /// </summary>
        public static Window CurrentWindow => Application.Current.MainWindow;
        
        public static T CreateInstance<T>() where T : class {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            if (instance == null) throw new Exception($"{type.Name} 实例创建失败!!!");
            return instance as T ?? throw new TypeCastException(type);
        }

        /// <summary>
        /// int 转枚举，如果失败则抛异常
        /// </summary>
        /// <param name="value">枚举int值</param>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T IntToEnum<T>(int value) where T : Enum {
            if (Enum.IsDefined(typeof(T), value)) {
                // 如果是有效的枚举值
                return (T)(object)value;
            }

            throw new EnumCaseException($"无效的枚举值: {value}");
        }
    }
}