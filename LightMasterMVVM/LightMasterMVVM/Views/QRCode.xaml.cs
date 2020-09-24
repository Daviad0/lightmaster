using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace LightMasterMVVM.Views
{
    public class QRCode : Window
    {
        public QRCode()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.CanResize = false;
            this.ClientSize = new Avalonia.Size(450, 300);
            this.HasSystemDecorations = false;
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var bitmap = new System.Drawing.Bitmap(assets.Open(new Uri("resm:LightMasterMVVM.Assets.LightScoutThick.png")));
            QRCoder.QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("LRSSQR>862>David Reeves>R1>0000>2", QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(15, 63, 140), Color.White, false);
            using (MemoryStream memory = new MemoryStream())
            {
                qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                //AvIrBitmap is our new Avalonia compatible image. You can pass this to your view
                this.Find<Avalonia.Controls.Image>("QRCode").Source = new Avalonia.Media.Imaging.Bitmap(memory);
            }
            this.PointerPressed += QRCode_PointerPressed;
        }

        private void QRCode_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
