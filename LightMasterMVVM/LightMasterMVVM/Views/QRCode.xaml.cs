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
        public Button selectRed1 = new Button();
        public Button selectRed2 = new Button();
        public Button selectRed3 = new Button();
        public Button selectBlue1 = new Button();
        public Button selectBlue2 = new Button();
        public Button selectBlue3 = new Button();
        private Button close_window = new Button();
        public Button prevClickedButton = new Button();
        public QRCode()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            selectRed1 = this.Find<Button>("Red1");
            selectRed1.Click += ChangeQRCode;
            selectRed2 = this.Find<Button>("Red2");
            selectRed2.Click += ChangeQRCode;
            selectRed3 = this.Find<Button>("Red3");
            selectRed3.Click += ChangeQRCode;
            selectBlue1 = this.Find<Button>("Blue1");
            selectBlue1.Click += ChangeQRCode;
            selectBlue2 = this.Find<Button>("Blue2");
            selectBlue2.Click += ChangeQRCode;
            selectBlue3 = this.Find<Button>("Blue3");
            selectBlue3.Click += ChangeQRCode;
            close_window = this.Find<Button>("HideWindow");
            close_window.Click += Close_window_Click;
            prevClickedButton = selectRed1;
            this.CanResize = false;
            this.ClientSize = new Avalonia.Size(450, 340);
            this.HasSystemDecorations = false;
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
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

        private void Close_window_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeQRCode(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Button clicked = (Button)sender as Button;
            string buttontype = "";
            prevClickedButton.Classes.Remove("navbuttonselected");
            prevClickedButton.Classes.Add("navbutton");
            switch (clicked.Name)
            {
                case "Red1":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "R1";
                    break;
                case "Red2":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "R2";
                    break;
                case "Red3":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "R3";
                    break;
                case "Blue1":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "B1";
                    break;
                case "Blue2":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "B2";
                    break;
                case "Blue3":
                    clicked.Classes.Remove("navbutton");
                    clicked.Classes.Add("navbuttonselected");
                    buttontype = "B3";
                    break;
            }
            clicked.Classes.Remove("navbutton");
            clicked.Classes.Add("navbuttonselected");
            QRCoder.QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("LRSSQR>862>David Reeves>" + buttontype + ">0000>2", QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(15, 63, 140), Color.White, false);
            using (MemoryStream memory = new MemoryStream())
            {
                qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                //AvIrBitmap is our new Avalonia compatible image. You can pass this to your view
                this.Find<Avalonia.Controls.Image>("QRCode").Source = new Avalonia.Media.Imaging.Bitmap(memory);
            }
            prevClickedButton = clicked;
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
