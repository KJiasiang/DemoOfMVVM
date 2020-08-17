using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Game1.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private Model.GameModel gameModel = new Model.GameModel();
        private Character[,] map = new Character[9, 9];
   
        public GameViewModel()
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    map[i, j] = new Character();
            }
        }

        #region Properties
        public int TurnLimit
        {
            get { return gameModel.TurnLimit; }
            set
            {
                gameModel.TurnLimit = value;
                RaisePropertyChaanged("TurnLimit");
            }
        }

        public AsyncObservableCollection<Character> Characters
        {
            get
            {
                if (gameModel.Characters == null)
                    gameModel.Characters = new AsyncObservableCollection<Character>();
                return gameModel.Characters;
            }

            set
            {
                gameModel.Characters = value;
                RaisePropertyChaanged("Characters");
            }
        }

        public System.Windows.Visibility StartVisible
        {
            get
            {
                return gameModel.StartVisible;
            }
            set
            {
                gameModel.StartVisible = value;
                RaisePropertyChaanged("StartVisible");
            }
        }

        public System.Windows.Visibility StopVisible
        {
            get
            {
                return gameModel.StopVisible;
            }
            set
            {
                gameModel.StopVisible = value;
                RaisePropertyChaanged("StopVisible");
            }
        }

        public bool StartEnable
        {
            get
            {
                return gameModel.StartEnable;
            }
            set
            {
                gameModel.StartEnable = value;
                RaisePropertyChaanged("StartEnable");
            }
        }

        public bool StoptEnable
        {
            get
            {
                return gameModel.StoptEnable;
            }
            set
            {
                gameModel.StoptEnable = value;
                RaisePropertyChaanged("StoptEnable");
            }
        }

        public System.Windows.Visibility BlockVisible
        {
            get
            {
                return gameModel.BlockVisible;
            }
            set
            {
                gameModel.BlockVisible = value;
                RaisePropertyChaanged("BlockVisible");
            }
        }

        public string BlockText
        {
            get
            {
                return gameModel.BlockText;
            }
            set
            {
                gameModel.BlockText = value;
                RaisePropertyChaanged("BlockText");
            }
        }

        public bool MoveEnable
        {
            get
            {
                return gameModel.MoveEnable;
            }
            set
            {
                gameModel.MoveEnable = value;
            }
        }
        #endregion

        #region Commands      
        public ICommand StartGame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("StartGame");
                    Task.Run(() => InitialGame());
                }, () => { return StartEnable; });
            }
        }
        private void InitialGame()
        {
            // ShowTextBlock("START");
            StartEnable = false;
            StopVisible = System.Windows.Visibility.Visible;
            StartVisible = System.Windows.Visibility.Hidden;
            //   HideTextBlock();
            //  StoptEnable = true;
            StartLevel_1();
            StoptEnable = true;
        }
        private void StartLevel_1()
        {
            ShowTextBlock("Level 1");
            TurnLimit = 10;
            AddPlayer(0, 4, 4);
            AddEnemy(0, 0, 0);
            AddEnemy(0, 0, 8);
            AddEnemy(0, 8, 0);
            AddEnemy(0, 8, 8);
            AddEnemy(0, 0, 4);
            AddEnemy(0, 4, 0);
            AddEnemy(0, 8, 4);
            AddEnemy(0, 4, 8);
            HideTextBlock();
            MoveEnable = true;
        }

        public ICommand StopGame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("StopGame");
                    TurnLimit = 0;
                    StoptEnable = false;
                    StopVisible = System.Windows.Visibility.Hidden;
                    StartVisible = System.Windows.Visibility.Visible;
                    StartEnable = true;
                    ClearMap();
                }, () => { return StoptEnable; });
            }
        }

        public ICommand LeaveGame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("LeaveGame");
                    System.Windows.Application.Current.Shutdown();
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    for (int j = 0; j < 9; j++)
                    //        Console.Write("{0} ", map[i, j].Type);
                    //    Console.WriteLine("");
                    //}
                });
            }
        }

        public ICommand MoveRight
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("MoveRight");
                    MovePlayer(MoveDirection.RIGHT);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand MoveLeft
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("MoveLeft");
                    MovePlayer(MoveDirection.LEFT);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand MoveUp
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("MoveUp");
                    MovePlayer(MoveDirection.UP);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand MoveDown
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("MoveDown");
                    MovePlayer(MoveDirection.DOWN);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand DashRight
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("DashRight");
                    DashPlayer(MoveDirection.RIGHT);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand DashLeft
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("DashLeft");
                    DashPlayer(MoveDirection.LEFT);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand DashUp
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("DashUp");
                    DashPlayer(MoveDirection.UP);
                }, () => { return MoveEnable; });
            }
        }

        public ICommand DashDown
        {
            get
            {
                return new RelayCommand(() =>
                {
                    My.WriteConsole("DashDown");
                    DashPlayer(MoveDirection.DOWN);
                }, () => { return MoveEnable; });
            }
        }

        private void MovePlayer(MoveDirection direction)
        {
            MoveEnable = false;
            Character newCharacter = Characters[0].Move(direction);
            Step2(newCharacter);            
        }
        private void DashPlayer(MoveDirection direction)
        {
            MoveEnable = false;
            Character newCharacter = Characters[0].Dash(direction);
            Step2(newCharacter);
        }

        private void Step2(Character newPlayer)
        {
            if (Characters[0].CompareXYIsSame(newPlayer))
            {
                MoveEnable = true;
                return;
            }
            else
            {
                Characters[0] = newPlayer;
            }

            if (MoveEnemy())
                MoveEnable = true;
            TurnLimit--;
        }

        private bool MoveEnemy()
        {
            Character player = Characters[0];
            for (int i = 1; i < Characters.Count; i++)
            {
                if (Math.Abs(Characters[i].X - player.X) > Math.Abs(Characters[i].Y - player.Y))
                {
                    if (Characters[i].X > player.X)
                        Characters[i] = Characters[i].MoveLeft();
                    else
                        Characters[i] = Characters[i].MoveRight();
                }
                else
                {
                    if (Characters[i].Y > player.Y)
                        Characters[i] = Characters[i].MoveUp();
                    else
                        Characters[i] = Characters[i].MoveDown();
                }
                if (Characters[i].CompareXYIsSame(player))
                    return false;
            }
            return true;
        }
        #endregion


        private void ShowTextBlock(string text)
        {
            BlockText = text;
            BlockVisible = System.Windows.Visibility.Visible;
        }

        private void HideTextBlock()
        {
            My.SleepSeconds(3);
            BlockVisible = System.Windows.Visibility.Hidden;
        }

        private void ClearMap()
        {
            Characters.Clear();
        }

        private void AddPlayer(int id, int x, int y)
        {
            Characters.Add(new Player(id, x, y));
            map[y, x].Type = CharaterType.PLAYER;
        }

        private void AddEnemy(int id, int x, int y)
        {
            Characters.Add(new Enemy(id, x, y));
            map[y, x].Type = CharaterType.ENEMY;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChaanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
