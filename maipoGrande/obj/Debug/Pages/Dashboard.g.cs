﻿#pragma checksum "..\..\..\Pages\Dashboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "515B0A7B0235138AC83DF17E100C6316AD78EDFC542DC9B162BE12BFEF16FC74"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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
    /// Dashboard
    /// </summary>
    public partial class Dashboard : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart preciosPdv;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel menu;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ventasLocales;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ventasExternas;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart Chart;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Pages\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button facturaLocal;
        
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
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Dashboard.xaml"
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
            this.preciosPdv = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 2:
            this.menu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.ventasLocales = ((System.Windows.Controls.RadioButton)(target));
            
            #line 101 "..\..\..\Pages\Dashboard.xaml"
            this.ventasLocales.Click += new System.Windows.RoutedEventHandler(this.Click_ventasLocales);
            
            #line default
            #line hidden
            
            #line 101 "..\..\..\Pages\Dashboard.xaml"
            this.ventasLocales.Checked += new System.Windows.RoutedEventHandler(this.ventasLocales_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ventasExternas = ((System.Windows.Controls.RadioButton)(target));
            
            #line 102 "..\..\..\Pages\Dashboard.xaml"
            this.ventasExternas.Click += new System.Windows.RoutedEventHandler(this.click_ventasExternas);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\Pages\Dashboard.xaml"
            this.ventasExternas.Checked += new System.Windows.RoutedEventHandler(this.ventasExternas_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Chart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 6:
            
            #line 171 "..\..\..\Pages\Dashboard.xaml"
            ((LiveCharts.Wpf.PieChart)(target)).DataClick += new LiveCharts.Events.DataClickHandler(this.Chart_OnDataClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.facturaLocal = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\Pages\Dashboard.xaml"
            this.facturaLocal.Click += new System.Windows.RoutedEventHandler(this.facturaLocal_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

