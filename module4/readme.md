# 第四章 SharePoint 扩展

## 演示1 配置Office 365 环境

    - SharePoint 管理中心
        - 应用目录
        - 开发网站


## 演示2 创建Web 部件


    实验手册

    https://docs.microsoft.com/zh-cn/learn/modules/sharepoint-spfx-web-parts/3-exercise-create-web-part

    运行范例 `hello-world-sharepoint-webpart`

    ```
    npm i -g gulp yo
    yo @microsoft/sharepoint
    gulp trust-dev-cert

    gulp serve --nobrowser
    ```

    访问：https://code365xyz.sharepoint.com/sites/dev/_layouts/15/workbench.aspx



## 演示3 调用Microsoft Graph 资源

    实验手册

    https://docs.microsoft.com/zh-cn/learn/modules/sharepoint-spfx-graph-3rd-party-apis/7-exercise-graph-api

    SharePoint 管理中心

    https://code365xyz-admin.sharepoint.com/

    编译打包

    ```
    gulp build
    gulp bundle --ship
    gulp package-solution --ship

    ```


    应用目录网站

    https://code365xyz.sharepoint.com/sites/appcatalog

    上传，部署

    同意权限

    https://code365xyz-admin.sharepoint.com/_layouts/15/online/AdminHome.aspx#/webApiPermissionManagement

    在开发网站查看效果

    https://code365xyz.sharepoint.com/sites/dev


## 演示4 发布到Teams

    实验手册  https://docs.microsoft.com/zh-cn/learn/modules/sharepoint-spfx-teams-dev/3-exercise-deploy