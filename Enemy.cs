using Godot;
using System;

public class Enemy : Area2D
{
    [Export]
    public PackedScene Missile;

    public override void _Ready()
    {

    }

   public override void _Process(float delta)
   {

   }

    private void _on_Enemy_area_entered(Area2D area)
    {
        GD.Print("HIT!");
        QueueFree();
        area.QueueFree();
    }
}
