using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;
public class NoteData
{
    public string Id
    {
        get;
        set;
    }

    public string Content
    {
        get;
        set;
    }

    public DateTime Time
    {
        get;
        set;
    }

    public string ArticleTitle => "Sample Article Title"; // TODO: Access article data using service.
}
