using Godot;

public partial class Coin : Area2D
{
	public void _on_body_entered(Node2D body)
	{
		GameManager gameManager = GetNode<GameManager>("%GameManager");

		gameManager.AddPoint();
		QueueFree();
	}
}
