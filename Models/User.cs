namespace devalore_test_yonatan_koritny.Models
{
    public class User
    {

        public User(int id, string? name, string? gender, string? phone, string? country) 
        { 
            Id = id;
            Name = name;
            Gender = gender;
            Phone = phone;
            Location = country;
        }
        public int Id { get; set; }
        public string? Name { get; set;}

        public string? Gender { get; set; }

        public string? Location { get; set; }
        public int Age { get; set;}

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
