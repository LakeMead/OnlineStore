namespace OnlineStore.Web.Areas.Administration_Orders
{
    using System.Web.Mvc;

    public class Administration_OrdersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration_Orders";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_Orders_default",
                "Administration_Orders/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}