using KeyRotation;
using KeyRotation.Database;
using Microsoft.EntityFrameworkCore;
//using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddAzureKeyVault(
//    new Uri("https://euskvlowcoden01.vault.azure.net/"),
//    new DefaultAzureCredential()
//);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(
//        //"Server=tcp:eussqllowcoden01.database.windows.net,1433;Initial Catalog=eusdblowcoden01;Persist Security Info=False;User ID=admin.lowcode;Password=1q2w3e4r%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
//        builder.Configuration.GetConnectionString("Default"),
//        optionsBuilder => optionsBuilder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(2), null)
//    )
//);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/key/rotation", (KeyRotationRequest request) =>
{
    SecretRotator.RotateSecret(request.SecretName, request.KeyVaultName);

    return Results.Ok("Secret Rootated Successfully");
});

app.MapGet("/sample", () => Results.Ok("Sample Result"));

//using var scope = app.Services.CreateScope();
//await scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.MigrateAsync();

app.Run();

internal record KeyRotationRequest(string KeyVaultName, string SecretName, string SecretVersion);