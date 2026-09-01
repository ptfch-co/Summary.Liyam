namespace Summary.Liyam.Workflows.Task.Person.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePersonInLiyamViewModel
    {
        public string Title { get; set; }
        public string Group { get; set; }
        public string Region { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}