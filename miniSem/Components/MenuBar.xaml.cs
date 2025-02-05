using System.Windows;
using System.Windows.Input;
using miniSem.Base.Mvvm;
using miniSem.Base.Utils;

namespace miniSem.Components {
    public delegate void MenubarClickEvent();
    
    public partial class MenuBar {
        private bool _canDragMove;
        private LanguageType _languageType = LanguageType.Chinese;
        private ThemeType _themeType = ThemeType.Light;
        public BaseCommand OpenCurrentPathCommand { get; } = BaseCommand.Create(FileUtils.OpenDirectory);
        
        public MenuBar() {
            InitializeComponent();
        }

        #region 鼠标移动/拖动事件

        // 使用更深层次的信号传递
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
            _canDragMove = true;
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e) {
            _canDragMove = false;
        }
        
        protected override void OnMouseMove(MouseEventArgs e) {
            // 判断鼠标左键是否按下
            if (e.LeftButton != MouseButtonState.Pressed || !_canDragMove) {
                return;
            }
            if (CommonUtils.CurrentWindow.WindowState == WindowState.Maximized) {
                CommonUtils.CurrentWindow.WindowState = WindowState.Normal;
            }
            CommonUtils.CurrentWindow.DragMove();
        }

        #endregion


        #region 窗口工具

        private void CloseWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.Close();
        }

        private void MiniWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.WindowState = WindowState.Minimized;
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e) {
            if (e.ChangedButton != MouseButton.Left) {
                return;
            }
            var newState = CommonUtils.CurrentWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            CommonUtils.CurrentWindow.WindowState = newState;

        }

        #endregion

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