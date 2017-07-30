using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Diagnostics;
using Acr.UserDialogs;

namespace Tag.Core
{
    class LocationService : ILocationService
    {
        private Position _currentPos = null;
        public Position currentPos
        {
            get { return _currentPos; }
        }
        private IGeolocator geolocator = CrossGeolocator.Current;
 
        public async Task InitializeAsync()
        {
            try
            {
                // I want to save the location for further usage
                _currentPos = await geolocator.GetPositionAsync(TimeSpan.FromSeconds(1));
                Debug.WriteLine($"current position lat {_currentPos.Latitude} long {_currentPos.Longitude}");
            }
            catch (Exception)
            {
                // #revise
                // errors are thrown most likely because of android/ios/windowsphone location service being disabled, we have to do something about it.
                await UserDialogs.Instance.AlertAsync("لطفا موقعیت خود را فعال کنید", "خطا", "فهمیدم");
                // I first get the lastknown pos, to have at least something! 
                _currentPos = await geolocator.GetLastKnownLocationAsync(); 
                //Debug.WriteLine($"LocationService > InitializeAsync : {e.Message}");
            }
        }
    }
}
