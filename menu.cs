using Godot;
using System;

public class menu : Node2D
{
	public static string title;
	private Label label;
	
	public override void _Ready()
	{
		label = (Label)GetNode("Panel/Label");
	}


	public override void _Process(float delta)
	{
		label.Text = title;
	}

	private void _on_Button_button_up()
	{
		this.Visible = false;
	}


}
