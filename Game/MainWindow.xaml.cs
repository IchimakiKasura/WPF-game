using System.IO;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

		InitializeGlobalComponent();

		MediaPlayer mp = new();

		mp.Open(new("Game/Musics/BGM.wav", UriKind.Relative));
		mp.MediaEnded += delegate
		{
			mp.Position = TimeSpan.Zero;
			mp.Play();
		};

		gameEngine = new();

		Start.Click += delegate
		{

			//mp.Play();
			Start.IsEnabled = false;
			TX.IsEnabled = true;

			TX.Text = "1000";

			t.Tick += delegate
			{
				//gameEngine.Enemy.EnemySpawn(EnemyType.Slime);
				//gameEngine.Enemy.EnemySpawn(EnemyType.Astolfo);
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
