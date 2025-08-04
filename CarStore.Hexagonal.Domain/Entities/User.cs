using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.ValueObjects;

namespace CarStore.Hexagonal.Domain.Entities
{
    public class User : Entity<string>
    {
        public UserFullName FullName { get; private set; }
        public UserEmail Email { get; private set; }

        public User(UserFullName fullName, UserEmail email)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
        }

        public User(string id, UserFullName fullName, UserEmail email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        protected override void Validate()
        {
            // ValueObjects are self-validated. This would be useful for primitive-type properties.
        }
    }
}
