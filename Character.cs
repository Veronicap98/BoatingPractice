using Godot;
using System;

public class Character : RigidBody2D
{
	
	[Export]
	public int Speed = 150;
	public Sprite character;
	public CollisionShape2D collision;
	public Node2D MenuScreen;
	
	public override void _Ready()
	{
		character = (Sprite)GetNode("Sprite");
		collision = (CollisionShape2D)GetNode("CollisionShape2D");
		MenuScreen = (Node2D)GetNode("Menu");
	}

	public override void _PhysicsProcess(float delta)
	{
		menu.title = "You are not moving";

		if (Input.IsActionPressed("moveleft"))
		{
			this.Position -= new Vector2(Speed, 0) * delta; 
			character.FlipH = true;
			character.RotationDegrees = 0;
			collision.RotationDegrees = 0;
			menu.title = "You are moving left";
		}

		if (Input.IsActionPressed("moveright"))
		{
			this.Position += new Vector2(Speed, 0) * delta;
			character.FlipH = false;
			character.RotationDegrees = 0;
			collision.RotationDegrees = 0;
			menu.title = "You are moving right";
		}

		if (Input.IsActionPressed("moveup"))
		{
			this.Position -= new Vector2(0, Speed) * delta;
			menu.title = "You are moving up";

			if (character.FlipH == true) 
			{
				character.RotationDegrees = 90;
				collision.RotationDegrees = 90;
			}
			else 
			{
				character.RotationDegrees = -90;
				collision.RotationDegrees = -90;
			}
		}

		if (Input.IsActionPressed("movedown"))
		{
			this.Position += new Vector2(0, Speed) * delta;
			menu.title = "You are moving down";

			if (character.FlipH == true)
			{
				character.RotationDegrees = -90;
				collision.RotationDegrees = -90;
			}
			else 
			{
				character.RotationDegrees = 90;
				collision.RotationDegrees = 90;
			}
		}

		if ((Input.IsActionPressed("movedown")) && (Input.IsActionPressed("moveright")))
		{
			character.RotationDegrees = 45;
			collision.RotationDegrees = 45;
		}

		if ((Input.IsActionPressed("moveup")) && (Input.IsActionPressed("moveright")))
		{
			character.RotationDegrees = -45;
			collision.RotationDegrees = -45;
		}

		if ((Input.IsActionPressed("movedown")) && (Input.IsActionPressed("moveleft")))
		{
			character.RotationDegrees = -45;
			collision.RotationDegrees = -45;
		}

		if ((Input.IsActionPressed("moveup")) && (Input.IsActionPressed("moveleft")))
		{
			character.RotationDegrees = 45;
			collision.RotationDegrees = 45;
		}

		var Velocity = Vector2.Zero;
		if (Velocity.Length() > 0) Velocity = Velocity.Normalized() * Speed * delta;

		if (Input.IsActionPressed("inspect")) MenuScreen.Visible = true;
	}
}
