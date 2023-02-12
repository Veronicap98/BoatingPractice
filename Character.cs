using Godot;
using System;

public class Character : RigidBody2D
{
	
	[Export]
	public int Speed = 150;
	public Sprite character;
	public override void _Ready()
	{
		character = (Sprite)GetNode("Sprite");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("moveleft"))
		{
			this.Position -= new Vector2(Speed, 0) * delta; 
			character.FlipH = true;
			character.RotationDegrees = 0;
		}

		if (Input.IsActionPressed("moveright"))
		{
			this.Position += new Vector2(Speed, 0) * delta;
			character.FlipH = false;
			character.RotationDegrees = 0;
		}

		if (Input.IsActionPressed("moveup"))
		{
			this.Position -= new Vector2(0, Speed) * delta;
			if (character.FlipH == true) character.RotationDegrees = 90;
			else character.RotationDegrees = -90;
		}

		if (Input.IsActionPressed("movedown"))
		{
			this.Position += new Vector2(0, Speed) * delta;
			if (character.FlipH == true) character.RotationDegrees = -90;
			else character.RotationDegrees = 90;
		}

		if ((Input.IsActionPressed("movedown")) && (Input.IsActionPressed("moveright")))
		{
			character.RotationDegrees = 45;
		}

		if ((Input.IsActionPressed("moveup")) && (Input.IsActionPressed("moveright")))
		{
			character.RotationDegrees = -45;
		}

		if ((Input.IsActionPressed("movedown")) && (Input.IsActionPressed("moveleft")))
		{
			character.RotationDegrees = -45;
		}

		if ((Input.IsActionPressed("moveup")) && (Input.IsActionPressed("moveleft")))
		{
			character.RotationDegrees = 45;
		}

		var Velocity = Vector2.Zero;
		if (Velocity.Length() > 0) Velocity = Velocity.Normalized() * Speed * delta;
	}
}
