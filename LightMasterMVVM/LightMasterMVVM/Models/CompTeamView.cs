using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class CompTeamView
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<TeamMatchView> _team_matches;
        public ObservableCollection<TeamMatchView> team_matches
        {
            get
            {
                return this._team_matches;
            }

            set
            {
                if (value != this._team_matches)
                {
                    this._team_matches = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _team_number;
        public int team_number
        {
            get
            {
                return this._team_number;
            }

            set
            {
                if (value != this._team_number)
                {
                    this._team_number = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _match_progress;
        public string match_progress
        {
            get
            {
                return this._match_progress;
            }

            set
            {
                if (value != this._match_progress)
                {
                    this._match_progress = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool _has_matches;
        public bool has_matches
        {
            get
            {
                return this._has_matches;
            }

            set
            {
                if (value != this._has_matches)
                {
                    this._has_matches = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _rated_tier;
        public string rated_tier
        {
            get
            {
                return this._rated_tier;
            }

            set
            {
                if (value != this._rated_tier)
                {
                    this._rated_tier = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
