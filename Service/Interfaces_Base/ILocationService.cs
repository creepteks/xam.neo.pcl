using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    interface ILocationService
    {
        Task InitializeAsync();
        Position currentPos { get; }
    }
}
