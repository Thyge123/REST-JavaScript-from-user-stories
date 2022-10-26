namespace REST___JavaScript_from_user_stories.Models
{
    public class Record
    {
        public string Title {get; set;}
        public string Artist { get; set; }

        public int Duration { get; set; }
        public DateTime Publication { get; set; }

        public int Id { get; set; }

        public Record()
        {
                
        }

        public Record(int id, string title, string artist, int duration, DateTime publication)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            Publication = publication;
        }

        public override string ToString()
        {
            return $"{{{nameof(Title)}={Title}, {nameof(Artist)}={Artist}, {nameof(Duration)}={Duration.ToString()}, {nameof(Publication)}={Publication.ToString()}, {nameof(Id)}={Id.ToString()}}}";
        }
    }
}
