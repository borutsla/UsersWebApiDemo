using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Service;

namespace UsersWebApiDemo.WebApi.Users.DeleteUser;

public class DeleteUserController : UserControllerBase
{
    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete-user")]
    [ApiKey]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<bool>>> DeleteUser(DeleteUserCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}
