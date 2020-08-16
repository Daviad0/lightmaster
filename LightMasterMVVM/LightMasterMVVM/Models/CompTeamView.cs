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
        private int _a_pc_inner_avg;
        public int a_pc_inner_avg
        {
            get
            {
                return this._a_pc_inner_avg;
            }

            set
            {
                if (value != this._a_pc_inner_avg)
                {
                    this._a_pc_inner_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _a_pc_outer_avg;
        public int a_pc_outer_avg
        {
            get
            {
                return this._a_pc_outer_avg;
            }

            set
            {
                if (value != this._a_pc_outer_avg)
                {
                    this._a_pc_outer_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _a_pc_lower_avg;
        public int a_pc_lower_avg
        {
            get
            {
                return this._a_pc_lower_avg;
            }

            set
            {
                if (value != this._a_pc_lower_avg)
                {
                    this._a_pc_lower_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _a_pc_missed_avg;
        public int a_pc_missed_avg
        {
            get
            {
                return this._a_pc_missed_avg;
            }

            set
            {
                if (value != this._a_pc_missed_avg)
                {
                    this._a_pc_missed_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _t_pc_inner_avg;
        public int t_pc_inner_avg
        {
            get
            {
                return this._t_pc_inner_avg;
            }

            set
            {
                if (value != this._t_pc_inner_avg)
                {
                    this._t_pc_inner_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _t_pc_outer_avg;
        public int t_pc_outer_avg
        {
            get
            {
                return this._t_pc_outer_avg;
            }

            set
            {
                if (value != this._t_pc_outer_avg)
                {
                    this._t_pc_outer_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _t_pc_lower_avg;
        public int t_pc_lower_avg
        {
            get
            {
                return this._t_pc_lower_avg;
            }

            set
            {
                if (value != this._t_pc_lower_avg)
                {
                    this._t_pc_lower_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _t_pc_missed_avg;
        public int t_pc_missed_avg
        {
            get
            {
                return this._t_pc_missed_avg;
            }

            set
            {
                if (value != this._t_pc_missed_avg)
                {
                    this._t_pc_missed_avg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _t_num_cycles;
        public int t_num_cycles
        {
            get
            {
                return this._t_num_cycles;
            }

            set
            {
                if (value != this._t_num_cycles)
                {
                    this._t_num_cycles = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _avg_cycle_time;
        public string avg_cycle_time
        {
            get
            {
                return this._avg_cycle_time;
            }

            set
            {
                if (value != this._avg_cycle_time)
                {
                    this._avg_cycle_time = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
