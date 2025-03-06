using Rocket.API;

namespace Kill4Heal
{
    public class Configuration : IRocketPluginConfiguration
    {
        public uint Skull_HEALTH, Arm_HEALTH, Leg_HEALTH, Body_HEALTH, Foot_HEALTH, Spine_HEALTH, Front_HEALTH, Back_HEALTH;
        public bool ConsoleMsgEnabled, PlayerMsgEnabled;
        public float plrMsg_r, plrMsg_g, plrMsg_b;
        public string consoleMsgColor;
        public void LoadDefaults()
        {
            Skull_HEALTH = 75;
            Arm_HEALTH = 30;
            Leg_HEALTH = 20;
            Body_HEALTH = 50;
            Foot_HEALTH = 10;
            Spine_HEALTH = 40;
            Front_HEALTH = 20;
            Back_HEALTH = 20;
            ConsoleMsgEnabled = true;
            PlayerMsgEnabled = true;
            plrMsg_r = 255;
            plrMsg_g = 0;
            plrMsg_b = 0;
            consoleMsgColor = "red";
        }
    }
}