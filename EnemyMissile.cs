using Godot;
using System;

public class EnemyMissile : Area2D
{
    private Vector2 screenSize;

    public override void _Ready()
    {
        screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        Position += new Vector2(0, 400 * delta);

        if (Position.y > screenSize.y)
        {
            QueueFree();
        }
    }

    private void _on_EnemyMissile_area_entered(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            area.QueueFree();
            QueueFree();
        }
    }
}
