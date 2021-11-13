using System;
using Sandbox;

namespace sonic
{
	public class SpeedyCamera : Camera
	{
		[ConVar.Replicated]
		public static bool thirdperson_collision { get; set; } = true;

		public override void Update()
		{
			var pawn = Local.Pawn as AnimEntity;
			var client = Local.Client;

			if ( pawn == null )
				return;


			Position = pawn.Position;
			Vector3 targetPos;

			var center = pawn.Position + Vector3.Up * 64;

			Position = center;
			Rotation = Rotation.FromAxis( Vector3.Up, 4 ) * Input.Rotation;

			float distance = 100.0f * pawn.Scale;
			targetPos = Position; //+ Input.Rotation.Right * (pawn.CollisionBounds.Maxs.x * pawn.Scale);
			targetPos += Input.Rotation.Forward * -distance;

			if ( thirdperson_collision )
			{
				var tr = Trace.Ray( Position, targetPos )
					.Ignore( pawn )
					.Radius( 8 )
					.Run();

				Position = tr.EndPos;
			}
			else
			{
				Position = targetPos;
			}

			FieldOfView = 120;

			Viewer = null;
		}
	}
}
