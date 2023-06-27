using AgendaTech.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTech.Api.Controllers
{
    public class AgendaControllerBase<T> : ControllerBase
    {
        protected IActionResult ResponseGet(object? obj, bool errorWhenNull = true)
        {
            if (obj == null && errorWhenNull)
                return NotFound();

            if (obj == null && !errorWhenNull)
                return NoContent();

            return Ok(new SuccessResponse(obj));
        }

        protected IActionResult ResponsePost(string? mensagem, object? obj = null)
        {
            return Ok(new SuccessResponse(obj, mensagem));
        }
    }
}
