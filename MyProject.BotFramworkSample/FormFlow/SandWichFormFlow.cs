using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace MyProject.BotFramworkSample.FormFlow
{    
    [Serializable]
    public class SandWichOrder
    {
        public SandWichOption? 種類;
        public LengthOptions? サイズ;

        public static IForm<SandWichOrder> BuildForm()
        {
            return new FormBuilder<SandWichOrder>()
                .Message("ようこそシンプルサンドウィッチボットへ！")
                .Build();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SandWichOption
    {
        RoastBeef,
        BLT,
        SubwayClub
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LengthOptions
    {
        Regular,
        Footlong
    }

}

