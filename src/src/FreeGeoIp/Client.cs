using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
 
namespace FreeGeoIp
{
    public class Client
    {
        private readonly string _apiUrl;
        public IErrorLog ErrorLog { get; set; }

        public Client(string apiUrl = "https://freegeoip.net")
        {
            _apiUrl = apiUrl;
        }

        public GeoIpResponse Get(string ipAddress)
        {
            var url = ConstructUrl(ipAddress);
            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    return JsonConvert.DeserializeObject<GeoIpResponse>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                if (ErrorLog != null)
                {
                    using (var responseStream = ex.Response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        ErrorLog.Log(reader.ReadToEnd());
                    }
                }
                return null;
            }
        }

        private string ConstructUrl(string ipAddress) => _apiUrl + "/json/" + ipAddress;
    }
}