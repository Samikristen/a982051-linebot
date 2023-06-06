using Line.Messaging;
using Line.Messaging.Webhooks;

namespace A982051_linebot;

public class LineBotApp : WebhookApplication
{
    private readonly LineMessagingClient _messagingClient;
    public LineBotApp(LineMessagingClient lineMessagingClient)
    {
        _messagingClient = lineMessagingClient;
    }

    protected override async Task OnMessageAsync(MessageEvent ev)
    {
        var result = null as List<ISendMessage>;

        switch (ev.Message)
        {
            //文字訊息
            case TextEventMessage textMessage:
            {
                //頻道Id
                var channelId = ev.Source.Id;
                //使用者Id
                var userId = ev.Source.UserId;
                    
                //回傳 hellow
                result = new List<ISendMessage>
                {
                    new TextMessage("你怎麼這麼可憐，只能跑來和機器人說話")
                };
                //回傳 B站Vup推薦
                result = new List<ISendMessage>
                {
                    new TextMessage("長庚和尤塞斯，一個可愛夢魔一個日系男二")
                };
                //回傳 Vtuber推薦
                result = new List<ISendMessage>
                {
                    new TextMessage("holostars!")
                };
                //回傳 NT
                result = new List<ISendMessage>
                {
                    new TextMessage("壓榨盤古和老張的糟糕狒狒")
                };
            }
                break;
        }

        if (result != null)
            await _messagingClient.ReplyMessageAsync(ev.ReplyToken, result);
    }
}