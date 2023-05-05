using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;
public class MessageMentionNotificationData
{
    public string Content
    {
        get;
        set;
    }

    public string OriginalContent
    {
        get;
        set;
    }

    public string Username
    {
        get;
        set;
    }

    public DateTime Time
    {
        get;
        set;
    }

    public string Id
    {
        get;
        set;
    }

    public bool IsFavorite
    {
        get;
        set;
    }
}
