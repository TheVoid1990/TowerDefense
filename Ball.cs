using Godot;
using System;

public partial class Ball : CharacterBody3D
{
	public const float SPEED = 10.0f;
	const float JUMP_FORCE = 10.0f;

	Variant gravity = ProjectSettings.GetSetting("physics/3d/default_gravity");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void _PhysicsProcess(float delta)
	{
		if(!IsOnFloor())
		{
			Velocity = new Vector3(Velocity.X, Velocity.Y - (float)gravity * delta, Velocity.Z);
		}


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			Velocity = new Vector3(Velocity.X, JUMP_FORCE, Velocity.Z);
		}

		var inputdirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		var direction = (Transform.Basis * new Vector3(inputdirection.X, 0, inputdirection.Y)).Normalized();

		Velocity = direction * SPEED;

		// Move the ball
		MoveAndSlide();
	}
}
