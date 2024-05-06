using Godot;
using System;

public partial class Camera3D : Godot.Camera3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	[Export] public double Speed = 40;
	[Export] public float RotationSpeed = 0.05f;
	public Camera2D camera = new Camera2D();

	public override void _Process(double delta)
	{
		// Get input from arrow keys or WASD keys
		Vector3 direction = new Vector3();

		if (Input.IsActionPressed("ui_right"))
		{
			direction.X += 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1;
		}

		if (Input.IsActionPressed("ui_down"))
		{
			direction.Z += 1;
		}

		if (Input.IsActionPressed("ui_up"))
		{
			direction.Z -= 1;
		}

		if (Input.IsActionPressed("rotate_left"))
		{
			RotateY(RotationSpeed);  // Rotate left around the Y-axis
		}

		if (Input.IsActionPressed("rotate_right"))
		{
			RotateY(-RotationSpeed);  // Rotate right around the Y-axis
		}

		// Normalize direction to ensure consistent movement speed diagonally
		direction = direction.Normalized();

		// Move the camera
		Translate(direction);
	}
}
