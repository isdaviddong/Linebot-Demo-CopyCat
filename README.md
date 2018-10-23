Linebot-Demo-CopyCat
===

此Line bot範例為使用 LineBotSDK 建立 <br>
仿造 卡米狗 的行為 <br>
當你跟 Line bot 說 <br>
看到 OO 回復 XX <br>
未來你對該Line bot說 OO 它就回復 XX <br>

如何使用
===
* 請 clone 之後，修改 web.config 中的 ChannelAccessToken
```xml
  <appSettings>
    <add key="ChannelAccessToken" value="請改成你自己的channel access token"/>
  </appSettings>
```
* 為了便於除錯，請修改 CopyCatController.cs 中的 Admin User Id
```csharp
   catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage("請改成你自己的Admin User Id", "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
```

畫面
===
![](https://i.imgur.com/DKvVs4A.png)
