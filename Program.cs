using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SongApp 
{
    [Flags]
    public enum SongGenre
    {
        Unclassified = 0,
        Pop = 0b1,
        Rock = 0b10,
        Blues = 0b100,
        Country = 0b1_000,
        Metal = 0b10_000,
        Soul = 0b100_000
    }
    public class Song
    {   
        public string Title { get; }               //using getters to get values
        public string Artist { get; }
        public double Length { get; }
        public SongGenre Genre { get; }

        public Song(string title, string artist, double length, SongGenre genre)   //creating constructor to give values to variables
        {
            this.Title = title;
            this.Artist = artist;
            this.Length = length;
            this.Genre = genre;
        }
        public override string ToString()    //to display values
        { 
            //Tostring() method to display values
            return string.Format($"{Title} by {Artist} ({Genre.ToString()}) {Length} min"); 
        }
        
        public static class Library
        {
            private static List<Song> songs = new List<Song>();
            public static void DisplaySongs()
            {
                foreach (Song s in songs)
                {   
                    //prints all songs 
                    Console.WriteLine(s.ToString());
                }
            }
            public static void DisplaySongs(double longerThan)
            {
                foreach (Song s in songs)
                {
                    if (s.Length > longerThan)       //checks datatype of length variable
                    {
                        Console.WriteLine(s.ToString());
                    }
                }

            }
            public static void DisplaySongs(SongGenre genre)
            {
                foreach (Song s in songs)
                {
                    if (s.Genre == genre)        //compares genre and prints values
                    {
                        Console.WriteLine(s.ToString());
                    }
                }
            }
            public static void DisplaySongs(string artist)
            {
                foreach (Song s in songs)
                {
                    if (s.Artist == artist)   //compares artist and prints values
                    {
                        Console.WriteLine(s.ToString());
                    }
                }
            }

            public static void LoadSongs(string filename)  //creates a static class loadsongs
            {

                StreamReader reader = new StreamReader(filename);
                string title;
                string artist;
                string length;
                string genre;
                while ((title = reader.ReadLine()) != null)
                {
                    artist = reader.ReadLine();
                    length = reader.ReadLine();
                    genre = reader.ReadLine();
                    
                    Song s1 = new Song(title, artist, Convert.ToDouble(length), (SongGenre)Enum.Parse(typeof(SongGenre), genre));
                    songs.Add(s1);
                }
            }
        }
        public static void Main(String[] args)

        {
            //To test the constructor and the ToString method

            Console.WriteLine(new Song("Baby", "Justin Bebier", 3.35, SongGenre.Pop));

            //This is first time that you are using the bitwise or. It is used to specify a combination of genres

            Console.WriteLine(new Song("The Promise", "Chris Cornell", 4.26, SongGenre.Country | SongGenre.Rock));
            Library.LoadSongs("Week_03_lab_09_songs4.txt");     //Class methods are invoke with the class name

            //Displays all songs
            Console.WriteLine("\n\nAll songs");
            Library.DisplaySongs();

            SongGenre genre = SongGenre.Rock;
            //Displays Rock songs
            Console.WriteLine($"\n\n{genre} songs");
            Library.DisplaySongs(genre);

            string artist = "Bob Dylan";
            //Displays songs by Bob Dylan
            Console.WriteLine($"\n\nSongs by {artist}");
            Library.DisplaySongs(artist);

            double length = 5.0;
            Console.WriteLine($"\n\nSongs more than {length}mins");
            Library.DisplaySongs(length);
        }
    }
} 

