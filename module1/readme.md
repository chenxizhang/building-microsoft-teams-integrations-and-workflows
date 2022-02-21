# 第一章 实施Microsoft 标识（一）


## 注册应用程序

    https://aad.portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/Overview/appId/0e010870-42d4-4bfe-867b-01e49ca83f2b/isMSAApp/

## 演示

1. 直接通过 `msal-browser` 在客户端网页中进行登录以及注销

    ```
        cd module1
        serve
    ```
1. 在 React 项目中实现同样的效果

    演示：https://codesandbox.io/s/msal-spa-o0cm4s

1. 查看不同的权限，理解同意的框架

    在 https://codesandbox.io/s/msal-spa-o0cm4s 这个例子中，`loginPopup` 这个方法中尝试传入不同的参数，使用管理员或普通用户账号(`demo@code365.xyz`)去登录，看看效果

    ```
        Mail.Read  # 普通用户就可以同意的权限
        Directory.Read.All  # 需要管理员同意的权限
    ```

## 其他资源

我有一个专门的课程，请参考 《解密和实战Microsoft Identity Platform》<https://identityplatform.xizhang.com>