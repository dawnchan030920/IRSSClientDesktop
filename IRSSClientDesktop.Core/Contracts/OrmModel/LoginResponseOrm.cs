using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class LoginResponseOrm
{
    public int status_code
    {
        get; set;
    }
    public int id
    {
        get; set;
    }
    public string token
    {
        get; set;
    }
}