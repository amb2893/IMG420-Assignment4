using Godot;

public partial class Pickup : Area2D
{

	private GpuParticles2D _particles;
	private Label _winLabel;

	public override void _Ready()
	{
		_particles = GetNode<GpuParticles2D>("GPUParticles2D");
		if (_particles != null)
		{
			_particles.Emitting = false;
			
		}
	   _winLabel = GetNodeOrNull<Label>("Label");
		if (_winLabel != null)
			_winLabel.Hide();
			
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			GD.Print("Pickup collected by player!");


			// Play particles
			if (_particles != null)
				_particles.Emitting = true;

			// Pause the game

			// Hide pickup and disable collisions
			_winLabel.Visible = true;
			SetDeferred("CollisionLayer", 0);
			SetDeferred("CollisionMask", 0);
			GetTree().Paused = true;

			// Queue free after particle lifetime
			GetTree().CreateTimer(4.0, false).Timeout += () =>
			{
				GetTree().Paused = false; // resume game
				QueueFree();
			};
		}
	}
}
