﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.WinForms.Controls;
using JJ.Framework.WinForms.Helpers;
// ReSharper disable once ValueParameterNotUsed

namespace JJ.Framework.WinForms.Forms
{
	[PublicAPI]
	public partial class SimpleProcessForm : Form
	{
		public event EventHandler OnRunProcess;
		public event EventHandler Cancelled;

		// Initialization

		public SimpleProcessForm()
		{
			InitializeComponent();

			if (Assembly.GetEntryAssembly() != null)
			{
				base.Text = Assembly.GetEntryAssembly().GetName().Name;
			}

			simpleProcessControl.OnRunProcess += SimpleProcessControl_OnRunProcess;
			simpleProcessControl.Cancelled += SimpleProcessControl_Cancelled;
		}

		private void SimpleProcessForm_Load(object sender, EventArgs e) => PositionControls();

		// Properties

		[Browsable(false)]
		public bool IsRunning
		{
			get => simpleProcessControl.IsRunning;
			set => simpleProcessControl.IsRunning = value;
		}

		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => simpleProcessControl.Description;
			set => simpleProcessControl.Description = value;
		}

		[DefaultValue("Path: ")]
		public string TextBoxLabelText
		{
			get => simpleProcessControl.TextBoxLabelText;
			set => simpleProcessControl.TextBoxLabelText = value;
		}

		public string TextBoxText
		{
			get => simpleProcessControl.TextBoxText;
			set => simpleProcessControl.TextBoxText = value;
		}

		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => simpleProcessControl.TextBoxEnabled;
			set => simpleProcessControl.TextBoxEnabled = value;
		}

		[DefaultValue(true)]
		public bool TextBoxVisible
		{
			get => simpleProcessControl.TextBoxVisible;
			set => simpleProcessControl.TextBoxVisible = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.FileBrowseMode" />
		public FileBrowseModeEnum FileBrowseMode
		{
			get => simpleProcessControl.FileBrowseMode;
			set => simpleProcessControl.FileBrowseMode = value;
		}

		[DefaultValue(true)]
		public bool MustShowExceptions
		{
			get => simpleProcessControl.MustShowExceptions;
			set => simpleProcessControl.MustShowExceptions = value;
		}

		[DefaultValue("Are you sure?")]
		public string AreYouSureQuestion
		{
			get => simpleProcessControl.AreYouSureQuestion;
			set => simpleProcessControl.AreYouSureQuestion = value;
		}

		[DefaultValue(16)]
		public int Spacing
		{
			get => simpleProcessControl.Spacing;
			set => simpleProcessControl.Spacing = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.TextBoxRightToLeft" />
		[DefaultValue(RightToLeft.Yes)]
		public RightToLeft TextBoxRightToLeft
		{
			get => simpleProcessControl.TextBoxRightToLeft;
			set => simpleProcessControl.TextBoxRightToLeft = value;
		}

		[DefaultValue("Start")]
		public string StartButtonText
		{
			get => simpleProcessControl.StartButtonText;
			set => simpleProcessControl.StartButtonText = value;
		}

		[DefaultValue("Cancel")]
		public string CancelButtonText
		{
			get => simpleProcessControl.CancelButtonText;
			set => simpleProcessControl.CancelButtonText = value;
		}

		[DefaultValue(true)]
		public bool BrowseButtonEnabled
		{
			get => simpleProcessControl.BrowseButtonEnabled;
			set => simpleProcessControl.BrowseButtonEnabled = false;
		}

		/// <summary>
		/// The base form seems to be as bold as to
		/// assign the entry-point assembly name
		/// as the form's title bar text.
		/// It may afterwards be assigned something custom.
		/// </summary>
		public new string Text
		{
			get => base.Text;
			set => base.Text = value;
		}

		// Positioning

		private void SimpleProcessForm_SizeChanged(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			simpleProcessControl.Location = new Point(0, 0);
			simpleProcessControl.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
		}

		// Processing

		public void ShowProgress(string message) => simpleProcessControl.ShowProgress(message);

		private void SimpleProcessControl_OnRunProcess(object sender, EventArgs e) => OnRunProcess?.Invoke(sender, e);

		private void SimpleProcessControl_Cancelled(object sender, EventArgs e) => Cancelled?.Invoke(sender, e);

	    private void Base_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = simpleProcessControl.IsRunning;

	    public void OnUiThread(Action action) => simpleProcessControl.OnUiThread(action);

		public void OnBackgroundThread(Action action) => simpleProcessControl.OnBackgroundThread(action);
	}
}