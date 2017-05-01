using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace MyProject.BotFramworkSample.Dialogs
{
    /// <summary>
    /// 受信したメッセージをそのまま返すダイアログ
    /// </summary>
    [Serializable]
    public class MessageEchoDialog : IDialog<object>
    {
        /// <summary>
        /// ダイアログ呼び出し時に実行されるメソッド
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecivedAsync);
        }

        /// <summary>
        /// 受け取ったメッセージをそのまま返す
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task MessageRecivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.PostAsync($"あなたは{message.Text}と言いましたね？");
            context.Wait(MessageRecivedAsync);
        }
    }
}