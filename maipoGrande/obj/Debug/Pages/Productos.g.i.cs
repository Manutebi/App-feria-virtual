﻿#pragma checksum "..\..\..\Pages\Productos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F8D593BD41E66B583AE041BADFE92873A92701A"
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
    /// Productos
    /// </summary>
    public partial class Productos : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid listadoProductos;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NombreProductoLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NombreProductoBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label idCalidadLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdCalidad;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label idProductoLabel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdProducto;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuardarProducto;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ActualizarProducto;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EliminarProducto;
        
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
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/productos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Productos.xaml"
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
            this.listadoProductos = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Pages\Productos.xaml"
            this.listadoProductos.Loaded += new System.Windows.RoutedEventHandler(this.ListadoProductos_Loaded);
            
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
            
            #line 19 "..\..\..\Pages\Productos.xaml"
            this.cbIdCalidad.Loaded += new System.Windows.RoutedEventHandler(this.CbIdCalidad_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.idProductoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cbIdProducto = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\Pages\Productos.xaml"
            this.cbIdProducto.Loaded += new System.Windows.RoutedEventHandler(this.CbIdProducto_Loaded);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Pages\Productos.xaml"
            this.cbIdProducto.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbIdProducto_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GuardarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\Productos.xaml"
            this.GuardarProducto.Click += new System.Windows.RoutedEventHandler(this.GuardarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ActualizarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\Productos.xaml"
            this.ActualizarProducto.Click += new System.Windows.RoutedEventHandler(this.ActualizarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.EliminarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\Productos.xaml"
            this.EliminarProducto.Click += new System.Windows.RoutedEventHandler(this.EliminarProducto_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

