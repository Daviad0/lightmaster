using Avalonia.Styling;
using DynamicData.Annotations;
using LightMasterMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class NotificationItem : INotifyPropertyChanged
    {
        private string backgroundColor;
        private string notificationText;
        private string notificationTitle;
        private bool notificationActive;
        private bool isPermissionRequest;
        private bool isTimed;
        private int notificationId;
        private int secondsLeft;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
        public int SecondsLeft
        {
            get
            {
                return this.secondsLeft;
            }

            set
            {
                if (value != this.secondsLeft)
                {
                    this.secondsLeft = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
        public bool IsTimed
        {
            get
            {
                return this.isTimed;
            }

            set
            {
                if (value != this.isTimed)
                {
                    this.isTimed = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
        public void CancelNotification()
        {
            NotificationActive = false;
            OnPropertyChanged();
        }
    }
}
