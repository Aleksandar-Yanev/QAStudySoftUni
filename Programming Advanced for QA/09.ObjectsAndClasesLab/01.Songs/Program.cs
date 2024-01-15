namespace _01.Songs
{
    internal class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOFSongs = int.Parse(Console.ReadLine());
            List<Song> listOfSongs = new List<Song>();

            for (int i = 0; i < numberOFSongs; i++)
            {
                string[] partsOfSong = Console.ReadLine().Split("_").ToArray();
                Song currentSong = new Song() 
                { 
                    TypeList = partsOfSong[0],
                    Name = partsOfSong[1],
                    Time = partsOfSong[2]
                };
                
                listOfSongs.Add(currentSong);
            }

            string command = Console.ReadLine();

            if (command != "all")
            {
                listOfSongs = listOfSongs.Where(x => x.TypeList == command).ToList();
            }

            foreach (Song song in listOfSongs)
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}