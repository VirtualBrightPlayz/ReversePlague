using EXILED;
using EXILED.Extensions;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReversePlague
{
	partial class EventHandlers
	{
		private bool isRoundStarted = false;

		private Dictionary<ReferenceHub, CoroutineHandle> coroutines = new Dictionary<ReferenceHub, CoroutineHandle>();

		public void OnWaitingForPlayers()
		{
			Configs.ReloadConfigs();
		}

		public void OnRoundStart()
		{
			isRoundStarted = true;
			Timing.RunCoroutine(BeginPlague());
		}

		public void OnRoundRestart()
		{
			isRoundStarted = false;

			Timing.KillCoroutines(coroutines.Values);
			coroutines.Clear();
		}

		public void OnPlayerDie(ref PlayerDeathEvent ev)
		{
			Team team = ev.Player.GetTeam();
			if (team == Team.SCP || team == Team.RIP || (team == Team.TUT && !Configs.tutorialInfect)) return;
			foreach (ReferenceHub scp in Player.GetHubs().Where(x => x.GetRole() == RoleType.Scp049))
			{
				if (Vector3.Distance(ev.Player.transform.position, scp.transform.position) < Configs.range)
				{
					foreach (var item in ev.Player.inventory.items)
					{
						ev.Player.inventory.SetPickup(item.id, item.durability, ev.Player.transform.position, ev.Player.transform.rotation, 0, 0, 0);
					}
					ReferenceHub player = ev.Player;
					Vector3 pos = player.transform.position;
					ev.Player.characterClassManager.SetPlayersClass(RoleType.Scp0492, ev.Player.gameObject);
					Timing.CallDelayed(Configs.teleportDelay, () => player.plyMovementSync.OverridePosition(pos, 0f));
				}
			}
		}
	}
}
