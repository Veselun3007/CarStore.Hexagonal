using CarStore.Hexagonal.Domain.Entities;

namespace CarStore.Hexagonal.Application.Features.Users.Common
{
    public class UserResult
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
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
