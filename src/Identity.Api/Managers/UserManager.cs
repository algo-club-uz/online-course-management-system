using CommonFiles.Entities.Enums;
using CommonFiles.Models.CommonModels;
using Identity.Api.Entities;
using Identity.Api.Exceptions;
using Identity.Api.Models;
using Identity.Api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Managers;

public class UserManager
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenManager _jwtTokenManager;

    public UserManager(JwtTokenManager jwtTokenManager, IUserRepository userRepository)
    {
        _jwtTokenManager = jwtTokenManager;
        _userRepository = userRepository;
    }


    public async Task<UserModel> Register(CreateUserModel model)
    {
        if (await _userRepository.IsUserNameExist(model.Username))
        {
            throw new UsernameExistException(model.Username);
        }
        var user = new User()
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Username = model.Username,
            UserRole = ERole.User
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user,model.Password);
        await _userRepository.AddUser(user);
        return ParseToUserModel(user);
    }

    public async Task<string> Login(LoginUserModel model)
    {
        var userName = await _userRepository.GetUserByUserName(model.Username);
        var result = new PasswordHasher<User>().
            VerifyHashedPassword(userName, userName.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new InCorrectPassword(model.Password);
        }
        var token = _jwtTokenManager.GenerateToken(userName);
        return token;
    }

    public async Task<UserModel?> GetUser(string username)
    {
        var user= await _userRepository.GetUserByUserName(username);
        return ParseToUserModel(user);
    }
    public async Task<UserModel?> GetUser(Guid id)
    {
        var user= await _userRepository.GetUserById(id);
        return ParseToUserModel(user);
    }

    private UserModel ParseToUserModel(User user)
    {
        var model = new UserModel()
        {
            UserId = user.UserId,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            CreateDate = user.CreateDate,
            Username = user.Username,
            UserRole = user.UserRole
        };
        return model;
    }
}