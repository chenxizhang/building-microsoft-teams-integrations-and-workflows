# 授课说明



## 清理所有授权权限

```powershell
Install-Module AzureAD -Scope CurrentUser
Connect-AzureAD # 用管理员身份
Get-AzureADOAuth2PermissionGrant | Remove-AzureADOAuth2PermissionGrant
```