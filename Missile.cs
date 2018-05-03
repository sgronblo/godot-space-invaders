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

        if (Position.y < -10) {
            QueueFree();
        }
    }

    private void _on_Missile_area_entered(Area2D area)
    {
        if (area.IsInGroup("Enemy"))
        {
            area.QueueFree();
            QueueFree();
        }
    }
}