using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;
public class AnswerData
{
    public string Summary
    {
        get;
        set;
    }

    public List<AnswerReference> References
    {
        get;
        set;
    } = new();
}