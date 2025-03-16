<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<JJ.OneOff.BeginCollectionItemTest.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.Views" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Edit</title>
</head>
<body>
    <% using (Html.BeginForm()) { %>

        <div>
            <ul>
                <% Html.RenderPartial(ViewNames._EditItem); %>
            </ul>
        </div>

        <div>
            <input type="submit" value="Save" />
        </div>

    <% } %>
</body>
</html>
