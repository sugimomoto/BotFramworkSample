using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;
using MyProject.BotFramworkSample.FormFlow;

namespace MyProject.BotFramworkSample.Dialogs
{
    public static class SandwichRequestDialog
    {
        public static IDialog<SandWichOrder> MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(SandWichOrder.BuildForm));
        }
    }
}