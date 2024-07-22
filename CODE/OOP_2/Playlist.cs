using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Playlist
    {
        public List<MusicTracks> Songs { get; set; }
        //public List<MusicTracks> AddSongs(string userInputTitle, string userInputGenre)
        //{
        //    var playlist = new List<MusicTracks>();
        //    foreach (var song in Songs)
        //    {
        //        song.Title = userInputTitle;
        //        song.Genre = userInputGenre;
        //        playlist.Add(song.Title, song.Genre);
        //    }
        //}
    }
}
