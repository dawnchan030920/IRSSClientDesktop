using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSSClientDesktop.BindFunctions
{
    public class BindHelpers
    {
        public static string GetUserDisplayed(string? username, bool isLoggedIn) => isLoggedIn && username != null ? username : "用户";
    }
}
