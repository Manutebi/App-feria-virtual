﻿#pragma checksum "..\..\..\Pages\Addproductos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "044E51DB44DF7B33A0F924DFCA22C57B8785FCB6BBC582EE57CA677AB8B62551"
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


namespace maipoGrande.Pages {
    
    
    /// <summary>
    /// Addproductos
    /// </summary>
    public partial class Addproductos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NombreProductoLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NombreProductoBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label idCalidadLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdCalidad;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\Addproductos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuardarProducto;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/addproductos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Addproductos.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Pages\Addproductos.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NombreProductoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.NombreProductoBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.idCalidadLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cbIdCalidad = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\Pages\Addproductos.xaml"
            this.cbIdCalidad.Loaded += new System.Windows.RoutedEventHandler(this.CbIdCalidad_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GuardarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\Addproductos.xaml"
            this.GuardarProducto.Click += new System.Windows.RoutedEventHandler(this.GuardarProducto_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

