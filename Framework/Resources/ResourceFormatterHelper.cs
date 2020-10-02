using System;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using JJ.Framework.Common;

namespace JJ.Framework.Resources
{
	/// <summary>
	/// Aims to supply basic logic for programming a ResourceFormatter class.
	/// The methods would aim to get a string resource from a specified ResourceManager.
	/// The idea would be that it were possible to program a ResourceFormatter class,
	/// with members that have the same name as the string resource.
	/// The aim is to also supply methods for filling in string placeholders.
	/// First the current culture might be used. If that does not give a text,
	/// it tries using a fallback culture (en-US).
	/// If no text is found in the resources, an exception may be thrown.
	/// This mechanism might be used in JJ.Framework in the CommonResourceFormatter,
	/// but it might be possible to reuse that mechanism in another custom class.
	/// 
	/// <para> Example of usage: </para>
	/// <para> public static class ResourceFormatter { </para>
	/// <para> private static readonly ResourceFormatterHelper _helper = new ResourceFormatterHelper(Resources.ResourceManager); </para>
	/// <para> public static string Duplicates =&gt; _helper.GetText(); } </para>
	/// <para> public static string PleaseFirst_WithName(string name) =&gt; _helper.GetText_WithOnePlaceHolder(name); } </para>
	/// 
	/// In the code above "Resources" might then be a resource editor from Visual Studio that may have the resources named Duplicates and PleaseFirst_WithName.
	/// </summary>
	[PublicAPI]
	public class ResourceFormatterHelper
	{
		private static readonly CultureInfo _fallBackCulture = new CultureInfo("en-US");

		private readonly ResourceManager _resourceManager;

		/// <inheritdoc cref="ResourceFormatterHelper" />
		public ResourceFormatterHelper(ResourceManager resourceManager)
			=> _resourceManager = resourceManager ?? throw new ArgumentNullException(nameof(resourceManager));

		public string GetText_WithOnePlaceHolder(object arg0, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0);

		public string GetText_WithTwoPlaceHolders(object arg0, object arg1, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0, arg1);

		public string GetText_WithThreePlaceHolders(
			object arg0, object arg1, object arg2, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0, arg1, arg2);

		public string GetText([CallerMemberName] string callerMemberName = null)
		{
			if (callerMemberName == null)
			{
				throw new Exception(
					$"{nameof(callerMemberName)} is null. Perhaps the wrong helper method called was called: " +
					$"{nameof(GetText)}, {nameof(GetText_WithOnePlaceHolder)}, {nameof(GetText_WithTwoPlaceHolders)}, etc.");
			}

			string resourceString = _resourceManager.GetString(callerMemberName);

			if (!string.IsNullOrWhiteSpace(resourceString))
			{
				return resourceString;
			}

			resourceString = _resourceManager.GetString(callerMemberName, _fallBackCulture);

			if (string.IsNullOrWhiteSpace(resourceString))
			{
				throw new Exception(
					$"{nameof(resourceString)} is null or whitespace for resource name '{callerMemberName}' both " +
					$"current culture '{CultureHelper.GetCurrentCultureName()}' and fallback culture '{_fallBackCulture.Name}'.");
			}

			return resourceString;
		}
	}
}
