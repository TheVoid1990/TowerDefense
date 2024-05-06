using Godot;
using System;

public partial class LevelGenerator : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var levelPiece = GD.Load<PackedScene>("res://GLTFs/RollingLogStraight.glb").Instantiate();

		for (int i = 0; i < 10; i++)
		{
			AddChild(levelPiece);
		}



	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
