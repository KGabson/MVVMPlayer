using WindowsMediaPlayer;
using WindowsMediaPlayer.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsMediaPlayer
{
    public class PlayerModel : ObservableObject
    {
        #region Fields
        public System.Collections.ObjectModel.ObservableCollection<Media> Medias { get; set; }

        // PLAYLIST NAME
        public String Name { get; set; }

        // MEDIA INDEX
        public int CurrentIndex { get; set; }

        public PlayerModel()
        {
            Name = "";
            Medias = new System.Collections.ObjectModel.ObservableCollection<Media>();
            CurrentIndex = 0;
        }

        public void addMedia(Media toAdd)
        {
            Medias.Add(toAdd);
        }

        public void Previous()
        {
            if (CurrentIndex == 0)
                CurrentIndex = (Medias.Count() - 1);
            else
                CurrentIndex = CurrentIndex - 1;
        }
        public void Next()
        {
            if ((CurrentIndex + 1) == Medias.Count())
                CurrentIndex = 0;
            else
                CurrentIndex = CurrentIndex + 1;
        }
    }
    #endregion
}