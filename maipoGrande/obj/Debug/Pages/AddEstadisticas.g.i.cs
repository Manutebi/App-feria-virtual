﻿#pragma checksum "..\..\..\Pages\AddEstadisticas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "341A694077C9847288294443389BFD42DBE5CA72A2EB31674F1CD6F2C2B6B845"
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
    /// AddEstadisticas
    /// </summary>
    public partial class AddEstadisticas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuardarSubasta;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RbLocalSi;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RbLocalNo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SubastaId;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PrecioPdv;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ValorSubasta;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\AddEstadisticas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFechaAsignada;
        
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
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/addestadisticas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddEstadisticas.xaml"
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
            
            #line 17 "..\..\..\Pages\AddEstadisticas.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\Pages\AddEstadisticas.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GuardarSubasta = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\AddEstadisticas.xaml"
            this.GuardarSubasta.Click += new System.Windows.RoutedEventHandler(this.GuardarSubasta_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RbLocalSi = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.RbLocalNo = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.SubastaId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PrecioPdv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ValorSubasta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.CbFechaAsignada = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\Pages\AddEstadisticas.xaml"
            this.CbFechaAsignada.Loaded += new System.Windows.RoutedEventHandler(this.CbFechaAsignada_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
