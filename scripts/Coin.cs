using Godot;

public partial class Coin : Area2D
{
	public void _on_body_entered(Node2D body)
	{
		var gameManager = GetNode<GameManager>("%GameManager");
		var audioStreamPlayer = GetNode<AudioStreamPlayer2D>("PickupSound");
		var collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");

		collisionShape.QueueFree();
		Visible = false;

		audioStreamPlayer.Play();
		gameManager.AddPoint();
	}

	public void _on_pickup_sound_finished(){
		QueueFree();
	}
}
