using Godot;

public partial class SlimeEnemy : Node2D
{
	public const float Speed = 60.0f;
	public int Direction = 1;

	public override void _Process(double delta)
	{
		var rayCastRight = GetNode<RayCast2D>("RayCastRight");
		var rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (rayCastRight.IsColliding()) 
		{
			Direction = -1;
			animatedSprite.FlipH = true;
		}
		else if (rayCastLeft.IsColliding())
		{
			Direction = 1;
			animatedSprite.FlipH = false;
		}

		var newPositionX =  (float)(Position.X + (Direction * (Speed * delta)));
		Position = new Vector2(newPositionX, Position.Y);
	}
}
