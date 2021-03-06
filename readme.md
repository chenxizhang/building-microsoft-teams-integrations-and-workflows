# Microsoft Teams 集成和工作流开发
> 陈 希章 | 2022年2月

## 概述

这是微软虚拟培训日（Microsoft Virtual Training Day）的配套案例，课程名为 《Build Microsoft Teams Integrations and Workflows》，或《基于Microsoft Teams 构建应用集成和工作流》。

中文版讲师为 陈希章， 目前供职于微软（亚洲）互联网工程院。

## 准备

1. 申请 Microsoft 365 开发者账号 <https://developer.microsoft.com/zh-CN/office/dev-program>

1. 本地开发环境 

    ```powershell
    # 安装choco这个工具
    Set-ExecutionPolicy Bypass -Scope Process -Force; 
    [System.Net.ServicePointManager]::SecurityProtocol =[System.Net.ServicePointManager]::SecurityProtocol -bor 3072; 
    iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

    # 安装有关常用软件
    choco install dotnet vscode git -y
    choco install nodejs --version=14.18.3 -y  # SharePoint Framework相关工具依赖这个版本
    refreshenv
    npm install -g gulp gulp-cli yo generator-teams @microsoft/generator-sharepoint yarn ngrok

    ```
1. 下载范例
    ```
    git clone https://github.com/chenxizhang/building-microsoft-teams-integrations-and-workflows.git
    ```
1. 还原项目，避免出现错误

    ```powershell
    (".\module2\console\console.csproj",".\module2\ProductCatalog\ProductCatalog.csproj",".\module2\ProductCatalogWeb\ProductCatalogWeb.csproj",".\module3\graph-request-thottling\graphconsoleapp.csproj",".\module3\graph-user-data-console\graph-user-data-console.csproj") | ForEach-Object {dotnet restore $_}
    ```

## 注意

1. 所有范例代码中涉及到的应用程序信息（例如 `clientId`, `tenantId`等）都只是我这边的测试环境配置好的，如果需要正常运行，你需要自己按照实验手册注册对应的应用程序，并且替换掉代码中对应的信息。