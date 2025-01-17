using System.Collections.Generic;

namespace miniSem.Base.Config {
    
    internal class GlobalConfig: BaseConfig {
        protected override string BasePath => "config/global.json";
        
        // 全局共享实例
        public static GlobalConfig Instance => _instance ?? (_instance = Load<GlobalConfig>());
        private static GlobalConfig _instance;

        private readonly List<string> _stringEmptyList = new List<string>();

        public string Name {
            get => GetValue("yuri");
            set => SetValue(value);
        }

        public string Version {
            get => GetValue("1.0.0");
            set => SetValue(value);
        }

        public List<string> Arrays {
            get => GetValue(_stringEmptyList);
            set => SetValue(value);
        }

        public Person Person {
            get => GetValue(new Person());
            set => SetValue(value);
        }
    }
    
    internal struct Person {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() {
            return $"name: {Name}, age: {Age}";
        }
    }
}