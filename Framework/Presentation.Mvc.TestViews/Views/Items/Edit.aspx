<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<JJ.Framework.Mvc.TestViews.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Views" %>

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
