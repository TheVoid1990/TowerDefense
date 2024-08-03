using Godot;
using System;
using System.Collections.Generic;
public partial class Enemy : CharacterBody3D
{
	public List<Vector3> Paths = new List<Vector3>();
	public const float Speed = 25.0f;
	public const float JumpVelocity = 4.5f;
	public int PathIndex = 0;
	
	public float StartWaitTime = 0.0f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _Ready()
	{
		//Paths.Add(new Vector3(0,0,0));
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			//velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		//Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		//Vector3 direction = (Transform.Basis * new Vector3(1, 0, 1)).Normalized();
		//Vector3 direction1 = 
		//if (direction != Vector3.Zero)
		//{
			//velocity.X = direction.X * Speed;
			//velocity.Z = direction.Z * Speed;
		//}
		//else
		//{
			//velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			//velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		//}
		
		Velocity = Position.DirectionTo(Paths[PathIndex]) * Speed;
		// LookAt(_target);
		if(StartWaitTime > 0)
		{
			StartWaitTime -= (float)delta;	
			GD.Print("Start Wait Time: ", StartWaitTime);
		}
		else if (Position.DistanceTo(Paths[PathIndex]) > 5)
		{
			MoveAndSlide();
		}
		else
		{
			PathIndex++;
		}

		//Velocity = velocity;
		//MoveAndSlide();
	}
}
