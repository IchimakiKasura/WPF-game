namespace Engine
{
	public partial class GameEngine : GameEngineBehaviour
	{

		public GameEngine()
		{
			BaseX = Canvas.GetLeft(BaseTower);
			BaseY = Canvas.GetTop(BaseTower);

			Enemy = new EnemyClass();
			Player = new PlayerClass();

			Base = new Rect(BaseX, BaseY, BaseTower.Width, BaseTower.Height);

			CompositionTarget.Rendering += Update;
		}

		void Update(object s, EventArgs e)
		{
			foreach (var Instance in Enemy.SpritePlaceholder.ToList())
			{
				double X = Canvas.GetLeft(Instance) + Canvas.GetLeft(Instance.HitBox);
				double Y = Canvas.GetTop(Instance) + Canvas.GetTop(Instance.HitBox);
				Rect HitBox = new(X, Y, Instance.HitBox.Width, Instance.HitBox.Height);

				// Movement
				// Vector2 Start = new() { X = (float)X, Y = (float)Y };
				// Vector2 End = new() { X = (float)BaseX, Y = (float)BaseY };
				// Vector2 CurrentPOS = calculatePosition(ref Start, ref End, Instance.I);

				// if(!Instance.TargetHitted)
				// {
				// 	Canvas.SetLeft(Instance, CurrentPOS.X);
				// 	Canvas.SetTop(Instance, CurrentPOS.Y);

				// 	Console.WriteLine(CurrentPOS);
				// }

				// Collision 
				foreach (var InstanceType in (EnemyTypeEnum[])Enum.GetValues(typeof(EnemyTypeEnum)))
				{
					if (Instance.Type == InstanceType && 
						Instance.Type != EnemyTypeEnum.Dead) Collision(Instance, HitBox);
				}
			}
		}

		// Screen
		private void Screen()
		{

		}

		// On-Hit collision       
		private void Collision(EnemySpawnSprite Instance, Rect HitBox)
		{
			if (Base.IntersectsWith(HitBox))
			{
				Instance.TargetHitted = true;
				StoryboardStop(Instance);
			}

			if (CurrentMouse.IntersectsWith(HitBox))
			{
				HitInstance Hit = new(Instance)
				{
					Text = "999999999999",
					DamageType = DamageTypeEnum.Delete
				};

				MainCanvas.Children.Add(Hit);

				DispatcherTimer dispatcherTimer = new() { Interval = TimeSpan.FromSeconds(1) };
				dispatcherTimer.Tick += delegate {
					MainCanvas.Children.Remove(Hit);
					Enemy.SpritePlaceholder.Remove(Instance);
					MainCanvas.Children.Remove(Instance);
				};

				dispatcherTimer.Start();

				Instance.Opacity = 0;
				Instance.Type = EnemyTypeEnum.Dead;
				Instance.mediaPlayer.Play();

				Killed++;
			}

			Gotaway.Content = "Got Away: " + GotAway;
			kills.Content = "Killed: " + Killed;
		}

		// Enemy vector Path
		static Vector2 calculatePosition(ref Vector2 start_pos, ref Vector2 end_pos, float time)
		{
			Vector2 mov_vec = Vector2.Subtract(end_pos, start_pos);

			Vector2 norm_mov_vec = Vector2.Normalize(mov_vec);

			Vector2 delta_vec = norm_mov_vec * time;

			return Vector2.Add(start_pos, delta_vec);
		}

		private void Wait()
		{

		}
	}
}
