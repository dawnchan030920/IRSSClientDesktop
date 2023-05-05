using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;

public class FavoriteData
{
    public DateTime Time
    {
        get;
        set;
    }

    public string Content
    {
        get;
        set;
    }

    public string Source
    {
        get;
        set;
    }

    public FavoriteType Type
    {
        get;
        set;
    }

    public string Id
    {
        get;
        set;
    }
}
