using System;
using System.Linq;
using System.Windows;

namespace miniSem.Utils {
    /// <summary>
    /// 语言资源，切换语言用
    /// </summary>
    public class LanguageResource : ResourceDictionary {}

    /// <summary>
    /// 主题资源, 切换主题使用
    /// </summary>
    public class ThemeStyleResource : ResourceDictionary { }
    
    public enum LanguageType {
        Chinese,
        English
    }
    
    public enum ThemeType {
        Dark,
        Light,
    }
    
    /// <summary>
    /// 处理资源文件常用工具
    /// </summary>
    public static class ResourceUtils {
        
        /// <summary>
        /// 切换全局系统语言，如果有默认语言需要使用LanguageResource导入
        /// </summary>
        /// <param name="type"></param>
        public static void ChangeLanguage(LanguageType type) {
            var res = Application.Current.Resources.MergedDictionaries;
            var language = res.FirstOrDefault(it => it is LanguageResource);
            if (language == null) {
                language = new LanguageResource();
                res.Add(language);
            }

            switch (type) {
                case LanguageType.Chinese: {
                    language.Source = new Uri("/Properties/zh-cn.xaml", UriKind.Relative);
                    break;
                }

                case LanguageType.English: {
                    language.Source = new Uri("/Properties/en-us.xaml", UriKind.Relative);
                    break;
                }
                
                default: return;
            }
        }
        
        /// <summary>
        /// 切换全局系统皮肤，如果有默认语言需要使用ThemeResource导入
        /// </summary>
        /// <param name="type"></param>
        public static void ChangeTheme(ThemeType type) {
            var res = Application.Current.Resources.MergedDictionaries;
            var theme = res.FirstOrDefault(it => it is ThemeStyleResource);
            if (theme == null) {
                theme = new ThemeStyleResource();
                res.Add(theme);
            }

            switch (type) {
                case ThemeType.Dark: {
                    theme.Source = new Uri("/Styles/DarkStyle.xaml", UriKind.Relative);
                    break;
                }

                case ThemeType.Light: {
                    theme.Source = new Uri("/Styles/LightStyle.xaml", UriKind.Relative);
                    break;
                }
                
                default: return;
            }
        }
    }
}