using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using VS2012LikeWindow2.Views.MetroChrome;

namespace VS2012LikeWindow2.Views.Behaviors
{
	public class MetroChromeBehavior : Behavior<Window>
	{
        GlowWindow left, right, top, bottom;

        protected override void OnAttached()
		{
			base.OnAttached();

			this.AssociatedObject.Loaded += (sender, e) =>
            {
                left = new GlowWindow(this.AssociatedObject, GlowDirection.Left);
                right = new GlowWindow(this.AssociatedObject, GlowDirection.Right);
                top = new GlowWindow(this.AssociatedObject, GlowDirection.Top);
                bottom = new GlowWindow(this.AssociatedObject, GlowDirection.Bottom);

                ShowAll();
                UpdateAll();
            };

            this.AssociatedObject.Activated += (sender, e) =>
            {
                ShowAll();
            };
            this.AssociatedObject.Deactivated += (sender, e) =>
            {
                HideAll();
            };
        }

        private void UpdateAll()
        {
            left.Update();
            right.Update();
            top.Update();
            bottom.Update();
        }

        private void ShowAll()
        {
            left.Show();
            right.Show();
            top.Show();
            bottom.Show();
        }
        private void HideAll()
        {
            left.Hide();
            right.Hide();
            top.Hide();
            bottom.Hide();
        }
    }
}
