<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JJ.OneOff.BeginCollectionItemTest.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.Views" %>

<li>
    <%: Model.Name %> (<%: Model.ID %>)

    <ul>

        <% foreach (var child in Model.Children) { %>

            <% Html.RenderPartial(ViewNames._DetailsItem, child); %>

        <% } %>

    </ul>
</li>