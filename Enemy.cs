using Godot;
using System;

public class Enemy : Area2D
{
    [Export]
    public PackedScene Missile;

    private float time = 0;

    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
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
