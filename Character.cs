using Godot;
using System;

public class Character : Area2D
{
	
	[Export]
	public int Speed = 100;
	public override void _Ready()
	{
		
	}

	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("moveleft")) this.Position -= new Vector2(Speed, 0) * delta;
		if (Input.IsActionPressed("moveright")) this.Position += new Vector2(Speed, 0)* delta;
		if (Input.IsActionPressed("moveup")) this.Position -= new Vector2(0, Speed) * delta;
		if (Input.IsActionPressed("movedown")) this.Position += new Vector2(0, Speed) * delta;
		var Velocity = Vector2.Zero;
		if (Velocity.Length() > 0) Velocity = Velocity.Normalized() * Speed * delta;
	}
}
