using Microsoft.VisualBasic;

namespace LARTech.API.Entities
{
    public class Person
    {

        public Person() 
        {
            Phones = new List<PhoneNumbers>();
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateFormat BirthDate { get; set; }

        public List<PhoneNumbers> Phones { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string name, string cpf, DateFormat birthdate, bool isactive )
        {
          Name = name;
          CPF = cpf;
          BirthDate = birthdate;
          IsActive = isactive;
        }

        public void Delete()
        {
          IsDeleted = true;
        }

    
    }
}
