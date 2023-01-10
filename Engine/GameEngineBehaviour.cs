global using System;
global using System.Linq;
global using System.Windows;
global using System.Numerics;
global using System.Diagnostics;
global using System.Windows.Media;
global using System.Windows.Shapes;
global using System.Windows.Controls;
global using System.Windows.Threading;
global using System.Collections.Generic;
global using System.Windows.Media.Imaging;
global using System.Windows.Media.Animation;

global using Engine.Damage;
global using Engine.Sprites;
global using Engine.Enemies.Instance;
global using static Resources.Properties.Resources;

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

		#region Variables
		public static double BaseX, BaseY;
		public static int Game_H, Game_W;
		public EnemyClass Enemy;
		public PlayerClass Player;
		public Rect Base;

		public static double MusicVolume = 0.5;
		public static double SoundEffectsVolume = 0.5;

		public int Killed = 0;
		public int GotAway = 0;
		#endregion

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

			DoubleAnimation EnemyX = new() { To = X, Duration = Speed };
			DoubleAnimation EnemyY = new() { To = Y, Duration = Speed };

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



	//////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////
	public sealed class Axis
	{
		public double AxisX { get; set; }
		public double AxisY { get; set; }
	}

	/// <summary>
	/// Enemy Type Instance
	/// </summary>
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
		//public static double HealthIncrease { get { return 0.5; } }


		public static EnemyType Astolfo = new EnemyType()
		{
			Type = EnemyTypeEnum.Astolfo,
			Image = new BitmapImage(new Uri(AstolfoImage)),
			Health = 999,
			Speed = 5000
		};

		public static EnemyType Slime = new EnemyType()
		{
			Type = EnemyTypeEnum.Slime,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 10,
			Speed = 10000
		};

		public static EnemyType Skeleton = new EnemyType()
		{
			Type = EnemyTypeEnum.Skeleton,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 25,
			Speed = 10000
		};

		public static EnemyType GibyBoby = new EnemyType()
		{
			Type = EnemyTypeEnum.GibyBoby,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType Cappage = new EnemyType()
		{
			Type = EnemyTypeEnum.Cappage,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType ClayGas = new EnemyType()
		{
			Type = EnemyTypeEnum.ClayGas,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 30,
			Speed = 8500
		};

		public static EnemyType RockyBoi = new EnemyType()
		{
			Type = EnemyTypeEnum.RockyBoi,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 50,
			Speed = 13000
		};

		public static EnemyType WhiteAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.WhiteAnomaly,
			Image = new BitmapImage(new Uri(WhiteAnomalyImage)),
			Health = 80,
			Speed = 8000
		};

		public static EnemyType BlueAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.BlueAnomaly,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 150,
			Speed = 15000
		};

		public static EnemyType RedAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.RedAnomaly,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 195,
			Speed = 10000
		};

		public static EnemyType BlackAnomaly = new EnemyType()
		{
			Type = EnemyTypeEnum.BlackAnomaly,
			Image = new BitmapImage(new Uri(SlimeImage)),
			Health = 300,
			Speed = 20000
		};
	}

	/// <summary>
	/// Enemy Type Enumeration
	/// </summary>
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

	/// <summary>
	/// Damage Type Enumeration
	/// </summary>
	public enum DamageTypeEnum
	{ 
		Normal,
		Critical,
		Delete
	}
}
