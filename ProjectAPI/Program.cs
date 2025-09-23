using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.Interfaces;
using ProjectAPI.Repository;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
 
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IUserService, UserRepo>();

builder.Services.AddScoped<IUserReg, UserRegService>();
builder.Services.AddScoped<IUserRegService, UserRegRepo>();

builder.Services.AddScoped<IAuth, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ITask, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

// ✅ 1. Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", // VS Code Live Server
                               "http://localhost:7228",  // Another local origin
                               "http://localhost")       // General localhost
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

// 1. Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],    // from appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"],// from appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    // ✅ This allows reading token from cookie instead of header
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("jwt"))
            {
                context.Token = context.Request.Cookies["jwt"];
            }
            return Task.CompletedTask;
        }
    };
});

// 2. Add Authorization
builder.Services.AddAuthorization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ 4. Enable CORS before Auth
app.UseCors("AllowFrontend");

app.UseAuthentication(); // 3. Use Authentication Middleware
app.UseAuthorization();

app.MapControllers();

app.Run();
