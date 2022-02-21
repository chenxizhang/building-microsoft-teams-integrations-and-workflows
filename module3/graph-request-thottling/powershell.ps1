$token= Get-MsalToken -ClientId a6bd527e-f5e5-440c-8973-3bb5ce4f9215 -TenantId 3a6831ab-6304-4c72-8d08-3afe544555dd -Scopes "Mail.Read"

 Start-Job -ScriptBlock {1..100 | %{ curl -Uri "https://graph.microsoft.com/v1.0/me/messages" -Headers @{"Authorization"="Bearer $($using:token.AccessToken)"} }}

 Receive-Job -Id 3