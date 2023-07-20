using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using nc2.Context;
using nc2.Interfaces;
using nc2.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var secretKey = "gizli key cümlem bu";
var key = new SymmetricSecurityKey(Encoding.UTF8
    .GetBytes(secretKey));
builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddScoped<IMediaUpload, MediaService>();

//builder.Services.AddDbContext<NcDbContext>(options => options.UseSqlServer("Server=.;Database=nc;uid=sa;pwd=123;TrustServerCertificate=True"));
//builder.Services.AddDbContext<NcDbContext>(options => options.UseSqlServer("Server=.;Database=nc;uid=sa;pwd=123;TrustServerCertificate=True"));
builder.Services.AddDbContext<NcDbContext>(options => options.UseSqlServer("Server=104.247.162.242\\MSSQLSERVER2019;Database=marsevor_nc;uid=marsevor_nc;pwd=~76j04ndI;TrustServerCertificate=True"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // services.AddAuthentication("Bearer")
                .AddJwtBearer(opt => {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = key
                    };
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
