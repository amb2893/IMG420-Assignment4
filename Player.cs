using Godot;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 200f;
	[Export] public float JumpForce = 400f;
	[Export] public float Gravity = 900f;
	[Export] public Vector2 RespawnPosition = new Vector2(46, 283);
	[Export] public float DeathYLimit = 600f;
 	[Signal] public delegate void PlayerDiedEventHandler();
	
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Gravity
		if (!IsOnFloor())
			Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * (float)delta);
		else if (Velocity.Y > 0)
			Velocity = new Vector2(Velocity.X, 0);

		// Horizontal input
		float direction = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		Velocity = new Vector2(direction * Speed, Velocity.Y);

		// Jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			Velocity = new Vector2(Velocity.X, -JumpForce);

		// Move
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			if (collision.GetCollider() is CharacterBody2D)
			{
				GD.Print("Game Over! You’ve been hit by the fly!");
				//GetTree().Paused = true;
				ResetPosition();

			}
		}
		// --- Animation Handling ---
		UpdateAnimation(direction);

		// Check for out-of-bounds
		if (Position.Y > DeathYLimit)
		{
			GD.Print("Game Over, Restarting...");
			ResetPosition();
		}
	}

	private void UpdateAnimation(float direction)
	{
		if (!IsOnFloor())
		{
			// Jump/fall animation
			_animatedSprite.Play("jump");
		}
		else if (Mathf.Abs(direction) > 0)
		{
			// Running animation
			_animatedSprite.Play("run");
		}
		else
		{
			// Idle animation
			_animatedSprite.Play("idle");
		}

		// Flip sprite based on direction
		if (direction != 0)
			_animatedSprite.FlipH = direction < 0;
	}

	private void ResetPosition()
	{
		//if (GetTree() != null)
		//{
		//	GetTree().ReloadCurrentScene();
		//}
		//GetTree().ChangeSceneToFile("res://Main.tscn");
		 EmitSignal(nameof(PlayerDied));
	}
}
