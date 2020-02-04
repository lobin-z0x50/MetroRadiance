﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VS2012LikeWindow2.Models;
using VS2012LikeWindow2.Views;

namespace VS2012LikeWindow2.ViewModels
{
	class WindowViewModel : ViewModelBase
	{

		#region WindowState 変更通知プロパティ

		private WindowState _WindowState;

		public WindowState WindowState
		{
			get { return this._WindowState; }
			set
			{
				if (this._WindowState != value)
				{
					this._WindowState = value;
					this.IsMaximized = value == WindowState.Maximized;
					this.CanNormalize = value == WindowState.Maximized;
					this.CanMaximize = value == WindowState.Normal;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region IsMaximized 変更通知プロパティ

		private bool _IsMaximized;

		public bool IsMaximized
		{
			get { return this._IsMaximized; }
			set
			{
				if (this._IsMaximized != value)
				{
					this._IsMaximized = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanMaximize 変更通知プロパティ

		private bool _CanMaximize = true;

		public bool CanMaximize
		{
			get { return this._CanMaximize; }
			set
			{
				if (this._CanMaximize != value)
				{
					this._CanMaximize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanMinimize 変更通知プロパティ

		private bool _CanMinimize = true;

		public bool CanMinimize
		{
			get { return this._CanMinimize; }
			set
			{
				if (this._CanMinimize != value)
				{
					this._CanMinimize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanNormalize 変更通知プロパティ

		private bool _CanNormalize = false;

		public bool CanNormalize
		{
			get { return this._CanNormalize; }
			set
			{
				if (this._CanNormalize != value)
				{
					this._CanNormalize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public void ChangePurple()
		{
			App.Current.ChangeTheme(Accent.Purple);
		}
		public void ChangeBlue()
		{
			App.Current.ChangeTheme(Accent.Blue);
		}
		public void ChangeOrange()
		{
			App.Current.ChangeTheme(Accent.Orange);
		}
	}
}
