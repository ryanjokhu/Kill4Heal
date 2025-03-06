using System;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using Rocket.Unturned.Events;
using SDG.Unturned;
using Rocket.API.Collections;
using UnityEngine;

namespace Kill4Heal
{
    public class Kill4Heal : RocketPlugin<Configuration>
    {
        public static Kill4Heal Instance;

        protected override void Load()
        {
            Rocket.Core.Logging.Logger.Log("=================");
            Rocket.Core.Logging.Logger.Log("Kill4Heal Loaded!");
            Rocket.Core.Logging.Logger.Log("created by: Ryan");
            Rocket.Core.Logging.Logger.Log("=================");
            UnturnedPlayerEvents.OnPlayerDeath += Events_OnPlayerDeath;
        }
        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= Events_OnPlayerDeath;
            Rocket.Core.Logging.Logger.Log("Kill4Heal Unloaded!");
        }

        public void Events_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, Steamworks.CSteamID murderer)
        {
            UnturnedPlayer killer = UnturnedPlayer.FromCSteamID(murderer);
            switch (limb)
            {
                case ELimb.SKULL:
                    GiveHealth(Instance.Configuration.Instance.Skull_HEALTH, killer, player, Translate("skull_name"));
                    break;
                case ELimb.LEFT_ARM:
                    GiveHealth(Instance.Configuration.Instance.Arm_HEALTH, killer, player, Translate("arm_name"));
                    break;
                case ELimb.RIGHT_ARM:
                    GiveHealth(Instance.Configuration.Instance.Arm_HEALTH, killer, player, Translate("arm_name"));
                    break;
                 case ELimb.LEFT_FOOT:
                    GiveHealth(Instance.Configuration.Instance.Foot_HEALTH, killer, player, Translate("foot_name"));
                    break;
                case ELimb.RIGHT_FOOT:
                    GiveHealth(Instance.Configuration.Instance.Foot_HEALTH, killer, player, Translate("foot_name"));
                    break;
                case ELimb.RIGHT_FRONT:
                    GiveHealth(Instance.Configuration.Instance.Front_HEALTH, killer, player, Translate("front_name"));
                    break;
                case ELimb.LEFT_FRONT:
                    GiveHealth(Instance.Configuration.Instance.Front_HEALTH, killer, player, Translate("front_name"));
                    break;
                case ELimb.SPINE:
                    GiveHealth(Instance.Configuration.Instance.Spine_HEALTH, killer, player, Translate("spine_name"));
                    break;
                case ELimb.LEFT_LEG:
                    GiveHealth(Instance.Configuration.Instance.Leg_HEALTH, killer, player, Translate("leg_name"));
                    break;
                case ELimb.RIGHT_LEG:
                    GiveHealth(Instance.Configuration.Instance.Leg_HEALTH, killer, player, Translate("leg_name"));
                    break;
                case ELimb.LEFT_BACK:
                    GiveHealth(Instance.Configuration.Instance.Back_HEALTH, killer, player, Translate("back_name"));
                    break;
                case ELimb.RIGHT_BACK:
                    GiveHealth(Instance.Configuration.Instance.Back_HEALTH, killer, player, Translate("back_name"));
                    break;

        }
    }

        public void GiveHealth(uint amount, UnturnedPlayer player, UnturnedPlayer killed, string limbName)
        {
            if (player.Health < 100) 
            {
                byte healAmount = (byte)Math.Min(amount, 100 - player.Health);
                player.Heal((byte)healAmount);
            }
            Color c = new Color();
            c.r = Instance.Configuration.Instance.plrMsg_r;
            c.g = Instance.Configuration.Instance.plrMsg_g;
            c.b = Instance.Configuration.Instance.plrMsg_b;
            UnturnedChat.Say(player, Translate("msg_playermsg", amount, killed, limbName), c);
        }

        public new TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList(){
                    {"msg_playermsg","You received {0} health for killing {1} in the {2}."},
                    {"spine_name", "spine"},
                    {"arm_name", "arm"},
                    {"leg_name", "leg"},
                    {"back_name", "back"},
                    {"front_name", "front"},
                    {"foot_name", "foot"},
                    {"skull_name", "skull"}
                };
            }
        }
    }
}
