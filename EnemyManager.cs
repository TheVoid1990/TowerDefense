using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TowerDefense
{
	public partial class EnemyManager : Node3D
	{
		Enemy enemy;
		public List<Vector3> Paths = new List<Vector3>();
		public List<BasicEnemy> BasicEnemies = new List<BasicEnemy>();
		public float increment = 2.0f;
		public float incrementValues = 0.0f;
		public override void _Ready()
		{
			for(int i = 0; i < 10; i++)
			{
				enemy = GD.Load<PackedScene>("res://Enemy.tscn").Instantiate() as Enemy;
				AddChild(enemy);
				enemy.Position = new Vector3(150, 0, 0);
				enemy.StartWaitTime = (float)i * 1.0f;
				enemy.Paths.AddRange( new List<Vector3>()
				{
					new Vector3(0,10,10),
					new Vector3(50,10,10),
					new Vector3(100,10,10),
					new Vector3(150,10,20),
					new Vector3(200,10,30),
					new Vector3(250,10,40),
					new Vector3(200,10,50),
					new Vector3(150,10,60),
					new Vector3(100,10,70),
					new Vector3(50,10,80),
					new Vector3(0,10,90)
				});
			}
			//BasicEnemies.Add((BasicEnemy)enemy);
			//BasicEnemies[0].Position = new Vector3(500, 0, 0);

		}

		public override void _Process(double delta)
		{
			
			//foreach (var enemy in BasicEnemies)
			//{
				//// move enemy positions in the x axis
				//// use delta to normalize movement
				//incrementValues += increment;
				//enemy.Position = new Vector3(enemy.Position.X + incrementValues, 25, enemy.Position.Z);
			//}
			//MoveAndSlide();
		


		}
		
		public override void _PhysicsProcess(double delta)
		{
			//var _targetVelocity.X = direction.X * Speed;
			//
			//// Moving the character
			//Velocity = _targetVelocity;
			//MoveAndSlide();
		}
	}
}
