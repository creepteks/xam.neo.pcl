using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tag.Core
{
    public static class UIService
    {
        public static void InvalidateSize(this View view)
        {
            if (view != null)
            {
                Type viewType = typeof(VisualElement);
                IEnumerable<MethodInfo> methods = viewType.GetTypeInfo()
                                                          .DeclaredMethods;
                MethodInfo method = methods.FirstOrDefault(m => m.Name == "InvalidateMeasure");

                if (method != null)
                {
                    method.Invoke(view, null);
                }
            }
        }
    }
}
