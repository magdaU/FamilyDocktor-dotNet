using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FamilyDoctor;
using System.Data.Entity;
using FamilyDoctor.DAL;
using System.Configuration;


namespace WebApplication1_Logowanie
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object FluentValidationModelValidatorProvider { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //FluentValidationModelValidatorProvider.Configuration();

            Database.SetInitializer<FamilyDoctorContext>(new DropCreateDatabaseIfModelChanges<FamilyDoctorContext>()); 
        }
        
    }
}
