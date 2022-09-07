namespace api_dev_week.src.Models
{
    public class Person
    {
        public Person()
        {
            this.Name = "template";
            this.Age = 0;
            this.Contracts = new List<Contract>();
        }
        public Person(string Name, int Age, string Cpf)
        {
            this.Name = Name;
            this.Age = Age;
            this.Cpf = Cpf;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Cpf { get; set; }
        public bool Activate { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
