using Godot;
using System;

enum Direction
{
    Right = 1,
    Left = -1
}

public class Enemy : Area2D
{
    public const int MARGIN = 100;
    [Export]
    public PackedScene Missile;

    private float time = 0;
    private Direction direction = Direction.Right;
	private Vector2 screenSize;

    public override void _Ready()
    {
		screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        if (Position.x > screenSize.x - MARGIN) {
            direction = Direction.Left;
        } else if (Position.x < MARGIN) {
            direction = Direction.Right;
        }

        var movement = new Vector2((int) direction * MARGIN * delta, 0);
        Position += movement;

        time += delta;
        if (time > 1)
        {
            time = 0;
            Fire();
        }
    }

    private void Fire()
    {
        var missile = (Area2D)Missile.Instance();
        missile.Position = Position;
        GetParent().AddChild(missile);
    }

    private void _on_Enemy_area_entered(Area2D area)
    {

    }
}
