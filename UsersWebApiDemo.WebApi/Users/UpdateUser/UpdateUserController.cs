using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Service;

namespace UsersWebApiDemo.WebApi.Users.UpdateUser;

public class UpdateUserController : UserControllerBase
{
    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update-user")]
    [ApiKey]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<bool>>> UpdateUser(UpdateUserCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}
