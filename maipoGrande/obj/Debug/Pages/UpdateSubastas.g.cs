﻿#pragma checksum "..\..\..\Pages\UpdateSubastas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F53998A20A8B2CEA847073D4D76E28EBA292F95AE55A37AEE9AA41B0395D553"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// UpdateSubastas
    /// </summary>
    public partial class UpdateSubastas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ActualizarSubasta;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fechaTerminoSubasta;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RbLocalSi;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RbLocalNo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox condTamano;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox condCarga;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox condRefrigeracion;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdPdv;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbEstadoSubasta;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\UpdateSubastas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox precioPdv;
        
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
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/updatesubastas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\UpdateSubastas.xaml"
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
            
            #line 18 "..\..\..\Pages\UpdateSubastas.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\Pages\UpdateSubastas.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ActualizarSubasta = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pages\UpdateSubastas.xaml"
            this.ActualizarSubasta.Click += new System.Windows.RoutedEventHandler(this.ActualizarSubasta_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.fechaTerminoSubasta = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.RbLocalSi = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.RbLocalNo = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.condTamano = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Pages\UpdateSubastas.xaml"
            this.condTamano.Loaded += new System.Windows.RoutedEventHandler(this.condTamano_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.condCarga = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\Pages\UpdateSubastas.xaml"
            this.condCarga.Loaded += new System.Windows.RoutedEventHandler(this.condCarga_Loaded);
            
            #line default
            #line hidden
            return;
            case 9:
            this.condRefrigeracion = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\Pages\UpdateSubastas.xaml"
            this.condRefrigeracion.Loaded += new System.Windows.RoutedEventHandler(this.condRefrigeracion_Loaded);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbIdPdv = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\Pages\UpdateSubastas.xaml"
            this.cbIdPdv.Loaded += new System.Windows.RoutedEventHandler(this.cbIdPdv_Loaded);
            
            #line default
            #line hidden
            return;
            case 11:
            this.CbEstadoSubasta = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\Pages\UpdateSubastas.xaml"
            this.CbEstadoSubasta.Loaded += new System.Windows.RoutedEventHandler(this.CbEstadoSubasta_Loaded);
            
            #line default
            #line hidden
            return;
            case 12:
            this.precioPdv = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
