using Avalonia.Styling;
using LightMasterMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class NotificationItem
    {
        private string backgroundColor;
        private string notificationText;
        private string notificationTitle;
        private bool notificationActive;
        private bool isPermissionRequest;
        private int notificationId;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DateTime timeAdded { get; set; }
        public string BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }

            set
            {
                if (value != this.backgroundColor)
                {
                    this.backgroundColor = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
    
        public int NotificationId
        {
            get
            {
                return this.notificationId;
            }

            set
            {
                if (value != this.notificationId)
                {
                    this.notificationId = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public bool NotificationActive
        {
            get
            {
                return this.notificationActive;
            }

            set
            {
                if (value != this.notificationActive)
                {
                    this.notificationActive = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool IsPermissionRequest
        {
            get
            {
                return this.isPermissionRequest;
            }

            set
            {
                if (value != this.isPermissionRequest)
                {
                    this.isPermissionRequest = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string NotificationText
        {
            get
            {
                return this.notificationText;
            }

            set
            {
                if (value != this.notificationText)
                {
                    this.notificationText = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string NotificationTitle
        {
            get
            {
                return this.notificationTitle;
            }

            set
            {
                if (value != this.notificationTitle)
                {
                    this.notificationTitle = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public void CancelNotification()
        {
            NotificationActive = false;
            NotifyPropertyChanged();
        }
    }
}
