using System;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.") : base(message)
    {
    }
}

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException() : base("Artist name should be between 3 and 20 symbols.")
    {
    }
}

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException() : base("Song name should be between 3 and 30 symbols.")
    {
    }
}

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException() : base("Invalid song length.")
    {
    }

    public InvalidSongLengthException(string message) : base(message)
    {
    }
}

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException() : base("Song minutes should be between 0 and 14.")
    {
    }
}

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException() : base("Song seconds should be between 0 and 59.")
    {
    }
}

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get { return this.artistName; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            this.artistName = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            this.songName = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        private set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        private set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            this.seconds = value;
        }
    }

    public int TotalSeconds
    {
        get { return this.minutes * 60 + this.seconds; }
    }
}


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int songsAdded = 0;
        int totalSeconds = 0;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] parts = line.Split(';');

            try
            {
                string artist = parts[0];
                string title = parts[1];
                string[] timeParts = parts[2].Split(':');

                int minutes = int.Parse(timeParts[0]);
                int seconds = int.Parse(timeParts[1]);

                Song song = new Song(artist, title, minutes, seconds);

                songsAdded++;
                totalSeconds += song.TotalSeconds;

                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int hours = totalSeconds / 3600;
        int minutesTotal = (totalSeconds % 3600) / 60;
        int secondsTotal = totalSeconds % 60;

        Console.WriteLine("Songs added: " + songsAdded);
        Console.WriteLine("Playlist length: " + hours + "h " + minutesTotal + "m " + secondsTotal + "s");
    }
}
