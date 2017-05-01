using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace MyProject.BotFramworkSample.Dialogs
{
    /// <summary>
    /// チャットメッセージの回数をカウントするダイアログ
    /// </summary>
    [Serializable]
    public class MessageCountDialog : IDialog<object>
    {
        protected int count = 1;
        
        /// <summary>
        /// ダイアログ呼び出し時に実行されるメソッド
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecievedAsync);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            // Messageを取得
            var message = await result;

            // Messageが「reset」の場合は、カウントリセットメッセージを表示
            // 「reset」以外の場合は、何回メッセージを受信したかを表示
            if (message.Text == "リセット")
            {
                PromptDialog.Confirm(
                    context,
                    AfterRestAsync,
                    "カウントをリセットしてもいいですか？",
                    "「はい」か「いいえ」で答えてください",
                    promptStyle: PromptStyle.None);
            }
            else
            {
                await context.PostAsync($"あなたとは{this.count++}回、会話しましたですわ∑(*'ω'*)");
                context.Wait(MessageRecievedAsync);
            }
        }

        /// <summary>
        /// リセット判定Dialog実施時の回答結果を受け取るためのデリゲード
        /// Trueであれば、プロパティのカウントをリセット
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task AfterRestAsync(IDialogContext context, IAwaitable<bool> result)
        {
            var confirm = await result;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("カウントをリセットしました");
            }
            else
            {
                await context.PostAsync("カウントをリセットしませんでした");
            }

            context.Wait(MessageRecievedAsync);
        }
    }
}