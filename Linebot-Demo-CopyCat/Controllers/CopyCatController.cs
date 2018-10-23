using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Linebot_Demo_CopyCat.Controllers
{
    public class CopyCatController :  isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/CopyCat")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或不設定直接抓取Web.Config中key為ChannelAccessToken的AppSetting)
                //this.ChannelAccessToken = "!!!!! 改成自己的ChannelAccessToken !!!!!";
                //↑↑↑↑↑↑↑↑↑↑↑ 此範例採用 appsetting 設定 ChannelAccessToken

                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                var responseMsg = "";

                //判斷是否為文字訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    var UserSay = LineEvent.message.text.Trim();
                    //判斷是否為教學訊息
                    if (UserSay.Contains("看到") && (UserSay.Contains("回覆") || UserSay.Contains("回復")))
                    {
                        //處理教學動作
                        responseMsg = Learn(UserSay, LineEvent);
                    }
                    else
                    {
                        //如果沒有教學指令，則從資料庫中找回覆訊息
                        responseMsg = GetNormalResponse(UserSay, LineEvent);
                    }

                    //回覆訊息
                    this.ReplyMessage(LineEvent.replyToken, responseMsg);
                }
                else
                {
                    //如果是其他型態的訊息

                }
           
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage("請改成你自己的Admin User Id", "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }

        private string GetNormalResponse(string userSay, isRock.LineBot.Event LineEvent)
        {
            var respMsg = "";
            //db
            Models.MainDBDataContext db = new Models.MainDBDataContext();
            //尋找答案
            var ret = from c in db.blah
                      where c.UserSay.Contains(userSay)
                      select c;
            //如果有
            if (ret.Count() > 0)
            {
                //先找是自己教過的
                var MyAns = from c in ret
                            where c.LineUserId == LineEvent.source.userId
                            orderby c.Id descending
                            select c;
                if (MyAns.Count() > 0)
                {
                    //找自己教過的答案
                    respMsg = MyAns.FirstOrDefault().ResponseMsg;
                }
                else
                {
                    //如果沒有，就找最後一筆答案(可能是別人教的)
                    var Ans = from c in ret
                              orderby c.Id descending
                              select c;
                    //理論上應該會有符合的
                    if (Ans.Count() > 0)
                        respMsg = Ans.FirstOrDefault().ResponseMsg;
                }
            }

            //如果沒有答案
            if (string.IsNullOrEmpty(respMsg))
            {
                //沒有符合條件的答案
                respMsg = $"我不知道當我看到 '{userSay}' 的時候，該怎麼回答，\n你可以教我嗎? \n\n";
                respMsg += "若你跟我說:\n";
                respMsg += "看到 OO 回覆 XX \n\n";
                respMsg += "這樣以後當我看到  OO 就會回覆 XX 囉...\n";
                respMsg += "(別忘了OO和XX的前後要有空白唷!)";
            }
            return respMsg;
        }

        private string Learn(string userSay, isRock.LineBot.Event LineEvent)
        {
            //預設回覆文字
            var respMsg = "我沒法依照你的指令學習...\n";
            respMsg += "你必須跟我說:\n";
            respMsg += "看到 OO 回覆 XX \n";
            respMsg += "這樣以後當我看到  OO 就會回覆 XX 囉...";
            respMsg += "(別忘了OO和XX的前後要有空白唷!)";

            //拆解教學語句
            var words = userSay.Split(' ');
            //去除空元素(可能是兩個空白造成的)
            words = words.Where(c => !string.IsNullOrEmpty(c)).ToArray();
            //去除空白
            for (int i = 0; i < words.Length; i++)
            {
                //全形空白轉半形
                words[i].Replace("　", "");
                //去除空白
                words[i] = words[i].Trim();
            }
            //判斷指令是否正確
            if (words[0] != "看到") return respMsg;
            if (words[2] != "回覆" && words[2] != "回復") return respMsg;
            if (words.Length < 4)
            {
                respMsg += $"\n\n你的教學指令:\n{userSay}\n格式不正確喔~";
                return respMsg;
            }

            //新增教學到資料庫
            Models.blah rec = new Models.blah();
            rec.LineUserId = LineEvent.source.userId;
            rec.UserSay = words[1].Trim();
            rec.isValid = true;
            rec.ResponseMsg = words[3];

            //db
            Models.MainDBDataContext db = new Models.MainDBDataContext();
            db.blah.InsertOnSubmit(rec);
            db.SubmitChanges();

            respMsg = "懂了...\n";
            respMsg += $"以後當我看到包含 '{rec.UserSay}' 的句子，\n就會回覆 '{rec.ResponseMsg}' 囉...";
            return respMsg;
        }
    }
}
