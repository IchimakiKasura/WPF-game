namespace Game;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public bool IsStart = false;

	public Rect CurrentMouse;

	DispatcherTimer t = new();

	GameEngine gameEngine;

	public MainWindow()
	{
		// epic
		//Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 20 });
		
		InitializeComponent();

		GameEngine.MusicVolume = 0.1;
		GameEngine.SoundEffectsVolume = 0.1;

		InitializeGlobalComponent();

		MediaPlayer mp = new();

		mp.Open(new(BGM, UriKind.Relative));
		mp.Volume = GameEngine.MusicVolume;
		mp.MediaEnded += delegate
		{
			mp.Position = TimeSpan.Zero;
			mp.Play();
		};

		GameEngine.Game_H = (int)GameWindow.Height;
		GameEngine.Game_W = (int)GameWindow.Width;

		gameEngine = new();

		Start.Click += delegate
		{

			mp.Play();
			Start.IsEnabled = false;
			TX.IsEnabled = true;

			TX.Text = "1000";

			t.Tick += delegate
			{
				gameEngine.Enemy.EnemySpawn(EnemyType.Slime);
				gameEngine.Enemy.EnemySpawn(EnemyType.Astolfo);
				gameEngine.Enemy.EnemySpawn(EnemyType.WhiteAnomaly);
			};
			t.Interval = TimeSpan.FromMilliseconds(1000);
			t.Start();
		};

	}

	private void MouseMoveHandler(object sender, System.Windows.Input.MouseEventArgs e)
	{
		Point position = e.GetPosition(MainCanvas);

		Canvas.SetLeft(ellipse, position.X - 50);
		Canvas.SetTop(ellipse, position.Y - 50);

		GameEngineBehaviour.CurrentMouse = CurrentMouse = new(position.X - 50, position.Y - 50, 100, 100);
	}

	private void TextChange(object sender, TextChangedEventArgs e)
	{
		if (TX.Text.Length < 1)
		{
			MessageBox.Show("Bro, Don't or you'll kill the process.", "tf?");
			TX.Text = "1000";
		}

		t.Interval = TimeSpan.FromMilliseconds(int.Parse(TX.Text));
		if (System.Text.RegularExpressions.Regex.IsMatch(TX.Text, "[^0-9]"))
		{
			TX.Text = TX.Text.Remove(TX.Text.Length - 1, 1);
			TX.SelectionStart = TX.Text.Length;
		}
	}
}
