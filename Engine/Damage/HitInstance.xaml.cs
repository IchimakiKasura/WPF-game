namespace Engine.Damage
{
	/// <summary>
	/// Interaction logic for HitInstance.xaml
	/// </summary>
	public partial class HitInstance : UserControl
	{

		public static readonly DependencyProperty TextProperty = 
			DependencyProperty.Register("Text", typeof(string), typeof(HitInstance), new PropertyMetadata("Hello"));

		public static readonly DependencyProperty DamageTypeProperty =
			DependencyProperty.Register("DamageType", typeof(DamageTypeEnum), typeof(HitInstance), new PropertyMetadata(DamageTypeEnum.Normal));

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public DamageTypeEnum DamageType
		{
			get { return (DamageTypeEnum)GetValue(DamageTypeProperty); }
			set
			{
				SetValue(DamageTypeProperty, value);

				if (DamageType == DamageTypeEnum.Normal) Foreground = Brushes.White;
				if (DamageType == DamageTypeEnum.Critical) Foreground = Brushes.Red;
				if (DamageType == DamageTypeEnum.Delete) Foreground = Brushes.Gold;
			}
		}

		public HitInstance(EnemySpawnSprite Instance)
		{
			InitializeComponent();
	
			Canvas.SetLeft(this, Canvas.GetLeft(Instance) + Canvas.GetLeft(Instance.DamageInstance));
			Canvas.SetTop(this, Canvas.GetTop(Instance) + Canvas.GetLeft(Instance.DamageInstance));
			Canvas.SetZIndex(this, 99);
		}
	}
}
