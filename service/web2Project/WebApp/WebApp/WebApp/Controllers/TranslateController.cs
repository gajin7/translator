using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class TranslateController : ApiController
    {
        
        public TranslateController()
        {
            
        }


        [System.Web.Http.Route("api/save")]
        public string GetProduct()
        {
            var req = HttpContext.Current.Request;
            var value = req.Url.ToString().Split('=')[1];
           

            if (value != null)
            {
                var translatedValue = Translator.Translate(value);
                XmlHelper.WriteTranslatedPairInXML(value, translatedValue);

                var content = new Content(translatedValue);

                return translatedValue;
            }

            return null;
            
        }
    }
}