using System.Collections.Generic;

namespace miniSem.Base.Config {
    
    internal class GlobalConfig: BaseConfig {
        protected override string BasePath => "config/global.json";
        
        // 全局共享实例
        public static GlobalConfig Instance => _instance ?? (_instance = Load<GlobalConfig>());
        private static GlobalConfig _instance;

        public string Name {
            get => GetValue("yuri");
            set => SetValue(value);
        }

        public string Version {
            get => GetValue("1.0.0");
            set => SetValue(value);
        }

        public List<string> Arrays {
            get => GetValue(new List<string>());
            set => SetValue(value);
        }
    }
}