using LARTech.API.Entities;

namespace LARTech.API.Persistence
{
    public class LarTechDbContext
    {
        public List<Person> Persons { get; set; }

        public LarTechDbContext() 
        { 
            Persons = new List<Person>();
        }
    }
}
