using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class CheckAuthResponseOrm
{
    public int status_code
    {
        get;
        set;
    }

    public string message
    {
        get;
        set;
    }
}
