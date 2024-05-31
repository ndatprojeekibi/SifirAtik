using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SifirAtik.Common;
using SifirAtik.Data.Contexts;
using SifirAtik.Data.Repositories;
using SifirAtik.Server.Middlewares;
using SifirAtik.Services.AutoMapper;
using SifirAtik.Services.Services;
using SifirAtik.Utils.AuthenticationKeys;

namespace SifirAtik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            #region App Settings

            AppSettings.SecretKey = builder.Configuration.GetSection("AppSettings:SecretKey").Value;
            AppSettings.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            #endregion

            #region Dependencies

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(AppSettings.ConnectionString));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<ItemRepository>();
            builder.Services.AddScoped<RequestRepository>();
            builder.Services.AddScoped<WarehouseRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();

            #endregion

            #region Authentication Details

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = KeyGenerator.GenerateSymmetricSecurityKey(AppSettings.SecretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseMiddleware<CustomMiddleware>();

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            #region Authentication Authorization

            app.UseAuthentication();
            app.UseAuthorization();

            #endregion


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run("https://0.0.0.0:7005");
        }
    }
}
