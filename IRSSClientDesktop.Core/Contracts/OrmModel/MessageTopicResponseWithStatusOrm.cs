﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class MessageTopicResponseWithStatusOrm
{
    public MessageTopicWithTopicId[] topics
    {
        get;
        set;
    }

    public string status_code
    {
        get;
        set;
    }
}
