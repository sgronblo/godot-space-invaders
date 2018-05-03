using Godot;
using System;

public class Player : Area2D
{
	private Vector2 screenSize;

	[Export]
	public int Speed = 0;

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

        Position = new Vector2(
            Mathf.Clamp(Position.x, 0, screenSize.x),
            Position.y
        );
    }
}

//public override void _Process(float delta)
//{
//    var velocity = new Vector2();
//    if (Input.IsActionPressed("ui_right")) {
//        velocity.x += 1;
//    }
//
//    if (Input.IsActionPressed("ui_left")) {
//        velocity.x -= 1;
//    }
//
//    if (Input.IsActionPressed("ui_down")) {
//        velocity.y += 1;
//    }
//
//    if (Input.IsActionPressed("ui_up")) {
//        velocity.y -= 1;
//    }
//
//    var animatedSprite = (AnimatedSprite) GetNode("AnimatedSprite");
//    if (velocity.Length() > 0) {
//        velocity = velocity.Normalized() * Speed;
//        animatedSprite.Play();
//    } else {
//        animatedSprite.Stop();
//    }
//}