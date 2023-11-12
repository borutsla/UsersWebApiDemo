using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Common.Users;

namespace UsersWebApiDemo.WebApi.Users.GetUser;

public class GetUserController : UserControllerBase
{
    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("get-user")]
    [ApiKey]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<UserDto>>> DeleteUser(GetUserRequest request, CancellationToken ct)
    {
        return Ok(await Mediator.Send(request, ct));
    }
}
