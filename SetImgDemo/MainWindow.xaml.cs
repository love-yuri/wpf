using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using NetMQ;
using miniSem.Base;
using NetMQ.Sockets;

namespace SetImgDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private readonly PublisherSocket _pub = new PublisherSocket(@"tcp://localhost:22222");
        
        public MainWindow() {
            DataContext = this;
            InitializeComponent();
            
            Unloaded += (a, b) => {
                SemViewerTc.StopLiveViewer();
            };
        }

        private void Msg(string msg) {
            var time = DateTime.Now.ToString("HH:mm:ss.fffff");
            var str = $"[{time}] {msg}\n";
            Dispatcher.Invoke(() => {
                if (LogLabel.Text != null && LogLabel.Text.Length > 1000) {
                    LogLabel.Text = "";
                }

                LogLabel.Text += str;
            });
            Log.Info(msg);
        }
        
        private void SendOver() {
            var msg = new List<byte>();
            msg.AddRange(BitConverter.GetBytes(-666));
            msg.AddRange(BitConverter.GetBytes(0));
            _pub.SendFrame(msg.ToArray());
        }

        /// <summary>
        /// 发送指令设置img的size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="flag"></param>
        private void SetImgSize(int flag, int width) {
            var msg = new List<byte>();
            msg.AddRange(BitConverter.GetBytes(flag));
            msg.AddRange(BitConverter.GetBytes(width));
            _pub.SendFrame(msg.ToArray());
        }
        
        private static void Wait() {
            var current = DateTime.Now;
            var temp = DateTime.Now;
            while ((temp - current).TotalMilliseconds < 1) {
                temp = DateTime.Now; 
            }
        }

        /// <summary>
        /// 加载图片并转换为黑白照片，默认渲染原生分辨率
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private WriteableBitmap LoadImg(string path) {
            Msg($"读取图片并开始转换... path: {path}");
            
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            // if (reSize != null) {
            // bitmapImage.DecodePixelWidth = 1024;
            // }
            bitmapImage.EndInit();
                
            var convertedBitmap = new FormatConvertedBitmap();
            convertedBitmap.BeginInit();
            convertedBitmap.Source = bitmapImage;
            convertedBitmap.DestinationFormat = PixelFormats.Gray8; // 统一转换
            convertedBitmap.EndInit();
            
            Msg("图片转换成功...");

            return new WriteableBitmap(convertedBitmap);
        }

        private void SendImg(string path, int flag = 0) {
            Task.Run(() => {
                Dispatcher.Invoke(() => {
                    ButtonOrigin.IsEnabled = false;
                    Button1024.IsEnabled = false;
                    Button10242.IsEnabled = false;
                    Button10243.IsEnabled = false;
                });
                var wBmp = LoadImg(path);
                int rowOffset = wBmp.PixelWidth;

                Msg($"图片宽度: {wBmp.PixelWidth} 高度: {wBmp.PixelHeight} 图片大小: {wBmp.PixelHeight * rowOffset / 1024 / 1024} MB 每行所占字节: {rowOffset}");
                
                SetImgSize(flag, rowOffset);
                // Dispatcher.Invoke(() => {
                //     ButtonOrigin.IsEnabled = true;
                //     Button1024.IsEnabled = true;
                //     Button10242.IsEnabled = true;
                //     Button10243.IsEnabled = true;
                // });
                // return;
                // resize img
                
                Msg("开始发送图片数据...");
                int h = Math.Min(wBmp.PixelWidth, wBmp.PixelHeight);
                var buffer = new byte[rowOffset + 8];
                int line = -1;
                for (var y = 0; y < h; y++) {
                    line++;
                    int offset = rowOffset * y; // 计算当前行的偏移量
                    WriteByte(BitConverter.GetBytes(offset), buffer, 0);
                    WriteByte(BitConverter.GetBytes(line), buffer, 4);
                
                    wBmp.CopyPixels(new Int32Rect(0, y, wBmp.PixelWidth, 1), buffer, rowOffset, 8);
                
                    // Msg($"发送第 {y} 行，一共 {wBmp.PixelHeight} 行 offset: {offset}");
                    Wait();
                    _pub.SendFrame(buffer);
                }
                

                Msg($"发送成功... 一共发送: {h * rowOffset} 字节");
                Dispatcher.Invoke(() => {
                    ButtonOrigin.IsEnabled = true;
                    Button1024.IsEnabled = true;
                    Button10242.IsEnabled = true;
                    Button10243.IsEnabled = true;
                });
                SendOver();
                // SendImg(path, reSize);
            });
        }

        /// <summary>
        /// 渲染原生分辨率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendImg(object sender, RoutedEventArgs e) {
            const string path = @"D:\extra\Battery-NCM-3KV-L2-0.831-X2-2800-1600ns-LA8-8K-_15.tiff";
            // const string path = @"E:\pictures\Camera Roll\wallven\wallhaven-x6yzoz_2560x1440.png";
            SendImg(path, -1);
        }
        
        /// <summary>
        /// 渲染1024分辨率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send1024Img(object sender, RoutedEventArgs e) {
            const string path = @"D:\extra\Battery-NCM-3KV-L2-0.831-X2-2800-1600ns-LA8-8K-_15.tiff";
            // const string path = @"E:\pictures\Camera Roll\wallven\wallhaven-x6yzoz_2560x1440.png";
            SendImg(path, -2);
        }
        
        private void Send1024Img2(object sender, RoutedEventArgs e) {
            const string path = @"D:\extra\Battery-NCM-3KV-L2-0.831-X2-2800-1600ns-LA8-8K-_15.tiff";
            // const string path = @"E:\pictures\Camera Roll\wallven\wallhaven-x6yzoz_2560x1440.png";
            SendImg(path, -3);
        }
        
        private void Send1024Img3(object sender, RoutedEventArgs e) {
            const string path = @"D:\extra\Battery-NCM-3KV-L2-0.831-X2-2800-1600ns-LA8-8K-_15.tiff";
            // const string path = @"E:\pictures\Camera Roll\wallven\wallhaven-x6yzoz_2560x1440.png";
            SendImg(path, -4);
        }

        private static void WriteByte(byte[] data, byte[] buffer, int offset) {
            for (var i = 0; i < data.Length; i++) {
                buffer[offset + i] = data[i];
            }
        }
    }
}