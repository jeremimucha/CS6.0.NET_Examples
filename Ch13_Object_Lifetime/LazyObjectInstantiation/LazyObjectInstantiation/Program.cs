using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            // This caller does not care about getting
            // all songs, but indirectly created 10,000 objects!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            // After updating with the Lazy<> wrapper class
            // Allocation of AllTracks happens when you call GetAllTracks()
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();

            Console.ReadLine();
        }
    }
}
