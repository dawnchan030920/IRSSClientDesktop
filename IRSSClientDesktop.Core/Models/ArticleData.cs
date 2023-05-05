using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;
public class ArticleData
{
    public string Title
    {
        get;
        set;
    }

    public string Platform
    {
        get;
        set;
    }

    public string MediaType
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

    public string Topic
    {
        get;
        set;
    }

    public string Id
    {
        get;
        set;
    }

    public Platform PlatformMapped
    {
        get
        {
            if (Platform.ToLower().StartsWith('z')) return Models.Platform.Zhihu;
            else if (Platform.ToLower().StartsWith('b')) return Models.Platform.Bilibili;
            else if (Platform.ToLower().StartsWith('w')) return Models.Platform.WeChat;
            else return Models.Platform.WeChat;
        }
    }

    public MediaType MediaTypeMapped
    {
        get
        {
            if (MediaType.ToLower().StartsWith('v')) return Models.MediaType.Video;
            else if (MediaType.ToLower().StartsWith('w')) return Models.MediaType.Words;
            else return Models.MediaType.Words;
        }
    }

    public bool IsFavorite
    {
        get;
        set;
    }
}
