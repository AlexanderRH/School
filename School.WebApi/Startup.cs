using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.UnitOfWork;
using School.Repositories.Dapper.School;
using School.WebApi.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace School.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork>
                (
                    options => new SchoolUnitOfWork
                        (
                            Configuration.GetConnectionString("Northwind")
                        )
                );

            services.AddMvc();

            var tokenProvider = new RsaJwtTokenProvider("issuer", "audience", "token_school_2017");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                    options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = tokenProvider.GetValidatorParameters();
                    }
                );


            services.AddAuthorization(
                    auth =>
                    {
                        auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                    }
                );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
