using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowsMediaPlayer
{
    public class PlayerViewModel : ObservableObject, IPageViewModel
    {
        private MediaElement myMedia;
        private XML fileMedias = new XML();
        private PlayerModel Playlist = new PlayerModel();
        //List<Tuple<String, Boolean>> mediasList
        public PlayerViewModel()
        {
            MediaElementObject = new MediaElement();
            myMedia.LoadedBehavior = MediaState.Manual;
            fileMedias.Load("Medias");
            //if (fileMedias.HasMedia("Media") == true)
            Playlist.Medias = fileMedias.GetMedias();
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
            set { myMedia = value; }
        }

        private ICommand _playCommand;
        private ICommand _pauseCommand;
        private ICommand _stopCommand;
        private ICommand _loadMediaCommand;
        private ICommand _prevCommand;
        private ICommand _nextCommand;

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
        public ICommand prevCommand
        {
            get
            {
                return _prevCommand ?? (_prevCommand = new CommandHandler(() => prevMedia(), _canExecute));
            }
        }
        public ICommand nextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new CommandHandler(() => nextMedia(), _canExecute));
            }
        }

        private bool _canExecute = true;
        public void playMedia()
        {
            myMedia.Source = new Uri(Playlist.Medias[Playlist.CurrentIndex].Path);
            myMedia.Position = TimeSpan.FromSeconds(1);
            myMedia.Play();
        }

        public void loadMedia()
        {
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

            // Tout d'abord load le XML (constructeur)
            // PlayerModel = Playlist

            Playlist.addMedia(new Player.Media(openMedia.FileName, openMedia.FileName));
            // check si il est pas déja ajouté ? 
            fileMedias.Add(openMedia.FileName, false);
            // lancé le write
            fileMedias.WriteInFile("Medias");

            // rajouter a la playlist
        }
        public void prevMedia()
        {
            Playlist.Previous();
            myMedia.Source = new Uri(Playlist.Medias[Playlist.CurrentIndex].Path);
            myMedia.Position = TimeSpan.FromSeconds(1);
            myMedia.Play();
        }

        public void nextMedia()
        {
            Playlist.Next();
            myMedia.Source = new Uri(Playlist.Medias[Playlist.CurrentIndex].Path);
            myMedia.Position = TimeSpan.FromSeconds(1);
            myMedia.Play();
        }

        public void pauseMedia()
        {
            myMedia.Pause();
        }

        public void stopMedia()
        {
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

