using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleMVVMExample
{
    public class PlayerViewModel : ObservableObject, IPageViewModel
    {
        private MediaElement myMedia;
        public PlayerViewModel()
        {
            MediaElementObject = new MediaElement();
            myMedia.LoadedBehavior = MediaState.Manual;
        }
        public string Name
        {
            get
            {
                return "Player Page";
            }
        }

        public MediaElement MediaElementObject
        {
            get { return myMedia; }
            set { myMedia = value;
                 }
        }


        int i = 1;
        private ICommand _playCommand;
        private ICommand _pauseCommand;
        private ICommand _stopCommand;
        private ICommand _loadMediaCommand;
        public ICommand playCommand
        {
            get
            {
                return _playCommand ?? (_playCommand = new CommandHandler(() => playMedia(), _canExecute));
            }
        }

        public ICommand loadMediaCommand
        {
            get
            {
                return _loadMediaCommand ?? (_loadMediaCommand = new CommandHandler(() => loadMedia(), _canExecute));
            }
        }

        public ICommand stopCommand
        {
            get
            {
                return _stopCommand ?? (_stopCommand = new CommandHandler(() => stopMedia(), _canExecute));
            }
        }
        public ICommand pauseCommand
        {
            get
            {
                return _pauseCommand ?? (_pauseCommand = new CommandHandler(() => pauseMedia(), _canExecute));
            }
        }

        private bool _canExecute = true;
        public void playMedia()
        {
            Console.WriteLine("play" + i);
            i += 1;
            myMedia.Play();
        }

        public void loadMedia()
        {
            Console.WriteLine("LOAD" + i);
            i += 1;
            OpenFileDialog openMedia = new OpenFileDialog();
            openMedia.Title = "Open Media";
            //openMedia.Filter = "mp4 files(*.mp4)|*.mp4";
            openMedia.InitialDirectory = @"C:\";
            openMedia.RestoreDirectory = true;
            if (openMedia.ShowDialog() == true)
            {
                myMedia.Source = new Uri(openMedia.FileName);
                myMedia.Position = TimeSpan.FromSeconds(1);
                myMedia.Play();
            }
        }
        public void pauseMedia()
        {
            Console.WriteLine("pause" + i);
            i += 1;
            myMedia.Pause();
        }

        public void stopMedia()
        {
            Console.WriteLine("stop" + i);
            i += 1;
            myMedia.Stop();
        }
    }
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}

