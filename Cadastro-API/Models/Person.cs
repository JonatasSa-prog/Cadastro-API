namespace Cadastro_API.Models
{
    public class Person
    {
        public Person()
        {
            this.active = true;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public DateTime birth { get; set; }
        public bool active { get; set; }
    }
}
