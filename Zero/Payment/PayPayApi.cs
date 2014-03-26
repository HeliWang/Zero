using System.Web;
using System.Text;
using Zero.Core.Web;

namespace Zero.Payment
{
    public class Constants
    {
        public const string API_USERNAME = "307399609_api1.qq.com";
        public const string API_PASSWORD = "1371720221";
        public const string API_SIGNATURE = "AHzv8Q3aqsIV48g4wRfSoFM34P4OAaoawuOHnUn.WsuqhOeDKZq1dhEE";
        public const string ENVIRONMENT = "sandbox";
        public const string API_URL = "https://api-3t.sandbox.paypal.com/nvp";
    }

    public class Profile
    {
        /// <summary>
        /// The username this profile uses to access the PayPal API
        /// </summary>
        public string APIUsername { get; set; }

        /// <summary>
        /// The password this profile uses to access the PayPal API
        /// </summary>
        public string APIPassword { get; set; }

        /// <summary>
        /// The signature hash used for three-token authentication
        /// </summary>
        public string APISignature { get; set; }

        /// <summary>
        ///  The PayPal environment (Live, Sadnbox)
        /// </summary>
        public string Environment { get; set; }

        public string API_URL{get;set;}
    }

    /// <summary>
    /// 贝宝支付接口（认证模式：签名认证）
    /// </summary>
    public class PayPayApi
    {
        public Profile Profile { get; set; }

        public PayPayApi(string model)
        {
            Profile profile = new Profile();

            switch (model)
            {
                case "live":
                    profile.APIUsername = "307399609_api1.qq.com";
                    profile.APIPassword = "1371720221";
                    profile.APISignature = "AHzv8Q3aqsIV48g4wRfSoFM34P4OAaoawuOHnUn.WsuqhOeDKZq1dhEE";
                    profile.Environment = "sandbox";
                    profile.API_URL = "https://api-3t.sandbox.paypal.com/nvp";
                    break;

                default:
                    profile.APIUsername = "307399609_api1.qq.com";
                    profile.APIPassword = "1371720221";
                    profile.APISignature = "AHzv8Q3aqsIV48g4wRfSoFM34P4OAaoawuOHnUn.WsuqhOeDKZq1dhEE";
                    profile.Environment = "sandbox";
                    profile.API_URL = "https://api-3t.sandbox.paypal.com/nvp";

                    break;
            }
        }

        public string SetExpressCheckout()
        {
            string url = "https://api-3t.sandbox.paypal.com/nvp";

            NVPCodec encoder = new NVPCodec();
            encoder["USER"] = "307399609_api1.qq.com";
            encoder["PWD"] = "1371720221";
            encoder["SIGNATURE"] = "AHzv8Q3aqsIV48g4wRfSoFM34P4OAaoawuOHnUn.WsuqhOeDKZq1dhEE";
            encoder["VERSION"] = "98";

            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = "http://www.firstpatche.com/";
            encoder["CANCELURL"] = "http://www.firstpatche.com/";
            encoder["PAYMENTREQUEST_0_AMT"] = "10";

            string requestString=encoder.Encode();
            string responseString = HttpHelper.GetWebRequest(url, requestString, "POST", System.Text.Encoding.UTF8);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(responseString);
            return "";
        }
    }
}
