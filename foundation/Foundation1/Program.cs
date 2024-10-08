using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("HOW to PROGRAM - Getting Started!", "Brackeys", 635);
        video1.AddComment(new Comment("hencytjoe", "Hope this helps someone!"));
        video1.AddComment(new Comment("waffelju395", "oh dear, here begins the journey of every programmer"));

        Video video2 = new Video("The Purple Mattress Passes The Raw Egg Test", "Purple", 29);
        video2.AddComment(new Comment("xyaz", "I ve done this at home myself and it actually works!!  Bravo!!!!"));
        video2.AddComment(new Comment("ash_kitten_101", "Purple, the only ads I don't skip."));

        List<Video> videos = new List<Video>{video1, video2};
        foreach(var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}