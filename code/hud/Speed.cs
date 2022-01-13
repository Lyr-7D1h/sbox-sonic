using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace sonic.hud
{
	public class Speed : Panel
	{
		public Label Label;

		public Speed()
		{
			Label = Add.Label( "100", "value" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;

			var maxSpeed = Math.Max( Math.Abs( player.Velocity.x ), Math.Abs( player.Velocity.y ) );

			Label.Text = $"{maxSpeed.FloorToInt()}";
		}
	}
}
