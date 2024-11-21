using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
// using Microsoft.CSharp.RuntimeBinder;
using LoveYuri.Utils;

namespace LoveYuri.Base;

/// <summary>
/// 基础配置类 子类读取文件使用load函数读取
/// </summary>
public abstract class BaseConfig {
    private bool _isInit = true;
    /// 基础目录
    protected abstract string BasePath { get; }
    /// 暂存属性
    private readonly ConcurrentDictionary<string, object?> _configData = new();

    // private IIncrementalGenerator? v;

    /// <summary>
    /// 加载配置文件，如果不存在则使用默认
    /// </summary>
    /// <typeparam name="T">配置文件类型</typeparam>
    /// <returns>配置文件类</returns>
    /// <exception cref="Exception"></exception>
    protected static T Load<T>() where T : BaseConfig, new() {
        var defaultConfig = new T {
            _isInit = false
        };
        var path = defaultConfig.BasePath;
        if (!File.Exists(path)) {
            using var stream = File.Create(path); 
            var jsonData = JsonSerializer.Serialize(defaultConfig);
            var byteArray = Encoding.UTF8.GetBytes(jsonData); // 将字符串转换为字节数组
            stream.Write(byteArray, 0, byteArray.Length); // 写入字节数组
            return defaultConfig;
        }
        
        var json = File.ReadAllText(path);
        try {
            var config = JsonSerializer.Deserialize<T>(json) ?? throw new Exception($"{typeof(T).Name}: {path} 序列化失败!!");
            Log.Debug($"{typeof(T).Name}: {path} 加载成功!!");
            config._isInit = false;
            return config;
        } catch (Exception e) {
            Log.Warn($"配置文件加载失败，使用默认配置 {e.Message}");
            return defaultConfig;
        }
    }
    
    /// <summary>
    /// 设置value属性
    /// </summary>
    /// <param name="value"></param>
    /// <param name="key"></param>
    protected void SetValue(object value, [CallerMemberName] string key = "") {
        _configData[key] = value;
        if (_isInit) return;
        File.WriteAllText(BasePath, JsonSerializer.Serialize(this, GetType()));
    }
    
    /// <summary>
    /// 读取配置
    /// </summary>
    /// <param name="value">默认值</param>
    /// <param name="key">默认key</param>
    /// <typeparam name="TV">值类型</typeparam>
    /// <returns></returns>
    protected TV GetValue<TV>(TV value, [CallerMemberName] string key = "") {
        var v = _configData.GetValueOrDefault(key, value);
        if (v == null) return value;
        return v switch {
            TV result => result,
            _ => (TV)v
        };
    }
}