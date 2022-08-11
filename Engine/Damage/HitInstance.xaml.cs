using System.Windows.Controls;

namespace Engine.Damage
{
	/// <summary>
	/// Interaction logic for HitInstance.xaml
	/// </summary>
	public partial class HitInstance : UserControl
	{
		public HitInstance(Enemies.Instance.EnemySpawnSprite Instance)
		{
			InitializeComponent();

			Canvas.SetLeft(this, Canvas.GetLeft(Instance) + Canvas.GetLeft(Instance.DamageInstance));
			Canvas.SetTop(this, Canvas.GetTop(Instance) + Canvas.GetLeft(Instance.DamageInstance));
			Canvas.SetZIndex(this, 99);
		}
	}
}
