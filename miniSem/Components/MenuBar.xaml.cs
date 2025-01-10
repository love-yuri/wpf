using System.Windows;
using System.Windows.Input;
using miniSem.Base.Utils;

namespace miniSem.Components {
    public delegate void MenubarClickEvent();
    
    public partial class MenuBar {
        public MenubarClickEvent ImportImgClick = null;
        private LanguageType _languageType = LanguageType.Chinese;
        private ThemeType _themeType = ThemeType.Light;
        
        public MenuBar() {
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            // 判断鼠标是否按下
            if (e.LeftButton == MouseButtonState.Pressed) {
                CommonUtils.CurrentWindow.DragMove();
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.Close();
        }

        private void MiniWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 切换语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeLanguage(object sender, RoutedEventArgs e) {
            switch (_languageType) {
                case LanguageType.English: {
                    ResourceUtils.ChangeLanguage(LanguageType.Chinese);
                    _languageType = LanguageType.Chinese;
                    break;
                }
                case LanguageType.Chinese: {
                    ResourceUtils.ChangeLanguage(LanguageType.English);
                    _languageType = LanguageType.English;
                    break;
                }
                default: {
                    return;
                }
            }
        }

        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTheme(object sender, RoutedEventArgs e) {
            switch (_themeType) {
                case ThemeType.Dark: {
                    ResourceUtils.ChangeTheme(ThemeType.Light);
                    _themeType = ThemeType.Light;
                    break;
                }
                case ThemeType.Light: {
                    ResourceUtils.ChangeTheme(ThemeType.Dark);
                    _themeType = ThemeType.Dark;
                    break;
                }
                default: {
                    return;
                }
            }
        }
    }
}