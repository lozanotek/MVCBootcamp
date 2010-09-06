<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    miniurl :: home
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript"> 
        function checkform(form) {
            if (form.url.value == "") {
                alert("Please type or paste a web address to shorten into the input box.");

                form.url.focus();
                return false;
            }
            var found = false;

            for (var i = 0; i < form.url.value.length; i++) {
                var chr = form.url.value.charAt(i);
                if (chr == '.') {
                    found = true;
                    break;
                }
            }
            if (found == false) {
                alert("Please type or paste a valid web address into the input box.");
                form.url.focus();
                return false;
            }
            return true;
        }
        function focusbox() {
            el = document.getElementById('url');
            el.focus();
        }

        window.onload = focusbox;
    </script>

    <form method="post" action="miniurl" onsubmit="return checkform(this">
    	<div style="text-align: center">
        	<p>What's the URL you want to minimize?</p>
        	<textarea cols="75" rows="4" id="url" name="url"></textarea> <br />
        	<input type="submit" value="Minimize!" />
	</div>
    </form>
</asp:Content>
