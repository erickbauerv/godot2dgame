using Godot;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -260.0f;

	public override void _PhysicsProcess(double delta)
	{
		AnimatedSprite2D animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		if (direction != Vector2.Zero)
		{
			animatedSprite.FlipH = direction.X == -1;
			animatedSprite.Play(IsOnFloor() ? "run" : "jump");
			velocity.X = direction.X * Speed;
		}
		else
		{
			animatedSprite.Play(IsOnFloor() ? "idle" : "jump");
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
