using KeyRotation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.MapGet("/sample", () => Results.Ok("Success Response."));

app.Run();

internal record KeyRotationRequest(string KeyVaultName, string SecretName, string SecretVersion);