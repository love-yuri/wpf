using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace miniSem.Base.Mvvm {
    
    /// <summary>
    /// 基础ViewModel 实现了变化更新
    /// </summary>
    public class BaseViewModel: INotifyPropertyChanged {
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置属性值，如果变化则通知更新
        /// </summary>
        /// <param name="field">待更新的属性</param>
        /// <param name="value">新的值</param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(field, value)) {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}