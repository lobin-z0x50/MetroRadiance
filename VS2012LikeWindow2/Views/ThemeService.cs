using System.Windows;
using System.Windows.Media;

namespace VS2012LikeWindow2.Views
{
	public enum Accent
	{
		Purple, Blue, Orange,
	}

	public static class ThemeService
	{		
		public static void ChangeTheme(this Application app, Accent accent)
		{
			SolidColorBrush brush = null;
			switch (accent)
			{
				case Accent.Purple:
					brush = new SolidColorBrush(Color.FromRgb(104, 33, 122));
					break;
				case Accent.Blue:
					brush = new SolidColorBrush(Color.FromRgb(0, 122, 204));
					break;
				case Accent.Orange:
					brush = new SolidColorBrush(Color.FromRgb(202, 81, 0));
					break;
			}

			app.Resources["AccentBrushKey"] = brush;
		}
	}
}
