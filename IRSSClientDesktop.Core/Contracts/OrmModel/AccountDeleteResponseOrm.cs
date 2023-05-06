using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;

public class AccountDeleteResponseOrm
{
    public AccountWithUsernameId[] accounts
    {
        get; set;
    }
    public int status_code
    {
        get; set;
    }
}
