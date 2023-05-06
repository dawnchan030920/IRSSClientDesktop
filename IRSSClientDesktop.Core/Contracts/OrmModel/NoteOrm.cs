using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class NoteOrm
{
    public string article_id
    {
        get; set;
    }
    public Note note
    {
        get; set;
    }
}

public class Note
{
    public string content
    {
        get; set;
    }
    public string time
    {
        get; set;
    }
}

