using Godot;

public partial class Killzone : Area2D
{    
    public void _on_body_entered(Node2D body)
    {
        var timer =  GetNode<Timer>("Timer");

        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        Engine.TimeScale = 0.5;
        timer.Start();
    }

    public void _on_timer_timeout()
    {
        Engine.TimeScale = 1;
        GetTree().ReloadCurrentScene();
    }
}
