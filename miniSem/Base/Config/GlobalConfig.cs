namespace miniSem.Base.Config {
    
    internal class GlobalConfig: BaseConfig {
        protected override string BasePath => "config/global.json";
        
        private static GlobalConfig _instance;
        public static GlobalConfig Instance => _instance ?? (_instance = Load<GlobalConfig>());

        public string Name {
            get => GetValue("yuri");
            set => SetValue(value);
        }

        public string Version {
            get => GetValue("1.0.0");
            set => SetValue(value);
        }
    }
}