using Godot;
using System.Collections.Generic;

public partial class Enemy : CharacterBody2D
{
	[Export] public float Speed = 150f;             // base speed og 100
	[Export] public float SpeedIncrease = 50f;      // amount to increase after each point og 20
	[Export] public NodePath[] PatrolPoints;
 	private NavigationAgent2D _navAgent;
	private AnimatedSprite2D _animatedSprite;
	private List<Vector2> _waypoints = new();
	private int _currentPatrolIndex = 0;

public override void _Ready()
{
	_animatedSprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");

	_navAgent = GetNode<NavigationAgent2D>("NavigationAgent2D");
	// Load patrol points
	foreach (var path in PatrolPoints)
	{
		var point = GetNodeOrNull<Node2D>(path);
		if (point != null)
			_waypoints.Add(point.GlobalPosition);
	}

	if (_waypoints.Count == 0)
		GD.PrintErr("Enemy: No patrol points assigned!");
}


	public override void _PhysicsProcess(double delta)
	{
		if (_waypoints.Count == 0) return;

		Vector2 target = _waypoints[_currentPatrolIndex];
		Vector2 direction = (target - GlobalPosition).Normalized();

		// Move toward the target
		Velocity = direction * Speed;
		MoveAndSlide();


		UpdateAnimation(direction);

		// Check if reached target
		if (GlobalPosition.DistanceTo(target) < 10f)
		{
			_currentPatrolIndex = (_currentPatrolIndex + 1) % _waypoints.Count;

			// Increase speed after each point
			if (Speed < 500)
			{
				Speed += SpeedIncrease;
			}
		}
	}

	private void UpdateAnimation(Vector2 direction)
	{
		if (_animatedSprite == null) return;

		if (direction.Length() > 0.1f)
		{
			_animatedSprite.Play("run");  // or "run"
			_animatedSprite.FlipH = direction.X > 0;
		}

	}
		private void OnPickupCollected()
	{
		GD.Print("Enemy killed by pickup!");
		QueueFree(); // remove enemy
	}
}
