using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.ValueObjects;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Riok.Mapperly.Abstractions;

namespace CarStore.Hexagonal.Persistence.Postgres.Mapping
{
    [Mapper]
    public partial class UserMapper : IEntityMapper<User, UserEntity>
    {
        public partial UserEntity ToEntity(User user);
        public partial User ToDomain(UserEntity entity);

        private string MapEmail(UserEmail email) => email.Value;
        private UserEmail MapEmail(string value) => new(value);

        private string MapName(UserFullName name) => name.Value;
        private UserFullName MapName(string value) => new(value);
    }
}
