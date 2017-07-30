using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Security.Cryptography.X509Certificates;

//namespace neo.pcl
//{
//    public class WebSocketService
//    {
//        private void InitializeWebsocker()
//        {
//            using (var ws = new WebSocket("wss://localhost:8888/api/ws"))
//            {
//                ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
//                X509Certificate cert = X509Certificate.CreateFromCertFile("c:\\certs\\cert.pem");
//                ws.SslConfiguration.ClientCertificates = new X509CertificateCollection();
//                ws.SslConfiguration.ClientCertificates.Add(cert);
//                //ws.SslConfiguration.ServerCertificateValidationCallback = (e)=>
//                //{

//                //};
//                ws.Connect();
//                ws.OnError += (sender, e) =>
//                {
//                    Debug.WriteLine(e.Message);
//                };
//                ws.OnMessage += (sender, e) =>
//                {
//                };

//            }
//        }
//}
