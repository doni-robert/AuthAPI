using ATSBackend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer; // For JWT Bearer Authentication
using Microsoft.IdentityModel.Tokens; // For Token Validation
using System.Text;
using ATSBackend.Services; // For Encoding.UTF8

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration["Jwt:Key"] 
             ?? throw new ArgumentNullException("Jwt:Key", "JWT Key is not configured in appsettings.json.");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] 
                ?? throw new ArgumentNullException("Jwt:Issuer", "JWT Issuer is not configured in appsettings.json.");
var jwtAudience = builder.Configuration["Jwt:Audience"] 
                  ?? throw new ArgumentNullException("Jwt:Audience", "JWT Audience is not configured in appsettings.json.");


// Add services to the container.

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container for controllers
builder.Services.AddControllers();

// Register TokenService with the Jwt configuration
builder.Services.AddSingleton<TokenService>(new TokenService(jwtKey, jwtIssuer, jwtAudience));


// Register Swagger for API documentation (optional)
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
