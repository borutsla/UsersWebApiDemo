using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Users.AddUser;

namespace UsersWebApiDemo.WebApi.Users.AddUser;

public class AddUserController : AuthControllerBase
{
    /// <summary>
    /// Add user
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("add-user")]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<bool>>> AddUser(AddUserCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}
