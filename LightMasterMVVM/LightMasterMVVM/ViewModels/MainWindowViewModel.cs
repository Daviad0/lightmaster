using LightMasterMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.ViewModels
{
    public class TabletViewModel : ViewModelBase
    {
        private string _text = "Test";
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
    public class MainWindowViewModel : ViewModelBase
    {
        private string _text = "Initial text";
        private bool userControlVisible = true;

        public string Text
        {
            get => _text;
            // SetProperty will trigger PropertyChanged event so the view is notified
            set => SetProperty(ref _text, value);
        }
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }

        // Unlike WPF avalonia supports binding commands to view model methods. You can still use ICommand though
        public void ChangeText(object text)
        {
            Text = (string)text;
        }
        public void ChangeVisibility()
        {
            UserControlVisible = !UserControlVisible;
        }
    }
}
