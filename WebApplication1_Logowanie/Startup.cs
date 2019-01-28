using FluentValidation;
using Microsoft.Owin;
using Owin;
using System;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(WebApplication1_Logowanie.Startup))]
namespace WebApplication1_Logowanie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    //ADD

    //public void ConfigureServices(ServiceCollection services)
    //{
    //    services.Addmvc(setup =>
    //    {
    //        // ..mvc setup ...
    //    }).AddFluentValidation();
    //    CreatePatientValidator(services);
    //}

    //private static void CreatePatientValidator(ServiceCollection services)
    //{
    //    services.AddTransient<IEmailSender, AuthMessageSender>();
    //    //zarejestrowanie w kolekcji usług
    //    services.AddTransient<IValidator<Patient>, CreateValidator>();
    //}

    //public interface iservicecollection
    //{
    //    object addmvc(Func<object, object> p);
    //    void addtransient<t1, t2>();
    //}

    //END
}
