using Sandbox.UI;

namespace sonic.hud
{
	public partial class Hud : Sandbox.HudEntity<RootPanel>
	{
		public Hud()
		{
			if ( IsClient )
			{
				RootPanel.StyleSheet.Load( "/hud/Hud.scss" );

				RootPanel.AddChild<Speed>();
			}
		}
	}
}
