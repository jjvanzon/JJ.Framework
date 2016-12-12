JJ.Framework.Presentation.Mvc contains extensions to the Microsoft ASP.NET MVC Framework for developing web applications.

Most notably it makes it possible to send tree structures over HTTP which is not possible by default with MVC. Even though MVC can interpret POST data in a certain format, that allows tree structures to be received by MVC, there is no way to actually build up those tree structures from your view code, at least not natively supported by MVC. The HtmlHelperExtensions_Collections allow you to send tree-structures over the wire.

You have to wrap every level in the tree structure in a using block, as demonstrated with Razor syntax here:

	@using (Html.BeginItem(() => Model.MyItem))
	{
		using (Html.BeginCollection(() => Model.MyItem.MyCollection))
		{
			foreach (var x in Model.MyItem.MyCollection)
			{
				using (Html.BeginCollectionItem())
				{

				}
			}
		}
	}

Unfortunately it still contains bugs. I know which ones. Hopefully I will find time to solve them.

Next to that awsome idea, this project also contains a terrible idea: ViewMapping. Don't look there. I will refactor that out eventually.