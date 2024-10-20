﻿using System;
using System.Threading;
using System.Windows.Forms;
using JJ.Framework.Logging;
// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace JJ.Framework.WinForms.Helpers
{
    /// <summary>
    /// A WinForms message box might be shown upon exceptions when using this utility class.
    /// The aim is that the application would then not halt upon unhandled exceptions.
    /// The Initialize method would aim to set things up on its own.
    /// The following might also need to be added to the app.config
    /// otherwise the app may still halt upon exceptions on non-UI threads.
    /// <para>
    /// &lt;runtime&gt;
    /// &lt;legacyUnhandledExceptionPolicy enabled="1" /&gt;
    /// &lt;/runtime&gt;
    /// </para>
    /// It may still not prevent your WinForms app from halting.
    /// </summary>
    public static class UnhandledExceptionMessageBoxShower
    {
        private static bool _isInitialized;
        private static string _applicationName;

        public static void Initialize(string applicationName)
        {
            if (_isInitialized) throw new Exception($"{nameof(Initialize)} cannot be called more than once.");

            _applicationName = applicationName;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _isInitialized = true;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ShowMessageBox(ex);
            }
            else
            {
                string message = Convert.ToString(e.ExceptionObject);
                ShowMessageBox(message);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) => ShowMessageBox(e.Exception);

        /// <summary>
        /// Some threads' exceptions don't appear to be handled by the standard WinForms hooks.
        /// For instance a separate Windows message loop running on another thread for Midi device processing
        /// would not have its exceptions handled automatically.
        /// Then you can call this method manually.
        /// Otherwise, the Initialize method would aim to set things up on its own.
        /// </summary>
        public static void ShowMessageBox(Exception ex)
        {
            Exception ex2 = ExceptionHelper.GetInnermostException(ex);
            string message = ExceptionHelper.FormatException(ex2, false);
            ShowMessageBox(message);
        }

        private static void ShowMessageBox(string message) => MessageBox.Show(message, GetMessageBoxCaption());

        private static string GetMessageBoxCaption() => $"{_applicationName} - Exception";
    }
}
