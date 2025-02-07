using System;
using System.Collections.Generic;

namespace YouTubeVideos
{

    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

   
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; private set; } // List of comments

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }


        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

 
        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        
            List<Video> videos = new List<Video>
            {
                new Video("Video Title 1", "Author 1", 300),
                new Video("Video Title 2", "Author 2", 150),
                new Video("Video Title 3", "Author 3", 240)
            };

           
            videos[0].AddComment(new Comment("User A", "Great video! Thanks for sharing."));
            videos[0].AddComment(new Comment("User B", "I learned a lot from this."));
            videos[0].AddComment(new Comment("User C", "Awesome content!"));

            videos[1].AddComment(new Comment("User D", "Nice explanation."));
            videos[1].AddComment(new Comment("User E", "Could you please add more examples?"));

            videos[2].AddComment(new Comment("User F", "Very informative."));
            videos[2].AddComment(new Comment("User G", "I disagree with some points."));
            videos[2].AddComment(new Comment("User H", "Looking forward to more content!"));

            
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");

                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}
