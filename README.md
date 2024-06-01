# my-web-api-plus-mssql-plus-dapper-template

The following example uses PowerShell.

Navigate to sample:

```CMD
cd my-web-api-plus-mssql-plus-dapper-template\Sample.QuestionnaireAPI
```

Generate cert and configure local machine:

```CMD
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Sample.Questionnaire.API.pfx -p <CREDENTIAL_PLACEHOLDER>
dotnet dev-certs https --trust
```

> Note: The certificate name, in this case Sample.Questionnaire.API.pfx must match the project assembly name.

> Note: If console returns "A valid HTTPS certificate is already present.", a trusted certificate already exists in your store. It can be exported using MMC Console.
> - How to export .pfx certificate using Microsoft Management Console (MMC) (c-sharpcorner.com) - https://www.c-sharpcorner.com/article/how-to-export-pfx-certificate-using-microsoft-management-console-mmc/
> - How to generate .pfx certificate using Microsoft Management Console (MMC) (c-sharpcorner.com) - https://www.c-sharpcorner.com/article/how-to-generate-pfx-certificate-using-microsoft-management-console-mmc/

Configure application secrets, for the certificate:

```CMD
dotnet user-secrets init -p Sample.Questionnaire.API\Sample.Questionnaire.API.csproj
dotnet user-secrets -p Sample.Questionnaire.API\Sample.Questionnaire.API.csproj set "Kestrel:Certificates:Development:Password" "<CREDENTIAL_PLACEHOLDER>"
```

> Note: The password must match the password used for the certificate.
