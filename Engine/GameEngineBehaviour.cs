using Engine.Enemies.Instance;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Engine
{
	public class GameEngineBehaviour
	{
		/// <summary>
		/// Random idk
		/// </summary>
		public static Random random = new Random();

		/// <summary>
		/// Screen Size
		/// </summary>
		public enum ScreenSize { x720, x768, x900, x1080, x1440 }

		#region MainWindow Collections
		public static Canvas MainCanvas;
		public static Rectangle BaseTower;
		public static Ellipse ellipse;
		public static Label kills;
		public static Label Gotaway;
		public static Rect CurrentMouse;
		#endregion

		#region Storyboard Algo/shortcuts
		public static void StoryboardStart(EnemySpawnSprite Target, Duration Speed)
		{
			Storyboard anim = SetStoryBoard(GameEngine.BaseX,
											GameEngine.BaseY,
											Target,
											Speed);
			Target.storyboard = anim;
			Target.storyboard.Begin();
		}

		public static void StoryboardStop(EnemySpawnSprite Target)
		{
			var X = Canvas.GetLeft(Target);
			var Y = Canvas.GetTop(Target);
			Target.storyboard.Stop();
			Canvas.SetLeft(Target, X);
			Canvas.SetTop(Target, Y);
		}

		public static void StoryboardSlow(EnemySpawnSprite Target)
		{

		}

		private static Storyboard SetStoryBoard(double X, double Y, EnemySpawnSprite Target, Duration Speed)
		{
			Storyboard Animation = new Storyboard();
			Timeline.SetDesiredFrameRate(Animation, 24);

			DoubleAnimation EnemyX = new DoubleAnimation() { To = X, Duration = Speed };
			DoubleAnimation EnemyY = new DoubleAnimation() { To = Y, Duration = Speed };

			Storyboard.SetTargetProperty(EnemyX, new PropertyPath("(Canvas.Left)"));
			Storyboard.SetTargetProperty(EnemyY, new PropertyPath("(Canvas.Top)"));

			Storyboard.SetTarget(EnemyX, Target);
			Storyboard.SetTarget(EnemyY, Target);

			Animation.Children.Add(EnemyX);
			Animation.Children.Add(EnemyY);

			return Animation;
		}
		#endregion
	}

	// idk i want
	public sealed class CollisionParameters
	{
		public EnemySpawnSprite Instance { get; set; }
		public Rect HitBox { get; set; }
	}

	public sealed class EnemyAxis
	{
		public int AxisX { get; set; }
		public int AxisY { get; set; }
	}

	public sealed class EnemyType
	{
		/// <summary>
		/// Enemy Health
		/// </summary>
		public double Health;

		/// <summary>
		/// Its not really enemies speed. <br/>
		/// its Time it takes before the enemy
		/// hits the base.
		/// It takes MS not Seconds.
		/// </summary>
		public int Speed;

		public EnemyTypeEnum Type;

		public BitmapImage Image;

		/// <summary>
		/// Health multiplication idk 
		/// </summary>
		public static double HealthIncrease { get { return 0.5; } }


		public static EnemyType Astolfo = new EnemyType()
		{
			Type = EnemyTypeEnum.Astolfo,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/Astolfo.png")),
			Health = 999,
			Speed = 5000
		};

		public static EnemyType Slime = new EnemyType()
		{
			Type = EnemyTypeEnum.Slime,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 10,
			Speed = 10000
		};

		public static EnemyType Skeleton = new EnemyType()
		{
			Type = EnemyTypeEnum.Skeleton,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 25,
			Speed = 10000
		};

		public static EnemyType GibyBoby = new EnemyType()
		{
			Type = EnemyTypeEnum.GibyBoby,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType Cappage = new EnemyType()
		{
			Type = EnemyTypeEnum.Cappage,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType ClayGas = new EnemyType()
		{
			Type = EnemyTypeEnum.ClayGas,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType RockyBoi = new EnemyType()
		{
			Type = EnemyTypeEnum.RockyBoi,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 50,
			Speed = 13000
		};

		public static EnemyType WhiteAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.WhiteAnomaly,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/WhiteAnomaly.png")),
			Health = 80,
			Speed = 8000
		};

		public static EnemyType BlueAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.BlueAnomaly,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 150,
			Speed = 15000
		};

		public static EnemyType RedAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.RedAnomaly,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 195,
			Speed = 10000
		};

		public static EnemyType BlackAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.BlackAnomaly,
			Image = new BitmapImage(new Uri("pack://application:,,,/Resources;component/Image/slime.png")),
			Health = 300,
			Speed = 20000
		};
	}

	/// <summary>
	/// Thou shall not see this xD
	/// </summary>
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public enum EnemyTypeEnum
	{
		Astolfo,
		Slime,
		Skeleton,
		GibyBoby,
		Cappage,
		ClayGas,
		RockyBoi,
		WhiteAnomaly,
		BlueAnomaly,
		RedAnomaly,
		BlackAnomaly,
		Dead
	}
}
