﻿using System.Linq;
using System.Web.Mvc;
using CmsData;
using UtilityExtensions;

namespace CmsWeb.Areas.Setup.Controllers
{
    [Authorize(Roles = "ManageResources")]
    [RouteArea("Setup", AreaPrefix = "ResourceType"), Route("{action}/{id?}")]
    public class ResourceTypeController : CmsStaffController
    {
        [Route("~/ResourceTypes")]
        public ActionResult Index()
        {
            var m = from rt in DbUtil.Db.ResourceTypes
                    orderby rt.DisplayOrder
                    select rt;
            return View(m);
        }

        public JsonResult ResourceTypes()
        {
            var q = from c in DbUtil.Db.ResourceTypes
                    select new
                    {
                        value = c.ResourceTypeId.ToString(),
                        text = c.Name
                    };

            return Json(q.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var resourceType = new ResourceType { Name = "new resource type" };
            DbUtil.Db.ResourceTypes.InsertOnSubmit(resourceType);
            DbUtil.Db.SubmitChanges();
            return Redirect($"/ResourceTypes/#{resourceType.ResourceTypeId}");
        }

        [HttpPost]
        public ContentResult Edit(string id, string value)
        {
            var a = id.Split('.');
            var c = new ContentResult();
            c.Content = value;
            var resourceType = DbUtil.Db.ResourceTypes.SingleOrDefault(m => m.ResourceTypeId == a[1].ToInt());
            if (resourceType == null)
                return c;
            switch (a[0])
            {
                case "Name":
                    resourceType.Name = value;
                    break;
                case "DisplayOrder":
                    int displayOrder = resourceType.DisplayOrder;
                    int.TryParse(value, out displayOrder);
                    resourceType.DisplayOrder = displayOrder;
                    break;
            }
            DbUtil.Db.SubmitChanges();
            return c;
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            id = id.Substring(1);
            var catType = DbUtil.Db.ResourceTypes.SingleOrDefault(m => m.ResourceTypeId == id.ToInt());
            if (catType == null)
                return new EmptyResult();

            if (catType.Resources.Any())
                return Json(new { error = "Resources have that type, not deleted" });            

            DbUtil.Db.ResourceTypes.DeleteOnSubmit(catType);
            DbUtil.Db.SubmitChanges();
            return new EmptyResult();
        }
    }
}