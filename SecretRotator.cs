using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace KeyRotation;

internal static class SecretRotator
{
    private const string CredentialIdTag = "CredentialId";
    private const string ProviderAddressTag = "ProviderAddress";
    private const string ValidityPeriodDaysTag = "ValidityPeriodDays";

    public static void RotateSecret(string secretName, string keyVaultName)
    {
        //Retrieve Current Secret
        var kvUri = $"https://{keyVaultName}.vault.azure.net";
        var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        KeyVaultSecret secret = client.GetSecret(secretName);

        //Check Service Provider connection
        CheckServiceConnection(secret);

        //Create new password
        var randomPassword = CreateRandomPassword();

        //Add secret version with new password to Key Vault
        CreateNewSecretVersion(client, secret, randomPassword);

        //Update Service Provider with new password
        UpdateServicePassword(secret, randomPassword);
    }

    private static void CheckServiceConnection(KeyVaultSecret secret)
    {
        var userId = "admin.lowcode";//secret.Properties.Tags.ContainsKey(CredentialIdTag) ? secret.Properties.Tags[CredentialIdTag] : string.Empty;
        var dbResourceId = secret.Properties.Tags.ContainsKey(ProviderAddressTag) ? secret.Properties.Tags[ProviderAddressTag] : string.Empty;

        var dbName = "eussqllowcoden01";//dbResourceId.Split('/')[8];

        SqlConnectionStringBuilder builder = new()
        {
            DataSource = $"{dbName}.database.windows.net",
            UserID = userId,
            Password = "1q2w3e4r%"//secret.Value
        };

        using SqlConnection connection = new(builder.ConnectionString);
        connection.Open();
    }

    private static void CreateNewSecretVersion(SecretClient client, KeyVaultSecret secret, string newSecretValue)
    {
        var newSecret = new KeyVaultSecret(secret.Name, newSecretValue);
        newSecret.Properties.ExpiresOn = DateTime.UtcNow.AddDays(60);

        client.SetSecret(newSecret);
    }

    private static void UpdateServicePassword(KeyVaultSecret secret, string newpassword)
    {
        var userId = secret.Properties.Tags.ContainsKey(CredentialIdTag) ? secret.Properties.Tags[CredentialIdTag] : string.Empty;
        var dbResourceId = secret.Properties.Tags.ContainsKey(ProviderAddressTag) ? secret.Properties.Tags[ProviderAddressTag] : string.Empty;

        var dbName = dbResourceId.Split('/')[8];
        var password = secret.Value;

        SqlConnectionStringBuilder builder = new()
        {
            DataSource = $"{dbName}.database.windows.net",
            UserID = userId,
            Password = password
        };

        //Update password
        using SqlConnection connection = new(builder.ConnectionString);
        connection.Open();

        using SqlCommand command = new($"ALTER LOGIN {userId} WITH Password='{newpassword}';", connection);
        command.ExecuteNonQuery();
    }

    private static string CreateRandomPassword()
    {
        const int length = 60;

        byte[] randomBytes = new byte[length];
        RandomNumberGenerator.Create("random")?.GetBytes(randomBytes);
        
        return Convert.ToBase64String(randomBytes);
    }
}
