using Sandbox;

public sealed class GameManager : Component
{
	public int level = 0;
	[Property] public GameObject level1, level2, level3, level4, level5;

	private GameObject levelInstance;
	protected override void OnStart()
	{
		NewLevel();
	}
	public void NewLevel()
	{
		level++;
		if ( levelInstance != null )
		{
			levelInstance.Destroy();
		}

		GameObject prefab = null;

		switch ( level )
		{
			case 1:
				prefab = level1;
				break;
			case 2:
				prefab = level2;
				break;
			case 3:
				prefab = level3;
				break;
			case 4:
				prefab = level4;
				break;
			case 5:
				prefab = level5;
				break;
			case 6:
				level = 1;
				prefab = level1;
				Sandbox.Services.Achievements.Unlock("win_the_puzzle");
				Log.Info( "Achievement" );
				break;
			default:
				level = 1;
				prefab = level1;
				break;
		}
		levelInstance = prefab.Clone();
	}

	public void Restart()
	{
		if ( levelInstance != null )
		{
			levelInstance.Destroy();
		}

		GameObject prefab = null;

		switch ( level )
		{
			case 1:
				prefab = level1;
				break;
			case 2:
				prefab = level2;
				break;
			case 3:
				prefab = level3;
				break;
			case 4:
				prefab = level4;
				break;
			case 5:
				prefab = level5;
				break;
			default:
				level = 1;
				prefab = level1;
				break;
		}
		levelInstance = prefab.Clone();
	}
}
