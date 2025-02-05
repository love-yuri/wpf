using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace miniSem.Base.Config {

    /// <summary>
    /// 基础配置类 子类读取文件使用load函数读取
    /// </summary>
    internal abstract class BaseConfig {
        private bool _isInit = true;
        /// 基础目录
        protected abstract string BasePath { get; }
        /// 暂存属性
        private readonly ConcurrentDictionary<string, object> _configData = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// 是否在属性更改时写入数据, 默认为true
        /// 不保留配置，每次启动都是默认值
        /// </summary>
        [JsonIgnore]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public bool SaveWhenChange { get; set; } = true;
        
        /// <summary>
        /// 加载配置文件，如果不存在则使用默认
        /// </summary>
        /// <typeparam name="T">配置文件类型</typeparam>
        /// <returns>配置文件类</returns>
        protected static T Load<T>() where T : BaseConfig, new() {
            var defaultConfig = new T {
                _isInit = false
            };
            var path = defaultConfig.BasePath;
            if (!File.Exists(path)) {
                var directoryPath = Path.GetDirectoryName(path);
                if (directoryPath == null) {
                    throw new Exception("目录获取错误!!!");
                }
                
                if (!Directory.Exists(directoryPath)) {
                    Directory.CreateDirectory(directoryPath);
                }
                using (var stream = File.Create(path)) {
                    var jsonData = JsonConvert.SerializeObject(defaultConfig);
                    var byteArray = Encoding.UTF8.GetBytes(jsonData); // 将字符串转换为字节数组
                    stream.Write(byteArray, 0, byteArray.Length); // 写入字节数组
                    return defaultConfig;
                }
            }
            
            var json = File.ReadAllText(path);
            try {
                var settings = new JsonSerializerSettings {
                    // 总是替换数据，而不是修改原有数据,避免初始化时频繁调用该_configData用
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                };
                var config = JsonConvert.DeserializeObject<T>(json, settings) ?? throw new Exception($"{typeof(T).Name}: {path} 序列化失败!!");
                Log.Debug($"{typeof(T).Name}: {path} 加载成功!!");
                config._isInit = false;
                return config;
            } catch (Exception e) {
                Log.Error($"配置文件加载失败，使用默认配置 {e.Message}");
                return defaultConfig;
            }
        }
        
        
        /// <summary>
        /// 设置value属性
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        protected void SetValue(object value, [CallerMemberName] string key = "") {
            _configData[key] = value ?? throw new Exception("不可以设置value为null!!");
            Log.Debug($"设置value -> {key}, v -> {value}");
      
            // 初始化和更改写入不生效时不写入
            if (_isInit || !SaveWhenChange) {
                return;
            }
            Save();
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public void Save() {
            File.WriteAllText(BasePath, JsonConvert.SerializeObject(this));
        }
        
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="defaultValue">默认值</param>
        /// <param name="key">默认key</param>
        /// <typeparam name="TV">值类型</typeparam>
        /// <returns></returns>
        protected TV GetValue<TV>(TV defaultValue, [CallerMemberName] string key = "") {
            if (_configData.TryGetValue(key, out var v) && v is TV result) {
                return result;
            }
            return defaultValue;
        }
    }
}