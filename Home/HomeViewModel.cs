using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsMediaPlayer
{
    public class HomeViewModel: ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Playlists";
            }
        }
    }
}
