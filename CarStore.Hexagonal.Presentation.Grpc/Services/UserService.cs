using CarStore.Hexagonal.Application.Features.Users.Commands.DeleteUser;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetAllUser;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetUserById;
using CarStore.Hexagonal.Presentation.Grpc.Mappers;
using Grpc.Core;
using MediatR;

namespace CarStore.Hexagonal.Presentation.Grpc.Services
{
    public class UserService : UserGrpcService.UserGrpcServiceBase
    {

        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GetAllUsersResponse> GetAllUser(GetAllUserReques request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            if(!result.Any())
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No users found"));
            }

            var response = new GetAllUsersResponse();
            response.Users.AddRange(result.Select(UserGrpcMapper.ToGrpcDto));
            return response;
        }

        public override async Task<UserResponse> GetUserById(GetUserByIdRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { UserId = request.UserId });

            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"User with ID '{request.UserId}' not found"))
                : UserGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<UserResponse> AddUser(AddUserRequest request, ServerCallContext context)
        {
            var command = UserGrpcMapper.ToCommand(request);
            var result = await _mediator.Send(command);
            return UserGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new DeleteUserCommand { UserId = request.UserId });

            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"User with ID '{request.UserId}' not found"))
                : new DeleteUserResponse { Message = "Deleted successful" };
        }
    }
}
