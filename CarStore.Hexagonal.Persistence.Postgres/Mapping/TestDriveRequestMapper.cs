using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Riok.Mapperly.Abstractions;

namespace CarStore.Hexagonal.Persistence.Postgres.Mapping
{
    [Mapper]
    public partial class TestDriveRequestMapper : IEntityMapper<TestDriveRequest, TestDriveRequestEntity>
    {
        public partial TestDriveRequestEntity ToEntity(TestDriveRequest request);
        public partial TestDriveRequest ToDomain(TestDriveRequestEntity entity);
    }
}
