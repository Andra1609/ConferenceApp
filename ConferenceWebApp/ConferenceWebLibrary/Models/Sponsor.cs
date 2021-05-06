namespace ConferenceWebLibrary.Models
{
    public class Sponsor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }

        // a company can sponsor only one conference
        public virtual Conference Conference { get; set; }
    }
}
