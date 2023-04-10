using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;

public class SuggestedItemData
{
    public string Title
    {
        get;
        set;
    }

    public string? Description
    {
        get;
        set;
    }

    public SourceCategory SourceCategory
    {
        get;
        set;
    }
}
