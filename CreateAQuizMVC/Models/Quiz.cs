namespace CreateAQuizMVC.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string Question1 { get; set; }
        public string Answer1A { get; set; }
        public string Answer1B { get; set; }
        public string Answer1C { get; set; }
        public string Answer1D { get; set; }
        public string RightAnswer1 { get; set; }
        public string Question2 { get; set; }
        public string Answer2A { get; set; }
        public string Answer2B { get; set; }
        public string Answer2C { get; set; }
        public string Answer2D { get; set; }
        public string RightAnswer2 { get; set; }
        public string Question3 { get; set; }
        public string Answer3A { get; set; }
        public string Answer3B { get; set; }
        public string Answer3C { get; set; }
        public string Answer3D { get; set; }
        public string RightAnswer3 { get; set; }
        public string Question4 { get; set; }
        public string Answer4A { get; set; }
        public string Answer4B { get; set; }
        public string Answer4C { get; set; }
        public string Answer4D { get; set; }
        public string RightAnswer4 { get; set; }
    }
}
