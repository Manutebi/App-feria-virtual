// Updated by XamlIntelliSenseFileGenerator 22/11/2022 18:06:08
#pragma checksum "..\..\..\Pages\Updateventas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87D719CF920188AA5A8741E75031FEBBD3E12A37555F18AC495B1627AD9D56AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using maipoGrande.Pages;


namespace maipoGrande.Pages
{


    /// <summary>
    /// Updateventas
    /// </summary>
    public partial class Updateventas : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/updateventas.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Pages\Updateventas.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button btnClose;
        internal System.Windows.Controls.Label cantidadLabel;
        internal System.Windows.Controls.TextBox cantidadBox;
        internal System.Windows.Controls.Label frutaLabel;
        internal System.Windows.Controls.ComboBox cbProducto;
        internal System.Windows.Controls.Label estadoLabel;
        internal System.Windows.Controls.ComboBox cbEstadoSolicitud;
        internal System.Windows.Controls.Label idSolicitud;
        internal System.Windows.Controls.ComboBox cbIdSolicitudCompra;
        internal System.Windows.Controls.Button GuardarSolicitud;
        internal System.Windows.Controls.Button ActualizarSolicitud;
        internal System.Windows.Controls.Button EliminarSolicitud;
    }
}

