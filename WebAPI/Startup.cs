using Application.Bootstrap;
using Application.Interfaces;
using Application.Interfaces.Authentication;
using Domain.Entities.Authentication;
using Domain.Infrastructure;
using FluentValidation;
using Infrastructure.Bootstrap;
using Infrastructure.Services;
using Joonasw.AspNetCore.SecurityHeaders;
using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance;
using Persistance.Bootstrap;
using Quotation.Domain.Entities.Authentication;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Application.Commands.UserCommands;
using Application.Commands.WorkoutRecordCommands;
using Application.Interfaces.WorkoutRecord;
using Application.Queries.UserQueries;

namespace WebAPI
{
    public class Startup
    {
        private const string ReportViolationsTo = "/csp-report";
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddDistributedMemoryCache();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.Headers["Location"] = context.RedirectUri;
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return Task.CompletedTask;
                    };
                    options.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.Headers["Location"] = context.RedirectUri;
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        return Task.CompletedTask;
                    };
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.ConsentCookie.MaxAge = TimeSpan.FromDays(365);
            });

            var connectionString = Configuration.GetConnectionString("FitnessDatabase");
            services.AddDbContext<FitnessDbContext>(options => options.UseSqlServer(connectionString));

            
            services.Configure<Logging>(Configuration.GetSection("Logging"));

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(RegisterUserCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(LoginCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(AddWorkoutRecordCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(UsersQueryHandler).GetTypeInfo().Assembly);
            services.RegisterInfrastructureComponents();
            services.RegisterApplicationServices();
            services.RegisterRepositories();
            services.RegisterWebAPIServices();
            services.AddCsp(nonceByteAmount: 32);

            services.AddTransient<IWorkoutRecordService, WorkoutRecordService>();

            
            services.AddTransient<IFitnessDbContextInitializer, FitnessDbContextInitializer>();

            services.AddIdentity<User, ApplicationRole>()
                  .AddEntityFrameworkStores<FitnessDbContext>()
                  .AddDefaultTokenProviders();

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

            //services.AddOpenApiDocument();
            services.AddApplicationInsightsTelemetry();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});

            //services.AddAppEvents(opt =>
            //{
            //    opt.Handlers = new List<AppEventHandlerDescriptor>
            //    {
            //        new AppEventHandlerDescriptor(typeof(UserActionLogEventHandler))
            //    };
            //});

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IAntiforgery antiforgery)//, IAsyncQueryService asyncQueryService, IQueryHelperService queryHelperService, AppConfigurations appConfigurations)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            var supportedCultures = new[] { "en-GB" };
            app.Use(next => context =>
            {
                var tokens = antiforgery.GetAndStoreTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = true, Path = "/" });
                //setting HttpOnly=true,Secure=true will make browser cookie secure
                return next(context);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            ////TODO: See if this really needs to be removed
            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Xss-Protection", "1;mode=block");
                context.Response.Headers["Cache-control"] = "private,no-cache,no-store, must-revalidate ,max-age=0";
                await next();
            });

            // Content Security Policy
            app.UseCsp(csp =>
            {
                csp.ByDefaultAllow
                    .FromSelf();

                csp.AllowFormActions
                .ToSelf();

                // Allow JavaScript from:
                csp.AllowScripts
                    .FromSelf() //This domain
                    .AddNonce()
                    .AllowUnsafeInline();

                // CSS allowed from:
                csp.AllowStyles
                    .FromSelf()
                  .AllowUnsafeInline();

                csp.AllowImages
                    .FromSelf();

                // HTML5 audio and video elemented sources can be from:
                csp.AllowAudioAndVideo
                    .FromNowhere();

                // Contained iframes can be sourced from:
                csp.AllowFrames
                    .FromNowhere(); //Nowhere, no iframes allowed

                // Allow AJAX, WebSocket and EventSource connections to:
                csp.AllowConnections
                    .ToSelf();

                // Allow fonts to be downloaded from:
                csp.AllowFonts
                   .FromSelf();

                // Allow object, embed, and applet sources from:
                csp.AllowPlugins
                    .FromNowhere();

                // Allow other sites to put this in an iframe?
                csp.AllowFraming
                    .FromNowhere(); // Block framing on other sites, equivalent to X-Frame-Options: DENY

                // Do not block violations, only report
                // This is a good idea while testing your CSP
                // Remove it when you know everything will work
                csp.SetReportOnly();
                // Where should the violation reports be sent to?
                csp.ReportViolationsTo(ReportViolationsTo);

                // Do not include the CSP header for requests to the /api endpoints
                csp.OnSendingHeader = context =>
                {
                    context.ShouldNotSend = context.HttpContext.Request.Path.StartsWithSegments("/api");
                    return Task.CompletedTask;
                };
            });
        }
    }
}