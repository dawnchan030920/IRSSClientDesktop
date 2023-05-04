using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;
public class MessageSummaryData
{
    public string Group
    {
        get;
        set;
    }

    public string Summary
    {
        get;
        set;
    }

    public string OriginalContent
    {
        get;
        set;
    }
}
