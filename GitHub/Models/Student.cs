namespace GitHub.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int RatingsId { get; set; }

        public Ratings Ratings { get; set; }

        public int TestId { get; set; }

        public Test Test { get; set; }

    }
}