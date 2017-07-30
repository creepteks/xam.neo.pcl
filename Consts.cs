using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    static class Consts
    {
        #region server IPs & port
        public const string EMULATOR_IP = "169.254.80.80";
        public const string WEBSERVER_PORT = "8888";
        internal const string EMULATOR_REST_ENDPOINT = "https://169.254.80.80:8888/api/";
        internal const string DEVICE_RET_ENDPOINT = "http://127.0.0.1:8888/api/";

        #endregion

        #region google Auth
        public const string GAuthAndroidClientID = "28120777995-pqkmcgk2phdl318pmt390nif37l0klm2.apps.googleusercontent.com";
        public const string GAuthiOSClientID = "somethign"; // #revise
        public const string GAuthWindowsClientID = "some else"; // #revise
        //public const string GAuthClientSecret = "";
        //public const string GAuthScope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login";
        public const string GAuthScope = "profile";
        public const string GAuthAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public const string GAuthAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public const string GAuthAndroidRedirectUrl = "tag.anslid.ir:/oauth2redirect";
        public const string GAuthiOSRedirectUrl = "tag.anslid.ir.ios:/oauth2redirect";
        public const string GAuthWindowsRedirectUrl = "tag.anslid.ir.windows:/oauth2redirect";
        //public const string GAuthMapApiRequests = "https://maps.googleapis.com/maps/api/";
        #endregion


        #region Persian Text Compat
        public const string PR_OKAY_TEXT = "باشه";
        public const string PR_CONNECTION_ERROR_TEXT = "شبکه در دسترس نیست";
        #endregion


        public static string[] SearchTagSuggestions = new string[] {
                                                                    "شال",
                                                                    "روسری",
                                                                    "مانتو",
                                                                    "شلوار",
                                                                    "پیراهن",
                                                                    "بلوز",
                                                                    "جلیقه",
                                                                    "دامن",
                                                                    "لباس عروس",
                                                                    "کت و شلوار",
                                                                    "تی‌شرت",
                                                                    "Test",
                                                                    "test",
                                                                    "suit",
                                                                    "jeans",
                                                                    "cotton",
                                                                    "lcykiki", //!!! I donno the spelling
                                                                    };

    }
}
