<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JJ.OneOff.BeginCollectionItemTest.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="HtmlHelpers.BeginCollectionItem" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.Views" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.ViewModels" %>

<li>
    <%: Html.TextBoxFor(x => x.Name) %> (<%: Model.ID %>)

    <ul>

        <% foreach (var child in Model.Children) { %>

            <% using (Html.BeginCollectionItem(PropertyNames.Children)) { %>

                <% Html.RenderPartial(ViewNames._EditItem, child); %>

            <% } %>

        <% } %>

    </ul>
</li>