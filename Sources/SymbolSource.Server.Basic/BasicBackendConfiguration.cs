using System;
using System.Configuration;
using System.Web;
using System.Web.Hosting;

namespace SymbolSource.Server.Basic
{
    public class BasicBackendConfiguration : IBasicBackendConfiguration
    {
        public string DataPath
        {
            get
            {
                var path = ConfigurationManager.AppSettings["DataPath"];

                if (String.IsNullOrEmpty(path))
                {
                    // Default path
                    return HostingEnvironment.MapPath("~/Data");
                }

                return path.StartsWith("~/") ? HostingEnvironment.MapPath(path) : path;
            }
        }

        public string IndexPath
        {
            get
            {
                var path = ConfigurationManager.AppSettings["indexPath"];

                if (String.IsNullOrEmpty(path))
                {
                    // Default path
                    return HostingEnvironment.MapPath("~/Index");
                }

                return path.StartsWith("~/") ? HostingEnvironment.MapPath(path) : path;
            }
        }

        public string ApiKey
        {
            get
            {
                var key = ConfigurationManager.AppSettings["ApiKey"];

                if (String.IsNullOrEmpty(key))
                {
                    // Default key
                    return "123";
                }

                return key;
            }
        }

        public string RemotePath
        {
            get
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HostingEnvironment.ApplicationVirtualPath.TrimEnd('/') + "/Data";
            }
        }
    }
}