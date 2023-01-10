namespace Engine.Sprites
{
	public class EnemyClass : GameEngineBehaviour
	{
		public List<EnemySpawnSprite> SpritePlaceholder = new List<EnemySpawnSprite>();

		public void EnemySpawn(EnemyType EnemyType)
		{

			EnemySpawnSprite Spawn = new()
			{
				Type = EnemyType.Type,
				Image = EnemyType.Image
			};

			#if DEBUG
				Spawn.ShowHitbox = true;
			#endif

			Axis enemyAxis = EnemyPosGen();

			Canvas.SetLeft(Spawn, enemyAxis.AxisX);
			Canvas.SetTop(Spawn, enemyAxis.AxisY);

			if (Canvas.GetLeft(Spawn) < Canvas.GetLeft(BaseTower))
				Spawn.IsRight = true;

			SpritePlaceholder.Add(Spawn);
			MainCanvas.Children.Add(Spawn);

			StoryboardStart(Spawn, TimeSpan.FromMilliseconds(EnemyType.Speed));
		}

		private Axis EnemyPosGen()
		{
			int AxisX, AxisY;
			int SpawnPoint = random.Next(0, 100);	                // Does a random roll whether
																	// it should spawn at Top and Bottom
																	// or Left and Right

			if (SpawnPoint <= 50)					
			{														//  spawn on sides //
				AxisX = random.Next(0, 100);						// ->           <- //
				if (AxisX <= 50) AxisX = -100;                      // ->			<- //
				else AxisX = Game_W + 100;                          // ->			<- //
																	// ->			<- //
				AxisY = random.Next(-100, Game_H + 100);            // ->			<- //
			}														/////////////////////
			else
			{
				AxisX = random.Next(-100, Game_W + 100);			//  spawn top&bot  //
																	// \/ \/ \/ \/ \/ \//
				AxisY = random.Next(0, 100);                        //                 //
				if (AxisY <= 50) AxisY = -100;                      //				   //
				else AxisY = Game_H + 100;                          // /\ /\ /\ /\ /\ ///
			}														/////////////////////

			return new()
			{
				AxisX = AxisX,
				AxisY = AxisY
			};
		}
	}

}
