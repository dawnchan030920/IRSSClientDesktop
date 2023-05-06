using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class MessageTopicWithTopicId
{
    public string topic
    {
        get;
        set;
    }

    public string id
    {
        get;
        set;
    }
}
