# 第二章 实施Microsoft 标识（二）

## 演示1

实验手册：https://docs.microsoft.com/zh-cn/learn/modules/identity-secure-custom-api/3-exercise-secure-api-microsoft-identity

### Web API项目

```powershell
$env:DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER =1;dotnet watch run --urls https://localhost:5050
```

### Web项目
```
dotnet watch run --urls https://localhost:5001
```

### 服务程序 (console)
```
dotnet run
```

## 演示2

在门户中演示如何在token中包含组的信息，在Web API项目中，设置按角色授权，然后在Web项目和Console项目中测试调用。

实验手册 https://docs.microsoft.com/zh-cn/learn/modules/identity-users-groups-approles/5-exercise-authorize-security-groups
