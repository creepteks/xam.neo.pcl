using FFImageLoading.Cache;
using FFImageLoading.Forms;
using System.Threading.Tasks;

namespace neo.pcl.Helpers
{
    public class CacheHelper
    {
        public static async Task RemoveFromCache(string url)
        {
            await CachedImage.InvalidateCache(url, CacheType.All, true);
        }
    }
}
