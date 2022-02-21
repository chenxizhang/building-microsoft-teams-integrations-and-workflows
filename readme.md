# 授课说明


## 还原项目，避免出现错误

```powershell
(".\module2\console\console.csproj",".\module2\ProductCatalog\ProductCatalog.csproj",".\module2\ProductCatalogWeb\ProductCatalogWeb.csproj",".\module3\graph-request-thottling\graphconsoleapp.csproj",".\module3\graph-user-data-console\graph-user-data-console.csproj") | ForEach-Object {dotnet restore $_}

```

## 清理所有授权权限

```powershell
Install-Module AzureAD -Scope CurrentUser
Connect-AzureAD # 用管理员身份
Get-AzureADOAuth2PermissionGrant | Remove-AzureADOAuth2PermissionGrant
```