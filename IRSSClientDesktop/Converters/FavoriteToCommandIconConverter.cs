using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace IRSSClientDesktop.Converters
{
    public class FavoriteToCommandIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool favorite)
            {
                if (favorite)
                {
                    return "\uE8D9";
                }
            }

            return "\uE734";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
    }
}
