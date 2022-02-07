using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using testbot.Services;

namespace testbot.Controllers
{
    public class webhookController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                             [FromBody] Update update)
        {
            await handleUpdateService.EchoAsync(update);
            
            return Ok();
        }
    }
}
