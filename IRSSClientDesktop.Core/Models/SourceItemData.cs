using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.Core.Models;

public class SourceItemData
{
    public string Account
    {
        get;
        set;
    }

    public Platform Platform
    {
        get;
        set;
    }

    public override string ToString() => $"{Enum.GetName(typeof(Platform), Platform)} - {Account}";

    public override bool Equals(object obj) => obj is SourceItemData other && Account == other.Account && Platform == other.Platform;
}