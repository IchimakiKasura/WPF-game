namespace Engine.Enemies.Instance
{
	/// <summary>
	/// Interaction logic for EnemySpawnSprite.xaml
	/// </summary>
	public partial class EnemySpawnSprite : UserControl
	{
		private static readonly DependencyProperty ScaleXProperty =
			DependencyProperty.Register("ScaleX", typeof(double), typeof(EnemySpawnSprite), new PropertyMetadata((double)1));

		public static readonly DependencyProperty IsRightProperty =
			DependencyProperty.Register("IsRight", typeof(bool), typeof(EnemySpawnSprite));

		public static readonly DependencyProperty TypeProperty =
			DependencyProperty.Register("Type", typeof(EnemyTypeEnum), typeof(EnemySpawnSprite));

		public static readonly DependencyProperty ImageProperty =
			DependencyProperty.Register("Image", typeof(ImageSource), typeof(EnemySpawnSprite));

		public static readonly DependencyProperty ShowHitboxProperty =
			DependencyProperty.Register("ShowHitbox", typeof(bool), typeof(EnemySpawnSprite));

		private double ScaleX
		{
			get { return (double)GetValue(ScaleXProperty); }
			set { SetValue(ScaleXProperty, value); }
		}

		public bool IsRight
		{
			get { return (bool)GetValue(IsRightProperty); }
			set { SetValue(IsRightProperty, value); if (IsRight) ScaleX = -1; }
		}

		public EnemyTypeEnum Type
		{
			get { return (EnemyTypeEnum)GetValue(TypeProperty); }
			set { SetValue(TypeProperty, value); }
		}

		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public bool ShowHitbox
		{
			get { return (bool)GetValue(ShowHitboxProperty); }
			set { SetValue(ShowHitboxProperty, value); if (ShowHitbox) HitBox.Stroke = Brushes.Red; }
		}

		public MediaPlayer mediaPlayer { get; set; }

		public Storyboard storyboard { get; set; }

		public bool TargetHitted { get; set; } = false;

		public EnemySpawnSprite()
		{
			mediaPlayer = new();
			mediaPlayer.Open(new(HitSound, UriKind.Relative));
			mediaPlayer.Position = new TimeSpan(0, 0, 0, 0, 8);
			mediaPlayer.Volume = GameEngine.SoundEffectsVolume;
			InitializeComponent();
		}
	}
}
