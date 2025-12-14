using Sandbox;

public sealed class UniversalBlock : Component, Component.ITriggerListener
{
	[Property] Rigidbody rb;
	[Property] float speed = 100;
	[Property] bool isVertical, isPlayer;
	protected override void OnUpdate()
	{
		if (isVertical)
		{
			if ( Input.Down( "Forward" ) )
			{
				rb.Velocity = new Vector3( rb.Velocity.x, rb.Velocity.y + speed, rb.Velocity.z );
			}
			if ( Input.Down( "Backward" ) )
			{
				rb.Velocity = new Vector3( rb.Velocity.x, rb.Velocity.y - speed, rb.Velocity.z );
			}
			rb.Velocity = new Vector3( rb.Velocity.x / 2, rb.Velocity.y, rb.Velocity.z );
		}
		else
		{
			if ( Input.Down( "Right" ) )
			{
				rb.Velocity = new Vector3( rb.Velocity.x + speed, rb.Velocity.y, rb.Velocity.z );
			}
			if ( Input.Down( "Left" ) )
			{
				rb.Velocity = new Vector3( rb.Velocity.x - speed, rb.Velocity.y, rb.Velocity.z );
			}
			rb.Velocity = new Vector3( rb.Velocity.x, rb.Velocity.y / 2, rb.Velocity.z );
		}

		if (isPlayer)
		{
			if (Input.Released("Restart"))
			{
				var GameManagers = Scene.GetAllComponents<GameManager>();

				foreach ( var go in GameManagers )
				{
					go.Restart();
				}
			}
		}
	}

	public void OnTriggerEnter( Collider other )
	{
		if (isPlayer)
		{
			if ( other.GameObject.Tags.Has( "Finish" ) )
			{
				var GameManagers = Scene.GetAllComponents<GameManager>();

				foreach ( var go in GameManagers )
				{
					go.NewLevel();
				}
			}
			else
			{
				//hohma
			}
		}
	}
}
