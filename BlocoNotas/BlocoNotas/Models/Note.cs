using System;
using System.Collections.Generic;
using System.Text;

namespace BlocoNotas.Models
{
    public class Note
    {
        public Note(string title, string path, string description)
        {
            Title = title;
            Path = path;
            Description = description;
        }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
