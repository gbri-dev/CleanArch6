using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    //definir como sealed garante que essa classe não pode ser herdada
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }
        //vamos permitir que nossa classe seja acrescentado usando um construtor parametrizado
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        //Método para poder alterar o nome
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        //Uma categoria pode ter 1 ou mais produtos
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name.Name is requred");
            DomainExceptionValidation.When(name.Length < 3, 
                "Invalid name, too short, minimum 3 characters");
            Name = name;
        }
    }
}
