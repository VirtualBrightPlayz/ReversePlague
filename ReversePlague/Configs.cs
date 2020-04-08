namespace ReversePlague
{
	class Configs
	{
		internal static float range;
		internal static float interval;

		internal static int scp049HealAmount;
		internal static int scpHealAmount;

		internal static bool tutorialHeal;
		internal static bool tutorialInfect;

        internal static float teleportDelay;

		public static void ReloadConfigs()
		{
			range = Plugin.Config.GetFloat("rp_range", 5f);
			interval = Plugin.Config.GetFloat("rp_interval", 1f);

			scp049HealAmount = Plugin.Config.GetInt("rp_049_heal_amount", 1);
			scpHealAmount = Plugin.Config.GetInt("rp_scp_heal_amount", 1);

			tutorialHeal = Plugin.Config.GetBool("rp_tutorial_heal", false);
			tutorialInfect = Plugin.Config.GetBool("rp_tutorial_infect", true);

            teleportDelay = Plugin.Config.GetFloat("rp_teleport_delay", 0.2f);
		}
	}
}
