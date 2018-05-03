using Godot;
using System;

public class Missile : Area2D
{
	private Vector2 screenSize;

    public override void _Ready()
    {
		screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        Position -= new Vector2(0, 400 * delta);

        GD.Print(Position.ToString());
        if (Position.y < -10) {
            QueueFree();
        }
    }

}
