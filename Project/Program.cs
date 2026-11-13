using System;
using System.Collections.Generic;
class Song
{
    string name = "";
    string author = "";
    Song? prev;
    public void SetName(string songName)
    {
        name = songName;
    }
    public void SetAuthor(string songAuthor)
    {
        author = songAuthor;
    }
    public void SetPrev(Song? song)
    {
        prev = song;
    }
    public void Print()
    {
        Console.WriteLine("Название: " + name);
        Console.WriteLine("Автор: " + author);
    }
    public string Title()
    {
        return name + " - " + author;
    }
    public override bool Equals(object? d)
    {
        if (d is Song song)
        {
            return Title() == song.Title();
        }
        return false;
    }
    public override int GetHashCode()
    {
        return Title().GetHashCode();
    }
}
class Program
{
    static void Main()
    {
        List<Song> songs = new List<Song>();
        Song song1 = new Song();
        song1.SetName("Династия");
        song1.SetAuthor("VILLIAN, madk1d");
        song1.SetPrev(null);
        Song song2 = new Song();
        song2.SetName("Экспонат");
        song2.SetAuthor("MIA BOYKA");
        song2.SetPrev(song1);
        Song song3 = new Song();
        song3.SetName("Кинолента");
        song3.SetAuthor("Баста");
        song3.SetPrev(song2);
        Song song4 = new Song();
        song4.SetName("Завидуют");
        song4.SetAuthor("Платина");
        song4.SetPrev(song3);
        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);
        songs.Add(song4);
        foreach (Song song in songs)
        {
            song.Print();
            Console.WriteLine();
        }
        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("Песни одинаковые.");
        }
        else
        {
            Console.WriteLine("Песни разные.");
        }
    }
}
