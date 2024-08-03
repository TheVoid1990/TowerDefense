using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
	public partial class BasicEnemy : Node3D
	{
		public int index = 0;
		public EnemyManager EnemyManager;
		public override void _Ready()
		{
			EnemyManager = GetNode<EnemyManager>("/root/EnemyManager");

		}

		public override void _Process(double delta)
		{
			// Move the enemy along the path at a constant speed
			if (index < EnemyManager.Paths.Count)
			{
				var target = EnemyManager.Paths[index];
				var direction = (target - GlobalTransform.Origin).Normalized();
				var speed = 5;
				GlobalTransform = GlobalTransform.Translated(direction * speed * (float)delta);

				if (GlobalTransform.Origin.DistanceTo(target) < 0.1)
				{
					index++;
				}
			}


		}
	}
}
