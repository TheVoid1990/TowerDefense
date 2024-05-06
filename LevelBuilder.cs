using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using TowerDefense;

public partial class LevelBuilder : Node3D
{

	private InputEventMouseButton previousMouseEvent = null;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TileContainer container;
		XmlSerializer serializer = new XmlSerializer(typeof(TileContainer));


		//List<int> cardinalDirectionSet = new List<int> { 1, 2, 4, 8 };
		List<int> cardinalDirectionSet = new List<int> { 7,11,13,14 };
		using (StreamReader fileReader = new StreamReader(@"Map for MapGenerator.xml"))
		{
			container = (TileContainer)serializer.Deserialize(fileReader);
		}

		for(int y = 0; y < container.Rows.Count; y++)
		{
			for(int x = 0; x < container.Rows[y].Tiles.Count; x++)
			{
				TowerDefense.TileData tile = container.Rows[y].Tiles[x];
				GD.Print("Tile at: " + x + ", " + y + " is: " + tile.Type);
				
				if(!cardinalDirectionSet.Contains(tile.Id)) continue;
				//if(tile.Id != 0) continue;

				Node3D levelPiece = GD.Load<PackedScene>("res://RollingLogStraight.tscn").Instantiate() as Node3D;
				AddChild(levelPiece);
				levelPiece.Position = new Vector3(x * 4, 0, y * 4);

				switch (tile.Id)
				{
					case 1:
						break;
					case 7:
						levelPiece.Rotation = new Vector3(0, (Mathf.Pi / 2) * 3, 0);
						break;
					case 11:
						levelPiece.Rotation = new Vector3(0, (Mathf.Pi / 2), 0);
						break;
					case 13:
						levelPiece.Rotation = new Vector3(0, Mathf.Pi, 0);
						break;
					case 14:
						levelPiece.Rotation = new Vector3(0, 0, 0);
						break;
						//case 4:
						//	levelPiece.Rotation = new Vector3(0, Mathf.Pi /2, 0);
						//	break;
						//case 8:
						//	levelPiece.Rotation = new Vector3(0, (Mathf.Pi / 2) * 3, 0);
						//	break;
				}

			}
		}
	}

	private void OnAreaInputEvent(Viewport viewport, InputEvent @event, int shapeIdx, Area3D area)
	{
		if (@event is not InputEventMouseButton) { return; }
		InputEventMouseButton mouseEvent = @event as InputEventMouseButton;
		bool leftMousePressed = mouseEvent.ButtonIndex == MouseButton.Left;

		if (leftMousePressed && mouseEvent.Pressed)
		{
			GD.Print("Area clicked: ", area.Name);

		}
	}

	private void OnAreaMouseExited()
	{
		GD.Print("Mouse exited the area");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		;
	}
}
