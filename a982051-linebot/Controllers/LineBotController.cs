using A982051_linebot;
using Line.Messaging;
using Microsoft.AspNetCore.Mvc;





namespace a982051_linebot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : ControllerBase
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;
        private readonly LineBotConfig _lineBotConfig;
        
        public LineBotController(IServiceProvider serviceProvider)
        {
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _httpContext = _httpContextAccessor.HttpContext;
            _lineBotConfig = new LineBotConfig();
            _lineBotConfig.channelSecret = "8a88a579a14c5de296f4c3793febb9c0";
            _lineBotConfig.accessToken = "e5EsBr2wvlT31s3h2AhkBOGtbn+8Zwkk4d7StjWnPLQ4TIuEs9vhNH9U4Gney+fi0SJU8H8coayEqpJ3ZizUkrtDOGB5U71AzfouCbRXTTqAhRNzzhjRmtTBanzUxm6obUFtAPtVrbGYNJhqdP 0PpwdB04t89/1O/w1cDnyilFU=";
        }
        
        //完整的路由網址就是 https://xxx/api/linebot/run
        [HttpPost("run")]
        public async Task<IActionResult> Post()
        {
            try
            {
                var events = await _httpContext.Request.GetWebhookEventsAsync(_lineBotConfig.channelSecret);
                var lineMessagingClient = new LineMessagingClient(_lineBotConfig.accessToken);
                var lineBotApp = new LineBotApp(lineMessagingClient);
                await lineBotApp.RunAsync(events);
            }
            catch (Exception ex)
            {
                //需要 Log 可自行加入
                //_logger.LogError(JsonConvert.SerializeObject(ex));
            }
            return Ok();
        }
        }
    }
