using Application.Repositories;
using Application.Requests.User.Commands;
using Application.Responses.User;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.User.Commands
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommandDto, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        public EditProfileCommandHandler(IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<Domain.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        async Task<UserDto> IRequestHandler<EditProfileCommandDto, UserDto>.Handle(EditProfileCommandDto request, CancellationToken cancellationToken)
        {
            try
            {

                var user = _mapper.Map<Domain.Entities.User>(request.userDto);
                if (!string.IsNullOrEmpty(user.Password))
                    user.Password = _passwordHasher.HashPassword(null, user.Password);
                else
                    user.Password = (await _userRepository.GetByConditionAsync(u => u.Id == user.Id))?.Password;
                var result = await _userRepository.UpdateAsync(user);
                if (result > 0)
                    return request.userDto;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
