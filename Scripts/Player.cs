using Godot;
using System;

public class Player : Area2D
{
	private Vector2 screenSize;

	[Export]
	public int Speed = 0;

    [Export]
    public PackedScene Missile;

    public override void _Ready()
    {
		screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_right")) {
            Position += new Vector2(Speed * delta, 0);
        }
        if (Input.IsActionPressed("ui_left")) {
            Position -= new Vector2(Speed * delta, 0);
        }

        if (Input.IsActionJustPressed("action_fire")) {
            var missile =  (Area2D) Missile.Instance();
            missile.Position = Position;
            GetParent().AddChild(missile);
        }

        Position = new Vector2(
            Mathf.Clamp(Position.x, 0, screenSize.x),
            Position.y
        );
    }
}
