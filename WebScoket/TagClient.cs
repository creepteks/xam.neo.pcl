using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Acr.UserDialogs;

namespace neo.pcl
{
    public class TagClient: IWebsocktClient
    {
        //fields
        //dependencies
        private WebSocket websocket;

        public async Task InitAsync()
        {
            Task[] tasks = new Task[] { SetUpWebsocket() };
            for (int i = 0; i < tasks.Length; i++)
            {
                await tasks[i];
            }
            //await Task.FromResult(true);
        }

        private async Task SetUpWebsocket()
        {
            //websocket = new WebSocket("wss://127.0.0.1/api/ws"); // when running on Actual device! this is my IP.
            websocket = new WebSocket("wss://169.254.80.80:8888/api/ws"); // when runnig on VS emulator
            //websocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            //X509Certificate cert = X509Certificate.CreateFromCertFile("c:\\certs\\cert.pem");
            //websocket.SslConfiguration.ClientCertificates = new X509CertificateCollection();
            //websocket.SslConfiguration.ClientCertificates.Add(cert);
            //websocket.SslConfiguration.ServerCertificateValidationCallback = (e)=>
            //{

            //};
            websocket.OnMessage += Ws_OnMessage;
            websocket.OnOpen += Ws_OnOpen;
            websocket.OnError += Ws_OnError;
            await websocket.ConnectAsync();
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            UserDialogs.Instance.ShowError(e.Message);
        }

        private async void Ws_OnOpen(object sender, EventArgs e)
        {
            //await websocket.SendAsync("{\"messageType\":\"Authentication\",\"message\":\"154668765\"}");
            await SendQueryToBackend("{\"hi\":\"salam\"}");
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            UserDialogs.Instance.ShowError(e.Data);
        }

        public async Task SendQueryToBackend(string jsonAction)
        {
            await websocket.SendAsync(jsonAction);
        }
        public bool isOnline() => /*CrossConnectivity.Current.IsConnected;*/ true;
        //{
            //// #test
            //return true;
            //return await CrossConnectivity.Current.IsRemoteReachable("8.8.8.8"); // this is google servers, but not restricted to Android, of Course. (Neo as a smartass);
            
            //Runtime runtime = Runtime.GetRuntime();
            //try
            //{
            //    Java.Lang.Process ipProcess = runtime.Exec("/system/bin/ping -c 1 8.8.8.8");
            //    int exitValue = ipProcess.WaitFor();
            //    return (exitValue == 0);
            //}
            //catch (Java.IO.IOException e) { e.PrintStackTrace(); }
            //catch (InterruptedException e) { e.PrintStackTrace(); }

            //return false;
        //}

    }
}
