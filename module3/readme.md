# 第三章 Microsoft Graph

## 演示1 Microsoft Graph 查询和参数

```
实验手册：https://docs.microsoft.com/zh-cn/learn/modules/optimize-data-usage/5-exercise-expand-related-entities-search-content-microsoft-graph

https://developer.microsoft.com/zh-cn/graph/graph-explorer

https://graph.microsoft.com/v1.0/
https://graph.microsoft.com/v1.0/me/photo/$value 
https://graph.microsoft.com/v1.0/me/manager
https://graph.microsoft.com/v1.0/me/messages
https://graph.microsoft.com/v1.0/me/messages?$count=true
https://graph.microsoft.com/v1.0/me/messages?$top=50
https://graph.microsoft.com/v1.0/me/messages?$top=50&$skip=20
https://graph.microsoft.com/v1.0/me/messages?$top=50&$orderby=subject
https://graph.microsoft.com/v1.0/me/messages?$top=50&$orderby=subject&$select=id,subject,sentDateTime
https://graph.microsoft.com/v1.0/me/messages?$select=id,subject,sentDateTime&$search="monthly"
https://graph.microsoft.com/v1.0/me/messages?$filter=hasAttachments eq false
https://graph.microsoft.com/v1.0/education/me/classes?$expand=members
https://graph.microsoft.com/v1.0/me/drive/root?$expand=children

```


## 演示2 批量查询

实验手册：https://docs.microsoft.com/zh-cn/learn/modules/optimize-data-usage/7-exercise-reduce-traffic-with-batched-requests

```
POST https://graph.microsoft.com/v1.0/$batch

{
    "requests": [
        {
            "url": "/me?$select=displayName,jobTitle,userPrincipalName",
            "method": "GET",
            "id": "1"
        },
        {
            "url": "/me/messages?$filter=importance eq 'high'&$select=from,subject,receivedDateTime,bodyPreview",
            "method": "GET",
            "id": "2"
        },
        {
            "url": "/me/events",
            "method": "GET",
            "id": "3"
        }
    ]
}


{
  "requests":
  [
    {
      "url": "/me/drive/root/children",
      "method": "POST",
      "id": "1",
      "body": {
        "name": "TestBatchingFolder",
        "folder": {}
      },
      "headers": {
        "Content-Type": "application/json"
      }
    },
    {
      "url": "/me/drive/root/children/TestBatchingFolder",
      "method": "GET",
      "id": "2",
      "DependsOn": [
        "1"
      ]
    }
  ]
}
```


## 演示3 流量控制

实验手册：https://docs.microsoft.com/zh-cn/learn/modules/optimize-network-traffic/3-exercise-understand-throttling-microsoft-graph

打开 [范例代码](./graph-request-thottling/), 运行 `dotnet run`

## 演示4 访问用户数据

实验手册：https://docs.microsoft.com/zh-cn/learn/modules/msgraph-access-user-data/3-exercise-reading-users?ns-enrollment-type=LearningPath&ns-enrollment-id=learn-m365.msgraph-associate

打开 [范例代码](./graph-user-data-console/)， 运行 `dotnet run`

## 演示5 订阅变更

实验手册：https://docs.microsoft.com/zh-cn/learn/modules/msgraph-changenotifications-trackchanges/3-exercise-create-app

```
POST https://graph.microsoft.com/v1.0/subscriptions

需要有User.Read.All权限


https://pipedream.com/@chenxizhang

{
    "changeType": "updated",
    "notificationUrl": "https://enfrrle0t9q41ua.m.pipedream.net",
    "resource": "/users",
    "expirationDateTime": "2022-01-17T20:00:00.0000000Z",
    "clientState": "SecretClientState"
}

```
