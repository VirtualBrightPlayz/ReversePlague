using EXILED;

namespace ReversePlague
{
	public class Plugin : EXILED.Plugin
	{
		private EventHandlers ev;

		public override void OnEnable()
		{
			ev = new EventHandlers();

			Events.WaitingForPlayersEvent += ev.OnWaitingForPlayers;
			Events.RoundStartEvent += ev.OnRoundStart;
			Events.RoundRestartEvent += ev.OnRoundRestart;
			Events.PlayerDeathEvent += ev.OnPlayerDie;
		}

		public override void OnDisable()
		{
			Events.WaitingForPlayersEvent -= ev.OnWaitingForPlayers;
			Events.RoundStartEvent -= ev.OnRoundStart;
			Events.RoundRestartEvent -= ev.OnRoundRestart;
			Events.PlayerDeathEvent -= ev.OnPlayerDie;

			ev = null;
		}

		public override void OnReload() { }

		public override string getName { get; } = "ReversePlague";
	}
}
