## 环境准备

1. 申请 Microsoft 365 开发者账号 <https://developer.microsoft.com/zh-CN/office/dev-program>
1. 本地开发环境 

    ```
    # 安装choco这个工具
    Set-ExecutionPolicy Bypass -Scope Process -Force; 
    [System.Net.ServicePointManager]::SecurityProtocol =[System.Net.ServicePointManager]::SecurityProtocol -bor 3072; 
    iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

    # 安装有关常用软件
    choco install dotnet vscode nodejs-lts postman git python -y
    ```
1. 下载范例
    ```
    git clone https://github.com/chenxizhang/building-microsoft-teams-integrations-and-workflows.git
    ```
1. 还原项目，避免出现错误

    ```powershell
    (".\module2\console\console.csproj",".\module2\ProductCatalog\ProductCatalog.csproj",".\module2\ProductCatalogWeb\ProductCatalogWeb.csproj",".\module3\graph-request-thottling\graphconsoleapp.csproj",".\module3\graph-user-data-console\graph-user-data-console.csproj") | ForEach-Object {dotnet restore $_}
    ```


```

## 清理所有授权权限

```powershell
Install-Module AzureAD -Scope CurrentUser
Connect-AzureAD # 用管理员身份
Get-AzureADOAuth2PermissionGrant | Remove-AzureADOAuth2PermissionGrant
```