using IAuthorizationPolicyRecipe.Web.Security;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;

// You can remove the reference to WebActivator by calling the Start() method from your Global.asax Application_Start
[assembly: WebActivator.PreApplicationStartMethod(typeof(IAuthorizationPolicyRecipe.Web.App_Start.AppStartFubuMVC), "Start", callAfterGlobalAppStart: true)]

namespace IAuthorizationPolicyRecipe.Web.App_Start
{
    public static class AppStartFubuMVC
    {
        public static void Start()
        {
            // FubuApplication "guides" the bootstrapping of the FubuMVC
            // application
            FubuApplication.For<ConfigureFubuMVC>() // ConfigureFubuMVC is the main FubuRegistry
                                                    // for this application.  FubuRegistry classes 
                                                    // are used to register conventions, policies,
                                                    // and various other parts of a FubuMVC application


                // FubuMVC requires an IoC container for its own internals.
                // In this case, we're using a brand new StructureMap container,
                // but FubuMVC just adds configuration to an IoC container so
                // that you can use the native registration API's for your
                // IoC container for the rest of your application
                .StructureMapObjectFactory(sof =>
                    {
                        sof.AddRegistry<SecurityRegistry>();
                    })
                .Bootstrap();

			// Ensure that no errors occurred during bootstrapping
			PackageRegistry.AssertNoFailures();
        }
    }
}