global using Engine;
global using System;
global using System.Reflection;
global using System.Windows;
global using System.Windows.Controls;
global using System.Windows.Threading;

namespace Game;

public partial class MainWindow
{
	void InitializeGlobalComponent()
	{
		GameEngineBehaviour.BaseTower = BaseTower;
		GameEngineBehaviour.MainCanvas = MainCanvas;
		GameEngineBehaviour.CurrentMouse = CurrentMouse;
		GameEngineBehaviour.Gotaway = Gotaway;
		GameEngineBehaviour.kills = kills;
	}
}