using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMVVMExample.Player
{
    public class Media
    {
        public Media(string a, string b)
        {
            Name = a;
            Path = b;
        }
        public String Name { get; set; }

        // PATH
        private String _Path;
        public String Path
        {
            get { return _Path; }
            set
            {
                _Path = value;
                if (System.IO.File.Exists(Path))
                {
                    Name = System.IO.Path.GetFileName(value);
                }
                else
                {
                    Name = Path;
                }
            }
        }
        public enum MediaType { MUSIC = 1, VIDEO = 2, PICTURE = 3 };
        public MediaType Type { get; set; }
    }
}
