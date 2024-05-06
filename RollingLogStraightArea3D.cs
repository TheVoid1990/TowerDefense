using Godot;
using System;

public partial class RollingLogStraightArea3D : Area3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _InputEvent(Godot.Camera3D camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx)
	{
		if (@event is not InputEventMouseButton) return;

		InputEventMouseButton mouseEvent = @event as InputEventMouseButton;
		bool leftMousePressed = mouseEvent.ButtonIndex == MouseButton.Left;

		if (leftMousePressed && mouseEvent.Pressed)
		{
			GD.Print("Area clicked: ");
			GD.Print("Instance ID: " + this.GetInstanceId());

			// Check if a player already exists
			Node potentialExistingPlayer = GetParent().GetNodeOrNull("WoodCutters"); // Ensure 'Player' is the node name in your scene tree
			if (potentialExistingPlayer == null)
			{
				// Instantiate player if not already present
				Node3D levelPiece = GD.Load<PackedScene>("res://WoodCutters.tscn").Instantiate() as Node3D;
				GetParent().AddChild(levelPiece);

				//Node playerInstance = playerScene.Instance();
				//GetParent().AddChild(playerInstance);
				//playerInstance.SetName("Player");  // Optionally set the name to easily find it later

				// If you want to set the position where the mouse was clicked
				// Assuming area has a global transform or similar property to position correctly

				//levelPiece.Position = this.GlobalPosition;
				levelPiece.Position = new Vector3(0, 4, 0);

			}
			else
			{
				GD.Print("Player already exists!");
			}
		}

	}

	public override void _Input(InputEvent @event)
	{

		// Add further click handling logic here
	}
}

//private void OnAreaInputEvent(Viewport viewport, InputEvent @event, int shapeIdx, Area3D area)
//{

//}

	//public override void _MouseEnter()
	//{
	//	base._MouseEnter();
	//	GD.Print("Mouse entered the area");

	//	// if mouse clicked print to console
	//	if (Input.IsMouseButtonPressed(MouseButton.Left))
	//	{
	//		GD.Print("Mouse clicked the area");
	//	}


	//	GD.Print("Mouse entered the area");

	//}
//}
