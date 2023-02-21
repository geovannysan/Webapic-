
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoftde.Datas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//jswtoken
builder.Configuration.AddJsonFile("appsettings.json");
var secret = builder.Configuration.GetSection("settings").GetSection("secrekey").ToString();
var keybayts = Encoding.UTF8.GetBytes(secret);
builder.Services.AddAuthentication(conf =>
{
    conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keybayts),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

}

app.UseHttpsRedirection();
//jswtoken
app.UseAuthentication();
//
app.UseAuthorization();

app.MapControllers();

app.Run();