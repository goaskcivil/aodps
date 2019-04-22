namespace AODPSo
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class PacketHandler : IPhotonEventHandler
    {
        private FileStream ostrm;
        private StreamWriter writer;
        private TextWriter oldOut = Console.Out;

        public PacketHandler(PlayerHandler playerHandler)
        {
            this.playerHandler = playerHandler;


//            try
//            {
//                ostrm = new FileStream("./LOG.txt", FileMode.OpenOrCreate, FileAccess.Write);
//                writer = new StreamWriter(ostrm);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Cannot open Redirect.txt for writing");
//                Console.WriteLine(e.Message);
//                return;
//            }
//
//            Console.SetOut(writer);
        }

        public void OnEvent(byte code, Dictionary<byte, object> parameters)
        {
            if (code == 2)
            {
                return;
            }

            object val;
            parameters.TryGetValue(252, out val);
            if (val == null)
            {
                return;
            }

            var iCode = 0;
            if (!int.TryParse(val.ToString(), out iCode))
            {
                return;
            }
//            Console.WriteLine("==============");
//            Console.WriteLine(Enum.GetName(typeof(EventCodes),iCode));
//            Console.WriteLine("==============");
//
//            for (var index = 0; index < parameters.Count; index++)
//            {
//                Console.WriteLine("p" + index + "=" + parameters[(byte) index] + ";");
//            }
//
//            Console.WriteLine("---------------");


            var eventCode = (EventCodes) iCode;
            switch (eventCode)
            {
                case EventCodes.RegenerationCraftingChanged:
                    Console.WriteLine("Self ID: " + parameters[0]);
//                    playerHandler.frm.LogLabel.Text += "RCC;";
                    playerHandler.self = int.Parse(parameters[0].ToString());
                    return;
                case EventCodes.FullAchievementProgressInfo:
                    Console.WriteLine("Self ID: " + parameters[0]);
//                    playerHandler.frm.LogLabel.Text += "FAPI;";

                    playerHandler.self = int.Parse(parameters[0].ToString());
                    return;
                case EventCodes.JoinFinished:
//                    playerHandler.frm.LogLabel.Text += "JF;";

                    onJoinFinished(parameters);
                    return;
                case EventCodes.HealthUpdate:
//		            playerHandler.frm.LogLabel.Text += "HU;";

                    onHealthEvent(parameters);
                    return;
                case EventCodes.NewCharacter:
//		            playerHandler.frm.LogLabel.Text += "NC;";

//                    onNewCharacterEvent(parameters);
                    return;
                case EventCodes.UpdateFame:
//		            playerHandler.frm.LogLabel.Text += "FU;";

                    var compVal = int.Parse(parameters[2].ToString()) * 0.00015;
                    playerHandler.fame += compVal;
                    playerHandler.zfame += compVal;
                    playerHandler.OutputFame();
                    return;
                case EventCodes.UpdateMoney:
//                    playerHandler.frm.LogLabel.Text += "MU;";

                    var p = 1;
                    playerHandler.frm.LogLabel.Text += "p" + p + "=" + parameters[(byte) p];

                    if (playerHandler.money == 0)
                    {
//                        playerHandler.frm.LogLabel.Text += ";FMU;";

                        playerHandler.money = (double) long.Parse(parameters[(byte) p].ToString()) / 10000;
                        playerHandler.OutputFame();

                        return;
                    }

//                    playerHandler.frm.LogLabel.Text += "UMU;";

                    var newMoney = (double) long.Parse(parameters[(byte) p].ToString()) / 10000;
                    var delta = newMoney - playerHandler.money;
                    playerHandler.money = newMoney;
                    playerHandler.zmoney += delta;
                    playerHandler.OutputFame();
                    return;
                case EventCodes.FullQuestInfo:
//                    playerHandler.frm.LogLabel.Text += "FQI;";
                    Console.WriteLine("Self ID: " + parameters[0]);
                    playerHandler.self = int.Parse(parameters[0].ToString());
                    return;
                case EventCodes.PartyPlayerJoined:
                    playerHandler.frm.LogLabel.Text += "PPJ;";
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        playerHandler.frm.LogLabel.Text += "p" + index + "=" + parameters[(byte) index] + ";";
                    }

                    return;
                case EventCodes.PartyPlayerUpdated:
                    playerHandler.frm.LogLabel.Text += "PPU;";
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        playerHandler.frm.LogLabel.Text += "p" + index + "=" + parameters[(byte) index] + ";";
                    }

                    return;
                case EventCodes.PartyInvitation:
                    playerHandler.frm.LogLabel.Text += "PI;";
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        playerHandler.frm.LogLabel.Text += "p" + index + "=" + parameters[(byte) index] + ";";
                    }

                    return;
                case EventCodes.PartyJoined:
                    playerHandler.frm.LogLabel.Text += "PJ;";
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        playerHandler.frm.LogLabel.Text += "p" + index + "=" + parameters[(byte) index] + ";";
                    }

                    return;
                case EventCodes.ChatSay:
                    playerHandler.frm.LogLabel.Text += "CS;";
                    if (parameters[2].ToString().ToLower() == "-dpsjoin")
                    {
                        playerHandler.AddPlayer(parameters[1].ToString(), int.Parse(parameters[0].ToString()));
                    }

                    if (parameters[2].ToString().ToLower() == "-dpsreset")
                    {
                        Reset();
                    }

                    return;
            }
        }

        private void onHealthEvent(Dictionary<byte, object> parameters)
        {
            var targ = int.Parse(parameters[0].ToString());
            var source = int.Parse(parameters[6].ToString());
            var change = int.Parse(parameters[2].ToString());
            if (change > 0)
            {
                playerHandler.UpdatePlayerHealed(source, change);
            }
            else
            {
                if (source != targ)
                {
                    playerHandler.UpdatePlayerDealt(source, -change);
                }

                playerHandler.UpdatePlayerTaken(targ, -change);
            }

            playerHandler.OutputData();
        }

        private void Reset()
        {
            playerHandler.ClearData();
            playerHandler.zoneTime = DateTime.Now;
            playerHandler.frm.mForm.labelText = "";
        }

        private void onJoinFinished(Dictionary<byte, object> parameters)
        {
Reset();
//            playerHandler.AddPlayer("Me", playerHandler.self);
            playerHandler.OutputData();
            playerHandler.OutputFame();
        }

        private void onNewCharacterEvent(Dictionary<byte, object> parameters)
        {
            var id = int.Parse(parameters[0].ToString());
            var nick = parameters[1].ToString();
            object oGuild = "";
            parameters.TryGetValue(8, out oGuild);
            if (oGuild != null)
            {
                oGuild.ToString();
            }

            parameters[44].ToString();
            playerHandler.AddPlayer(nick, id);
            Console.WriteLine("New Player: " + id + " " + nick);
        }

        public void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
        {
            var iCode = 0;
            if (!int.TryParse(parameters[253].ToString(), out iCode))
            {
            }
        }

        public void OnResponse(byte operationCode, short returnCode, Dictionary<byte, object> parameters)
        {
        }

        private readonly PlayerHandler playerHandler;
    }
}