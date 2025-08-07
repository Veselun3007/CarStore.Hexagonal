using CarStore.Hexagonal.Application.Features.Users.Commands.AddUser;
using CarStore.Hexagonal.Application.Features.Users.Common;

namespace CarStore.Hexagonal.Presentation.Grpc.Mappers
{
    public static class UserGrpcMapper
    {
        public static AddUserCommand ToCommand(AddUserRequest request)
        {
            return new AddUserCommand
            {
                FullName = request.FullName,
                Email = request.Email
            };
        }

        public static UserResponse ToGrpcDto(UserResult result)
        {
            return new UserResponse
            {
                UserId = result.UserId,
                FullName = result.FullName,
                Email = result.Email
            };
        }
    }
}
