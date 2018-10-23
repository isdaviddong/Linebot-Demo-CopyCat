<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Linebot_Demo_CopyCat._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #0000FF;
            font-size: large;
        }
        .auto-style2 {
            color: #FF0066;
            font-size: large;
        }
        .auto-style3 {
            color: #CC0099;
            font-size: large;
        }
        .auto-style4 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>這是一個 LINE Bot 範例 - CopyCat</h1>
            ===<br />
        </div>
    </form>
    <p class="auto-style4">
        此範例仿 卡米狗 的作法，WebHook為 /api/CopyCat</p>
    <p class="auto-style4">
        當你跟chat bot說</p>
    <p class="auto-style1">
        <strong>看到 hi 回覆 你好</strong></p>
    <p>
        <span class="auto-style4">未來chat bot只要看到 </span><span class="auto-style2">hi</span><span class="auto-style4"> 就會回覆</span><span class="auto-style3"> 你好</span></p>
</body>
</html>
