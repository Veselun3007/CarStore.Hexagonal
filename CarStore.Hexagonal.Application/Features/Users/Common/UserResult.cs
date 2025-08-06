using CarStore.Hexagonal.Domain.Entities;
using HotChocolate;

namespace CarStore.Hexagonal.Application.Features.Users.Common
{
    public class UserResult
    {
        [GraphQLName("userId")]
        public string UserId { get; set; }

        [GraphQLName("fullName")]
        public string FullName { get; set; }

        [GraphQLName("email")]
        public string Email { get; set; }

        public static UserResult FromEntity(User user)
        {
            return new UserResult
            {
                UserId = user.Id,
                FullName = user.FullName.Value,
                Email = user.Email.Value
            };
        }
    }
}
