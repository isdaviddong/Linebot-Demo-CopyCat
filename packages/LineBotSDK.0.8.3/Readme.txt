================================================
LineBot SDK for .NET (Line@ Messaging API, Line Login, Line Notify supported)
This is a .net SDK for developing LineBot
The minimum .NET version support is .NET 4.5.1
================================================
Example of use
https://github.com/isdaviddong/LineBotSdkExample

How to use (Chinese):
http://studyhost.blogspot.tw/search/label/LineBot

Supported:
> text, image, sticker, template message Push and Reply
> Group / Chat room Talk
> LineWebHookControllerBase
> LineNotify, LineLogin
> Flex Message
> Liff
> QuickReply

===================== Easy to use ==================
Push Message : 
isRock.LineBot.Utility.PushMessage (user id, text message, AccessToken);

Parsing Receieved Message (Parsing received JSON):
var ReceivedMessage = isRock.LineBot.Utility.Parsing (postData);

Reply Message  
isRock.LineBot.Utility.ReplyMessage (ReplyToken, text message, AccessToken);

====================
History:
2018/5/7		0.7.1	support Get Content/User Info  in WebHook BaseController
2018/5/16	0.7.2	Add MS QnA Macker Helper
2018/5/27	0.7.3	update MS QnA Macker  Helper For GA
2018/8/24    0.7.6	Add Issue short-live Channel Access Token  API support
								Add Liff Server API Support
2018/9/13	0.7.8	Fix QnA Maker call for GA version
2018/9/15	0.8.0	QuickReply supported
2018/10/4	0.8.3	fix QnA Services bug

中文說明:
================================================
LineBot SDK for .NET (Line@ Messaging API supported)
這是用來開發LineBot的.net  SDK
最低.net版本支援為 .net 4.5.1
================================================

使用範例:
https://github.com/isdaviddong/LineBotSdkExample

如何使用請參考套件公開說明書:
http://studyhost.blogspot.tw/search/label/LineBot

簡易使用說明:
Push Message(主動發訊息給用戶):
isRock.LineBot.Utility.PushMessage(用戶id, 文字訊息, AccessToken);

Parsing Receieved Message(Parsing 收到的JSON): 
var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);

Reply Message(回覆用戶的訊息):
isRock.LineBot.Utility.ReplyMessage(ReplyToken, 文字訊息, AccessToken);

==================================================
C# Examples:

LineBotSdk範例，包含純文字訊息、貼圖、圖片發送
https://github.com/isdaviddong/LineBotSdkExample

Line_Notify_Example
https://github.com/isdaviddong/Line_Notify_Example

Line_Login_Example
https://github.com/isdaviddong/Line_Login_Example

展示如何建立一個可以接收檔案的Line WebHook 
https://github.com/isdaviddong/LineExample_WebHookGetPicture

Carousel Template Example
https://github.com/isdaviddong/LinePushCarouselTemplateExample

Line bot 連續對談機制:
https://github.com/isdaviddong/LinebotConversationExample

Line bot 群組對談範例程式碼:
https://github.com/isdaviddong/LinebotInTheGroup

======================================
使用套件有利有弊，使用前請詳閱套件公開說明書
======================================


