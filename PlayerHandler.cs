namespace AODPSo
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class PlayerHandler
    {
        internal List<Player> Players { get; }

        public PlayerHandler(Form1 f)
        {
            Players = new List<Player>();
            frm = f;
        }

        public void AddPlayer(string nickname, int id)
        {
            var pp = new Player(nickname, id);
            var a = true;
            Players.ForEach(delegate(Player p)
            {
                if (p.Id == id)
                {
                    a = false;
                }
            });
            if (a)
            {
                Players.Add(pp);
            }
        }

        internal void ClearData()
        {
            zfame = 0.0;
            zoneTime = DateTime.Now;
            var playerList = Players;
            Action<Player> action;
            if ((action = inClass.insideAction) == null)
            {
                action = inClass.insideAction = inClass.insideClass.ClearData;
            }

            playerList.ForEach(action);
            Players.Clear();

        }

        internal void OutputData()
        {
            var oput = "";
            var dsec = DateTime.Now.Subtract(zoneTime).TotalSeconds;


            foreach (var player in Players)
            {
                player.DPS = (int) (player.dealt / dsec);
            }
            var maxDPS = Players.Max(player => player.DPS);

            var dpsPerc = new long[Players.Count];
            Players.Sort((A, B) => B.DPS.CompareTo(A.DPS));

            for (int i = 0; i < Players.Count; i++)
            {
                dpsPerc[i] = (int)(((float)Players[i].DPS*100 / (float)maxDPS));
            }
            Players.ForEach(delegate(Player p)
            {
                {
                    oput = string.Concat(oput, p.ToString(), " DPS: ", p.DPS.ToString(), Environment.NewLine);
                }
            });


            var lineSize = 13;

            var bgColor = new Bitmap(frm.mForm.Width, lineSize * Players.Count);

            var currentPlayer = 0;

            for (var i = 0; i < bgColor.Height; i++)
            {
                if (i % lineSize == 0 && i!=0)
                {
                    currentPlayer++;

                    
                }
                for (var j = 0; j < bgColor.Width; j++)
                {
                    var proc = ((float)j / bgColor.Width)*100;

                    if (currentPlayer <= Players.Count)
                    {
                        bgColor.SetPixel(j,i, proc>dpsPerc[currentPlayer]?Color.Transparent : Players[currentPlayer].color);
                    }
                    else
                    {
                        bgColor.SetPixel(j, i, Color.Transparent);
                    }
                }
            }

            frm.mForm.pubLabel.BackgroundImage = bgColor;
            frm.mForm.pubLabel.BackgroundImageLayout =ImageLayout.None;
            

            frm.mForm.labelText = oput;
        }

        internal void OutputFame()
        {
            var oput = "";
            var diff = DateTime.Now.Subtract(zoneTime);
            oput = oput + "Time in Zone: " + diff + Environment.NewLine;
            oput = oput + "Fame in Zone: " + (int) zfame + Environment.NewLine;
            oput = oput + "Money in Zone: " + (int) zmoney + Environment.NewLine;

            var dsec = diff.TotalSeconds;
            oput = oput + "Fame per Minute In Zone: " + (int) (zfame / dsec * 60.0) + Environment.NewLine;
            oput = oput + "Money per Minute In Zone: " + (int) (zmoney / dsec * 60.0) + Environment.NewLine;

            var tdiff = DateTime.Now.Subtract(appTime);
            oput = oput + "Time in App: " + tdiff + Environment.NewLine;

            oput = oput + "Fame in App: " + (int) fame + Environment.NewLine;
            oput = oput + "Money overall: " + (int) money + Environment.NewLine;

            var dsec2 = tdiff.TotalSeconds;
            oput = oput + "Fame per Minute OverAll: " + (int) (fame / dsec2 * 60.0) + Environment.NewLine;
//            oput = oput + "Money per Minute OverAll: " + (int) (money / dsec2 * 60.0) + Environment.NewLine;

            frm.fForm.fText = oput;
        }

        
        public bool RemovePlayer(int id)
        {
            return Players.RemoveAll(x => x.Id == id) > 0;
        }

        internal void UpdatePlayerDealt(int id, int amt)
        {
            Players.ForEach(delegate(Player p)
            {
                if (p.Id == id)
                {
                    p.dealt += amt;
                }
            });
        }

        internal void UpdatePlayerHealed(int id, int amt)
        {
            Players.ForEach(delegate(Player p)
            {
                if (p.Id == id)
                {
                    p.healed += amt;
                }
            });
        }

        internal void UpdatePlayerTaken(int id, int amt)
        {
            Players.ForEach(delegate(Player p)
            {
                if (p.Id == id)
                {
                    p.taken += amt;
                }
            });
        }

        public DateTime appTime = DateTime.Now;

        public double fame;
        public double money;

        public readonly Form1 frm;

        public int self;

        public double zfame;
        public double zmoney;

        public DateTime zoneTime = DateTime.Now;

        [CompilerGenerated, Serializable]
        private sealed class inClass
        {
            internal void ClearData(Player p)
            {
                p.dealt = 0L;
                p.healed = 0L;
                p.taken = 0L;
            }

            public static readonly inClass insideClass = new inClass();

            public static Action<Player> insideAction;
        }
    }
}