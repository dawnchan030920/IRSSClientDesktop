﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class NoteDeleteRequestOrm
{
    public string[] article_ids
    {
        get; set;
    }
}
