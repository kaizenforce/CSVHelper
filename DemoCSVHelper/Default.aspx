<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoCSVHelper._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Demo - CSV Helper</h1>
        <p class="lead">Cargar un archivo CSV y mostrarlo en una grilla.</p>
    </div>
    <div class="row">
         <h2>Selecciona tu archivo .CSV</h2>
        <asp:FileUpload ID="FUSeleccionarArchivoCSV" runat="server" />

        <br />
         <asp:RadioButtonList ID="rdOpcionCarga" runat="server" RepeatDirection="Horizontal">
             <asp:ListItem Selected="True" Value="Simple">Simple</asp:ListItem>
             <asp:ListItem Value="Map">CSVMap</asp:ListItem>
         </asp:RadioButtonList>

         <br />
         <asp:Button ID="btnCargar" runat="server" Text="Cargar CSV" OnClick="btnCargar_Click" />

        <br />
        <asp:GridView ID="gvListaEmpleados" runat="server"></asp:GridView>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-4">
            <h2>Revisa más demos</h2>
            <p>
                Si deseas ver más demos, puedes visitarnos en:
            </p>
            <p>
                <a class="btn btn-primary btn-lg" href="http://www.kaizen-force.com">Kaizen Force - Blog</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Síguenos en Youtube</h2>
            <p>
                <a class="btn btn-primary btn-lg" href="http://www.youtube.com/c/kaizenforce">Kaizen Force - Youtube</a>
            </p>
        </div>
                <div class="col-md-4">
            <h2>Síguenos en Facebook</h2>
            <p>
                <a class="btn btn-primary btn-lg" href="http://www.facebook.com/kaizenforce">Kaizen Force - Facebook</a>
            </p>
        </div>
    </div>

</asp:Content>
