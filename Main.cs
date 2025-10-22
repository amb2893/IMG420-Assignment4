using Godot;

public partial class Main : Node2D
{
	[Export] public PackedScene EnemyScene;
	[Export] public PackedScene PickupScene;

	[Export] public Vector2 EnemySpawnPosition = new Vector2(668, 45); //668 45
	[Export] public Vector2 PickupSpawnPosition = new Vector2(1004, 304);

	private CharacterBody2D _player;
	private Player player;
	public override void _Ready()
	{
		// Get reference to player
		var _player = GetNode<CharacterBody2D>("Player");
		
		var player = GetNode<Player>("Player"); // adjust path
		player = GetNode<Player>("Player");
   	 	player.PlayerDied += OnPlayerDied;

		// Spawn enemy
		if (EnemyScene != null)
		{
			Enemy enemy = (Enemy)EnemyScene.Instantiate();
			AddChild(enemy);
			enemy.GlobalPosition = EnemySpawnPosition;

			// Assign player so enemy can follow
			enemy.Set("PlayerPath", _player.GetPath());
		}

		// Spawn pickup
		if (PickupScene != null)
		{
			Area2D pickup = (Area2D)PickupScene.Instantiate();
			AddChild(pickup);
			pickup.GlobalPosition = PickupSpawnPosition;

			// Optional: connect signal for pickup
			pickup.BodyEntered += OnPickupCollected;
		}
	}

	private void OnPickupCollected(Node body)
	{
		if (body == _player)
		{
			GD.Print("Player collected a pickup!");
		}
	}
	
	private void OnPlayerDied()
	{
	//GD.Print("Player died! Resetting game...");
		GetTree().ReloadCurrentScene();
	}
}
