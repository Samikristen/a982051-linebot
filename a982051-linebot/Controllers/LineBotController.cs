using A982051_linebot;
using Microsoft.AspNetCore.Mvc;

namespace a982051_linebot.Controllers;

public class LineBotController
{
    
    [Route("api/linebot")]
    public class LineBotController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;
        private readonly LineBotConfig _lineBotConfig;

        public LineBotController(IServiceProvider serviceProvider,
            LineBotConfig lineBotConfig)
        {
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _httpContext = _httpContextAccessor.HttpContext;
            _lineBotConfig = new LineBotConfig();
            _lineBotConfig.channelSecret = "";
            _lineBotConfig.accessToken = ""
        }

        //完整的路由網址就是 https://xxx/api/linebot/run
        [HttpPost("run")]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}