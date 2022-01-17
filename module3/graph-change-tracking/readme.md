
# 将本地3000这个地址发不出去

> ngrok http 3000

# 启动服务器
> node .\server.js

# 配置订阅，请注意下面的 `notificationUrl` 设置为 ngrok 的地址
POST https://graph.microsoft.com/v1.0/subscriptions

```json
{
    "changeType": "updated",
    "notificationUrl": "https://828b-2404-f801-9000-18-6fec-00-505.ngrok.io",
    "resource": "/users",
    "expirationDateTime": "2022-01-17T20:00:00.0000000Z",
    "clientState": "SecretClientState"
}
```