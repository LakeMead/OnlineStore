namespace OnlineStore.Web.Infrastructure.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PopulateFromCacheAttribute : Attribute
    {
        public PopulateFromCacheAttribute(params string[] viewBagPropIds)
        {
            this.ViewBagPropIds = viewBagPropIds;
        }

        public string[] ViewBagPropIds { get; set; }
    }
}