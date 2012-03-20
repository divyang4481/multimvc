using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;
using BackToOwner.Web.Helpers;


namespace BackToOwner.Golf.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly XmlSerializer _serializer;
        private IServiceHelper _serviceHelper;

        public ServicesController(IServiceHelper serviceHelper)
        {
            this._serviceHelper = serviceHelper;
            this._serializer = new XmlSerializer(typeof(ServiceInit));
        }

        [HttpGet]
        [ActionName("Init")]
        public ContentResult InitGet()
        {
            ServiceInit data = new ServiceInit();
            data.BadgeNbr = String.Empty;
            data.Status = "use POST to use the service";
            data.Links = new[]{new Link {Href= _serviceHelper.Root + "Init"}};


            string result = Serialize(data);
            return Content(result,"text/xml");

        }

       

        [HttpPost]
        [ActionName("Init")]
        public ActionResult InitPost(ServiceInit payload)
        {
            
          
            if(String.IsNullOrEmpty(payload.BadgeNbr))
            {
                payload.Status = "Error - Badge nbr can't be empty!";
                payload.Links = null;
                return new HttpStatusCodeResult(400,payload.Status);
            }

            var badgeService = TenantFactory.Create<IRepository<Badge,string>>();
            var badge = badgeService.GetBy(n=>n.Nbr == payload.BadgeNbr);

            if (badge==null)
            {
                payload.Status = String.Format("Badge with number {0} not found!",payload.BadgeNbr);
                payload.Links = null;
                return new HttpStatusCodeResult(404, payload.Status);
            }

            payload.Status = badge.IsActive ? "Activate" : "Declare";
            payload.Links = new[] { new Link
                                        {
                                             Href = _serviceHelper.Root
                                             + payload.Status + "/" 
                                             + payload.BadgeNbr
                                         } };
            
            string result = Serialize(payload);
            return Content(result,"text/xml",Encoding.UTF8);
        }

        private string Serialize(ServiceInit request)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _serializer.Serialize(stream, request);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
