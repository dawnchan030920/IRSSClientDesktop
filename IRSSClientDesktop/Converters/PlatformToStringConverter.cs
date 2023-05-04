using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSSClientDesktop.Core.Models;
using Microsoft.UI.Xaml.Data;

namespace IRSSClientDesktop.Converters;
public class PlatformToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is Platform platform)
        {
            return platform switch
            {
                Platform.QQ => "QQ",
                Platform.WeChat => "微信",
                Platform.Bilibili => "Bilibili",
                Platform.Zhihu => "知乎"
            };
        }
        throw new ArgumentException("Value should be Platform enum.");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}
