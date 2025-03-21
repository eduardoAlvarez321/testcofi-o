<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Colaborador.aspx.cs" Inherits="NOM.WA.DATOSEMPLEADOE.FE.Colaborador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCargarDatos" runat="server" Text="Cargar Datos" OnClick="btnCargarDatos_Click" />

            <asp:GridView ID="gvColaboradores" runat="server" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
