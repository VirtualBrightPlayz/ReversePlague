using EXILED.Extensions;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReversePlague
{
	partial class EventHandlers
	{
		private IEnumerator<float> BeginPlague()
		{
			while (isRoundStarted)
			{
				foreach (ReferenceHub scp049 in Player.GetHubs().Where(x => x.GetRole() == RoleType.Scp049))
				{
					foreach (ReferenceHub zombie in Player.GetHubs().Where(x => x.GetRole() == RoleType.Scp0492))
					{
						int newHp = (int)scp049.playerStats.Health + Configs.scp049HealAmount;
						scp049.playerStats.Health = newHp > scp049.playerStats.maxHP ? scp049.playerStats.maxHP : newHp;

						foreach (ReferenceHub player in Player.GetHubs().Where(x => x.GetRole() != RoleType.Scp049 && (Configs.tutorialHeal ? x.GetTeam() == Team.SCP || x.GetTeam() == Team.TUT : x.GetTeam() == Team.SCP)))
						{
							if (Vector3.Distance(scp049.transform.position, player.transform.position) < Configs.range)
							{
								int newHp1 = (int)player.playerStats.Health + Configs.scpHealAmount;
								player.playerStats.Health = newHp1 > player.playerStats.maxHP ? player.playerStats.maxHP : newHp1;
							}
						}
					}
				}
				yield return Timing.WaitForSeconds(Configs.interval);
			}
		}
	}
}
