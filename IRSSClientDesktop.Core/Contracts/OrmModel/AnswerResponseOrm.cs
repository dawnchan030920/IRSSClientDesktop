using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class AnswerResponseOrm
{
    public Answer[] answers
    {
        get; set;
    }
}

public class Answer
{
    public string summary
    {
        get; set;
    }
    public Reference[] references
    {
        get; set;
    }
}

public class Reference
{
    public string title
    {
        get; set;
    }
    public string content
    {
        get; set;
    }
}