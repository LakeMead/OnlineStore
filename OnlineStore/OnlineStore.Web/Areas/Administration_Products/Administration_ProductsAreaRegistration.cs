namespace OnlineStore.Web.Areas.Administration_Products
{
    using System.Web.Mvc;

    public class AdministrationProductsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration_Products";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_Products_default",
                "Administration_Products/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}