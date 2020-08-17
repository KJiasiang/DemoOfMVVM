using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.ViewModel.Model
{
    class GameModel
    {
        public int TurnLimit
        {
            get;set;
        }

        public AsyncObservableCollection<Character> Characters
        {
            get;set;
        }

        public System.Windows.Visibility StartVisible
        {
            get;set;
        }

        public System.Windows.Visibility StopVisible
        {
            get; set;
        }

        public System.Windows.Visibility BlockVisible
        {
            get; set;
        }

        public bool StartEnable
        {
            get;set;
        }

        public bool StoptEnable
        {
            get; set;
        }

        public string BlockText
        {
            get;set;
        }

        public bool MoveEnable
        {
            get;set;
        }
        
        public GameModel()
        {
            MoveEnable = false;
            StartEnable = true;
            StartVisible = System.Windows.Visibility.Visible;
            StoptEnable = false;
            StopVisible = System.Windows.Visibility.Hidden;
            BlockVisible = System.Windows.Visibility.Hidden;
            BlockText = "Level 1";
        }
    }
}
