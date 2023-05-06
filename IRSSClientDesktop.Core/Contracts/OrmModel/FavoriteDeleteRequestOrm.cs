using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Contracts.OrmModel;
public class FavoriteDeleteRequestOrm
{
    public string type
    {
        get; set;
    }
    public string[] ids
    {
        get; set;
    }
}
