﻿#pragma checksum "..\..\..\Pages\Updatepdv.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9B09BE07D8E49460B48C42D828AF2A823CC4E539C57B4C8A61E5DC45121FFB6"
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
    /// Updatepdv
    /// </summary>
    public partial class Updatepdv : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label fechafinLabel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fechaFinBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdEstadoPDVLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdEstadoPDV;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdSolicitudLabel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIdSolicitud;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton VentaLocalSi;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton VentaLocalNo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\Updatepdv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Actualizar_proceso;
        
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
            System.Uri resourceLocater = new System.Uri("/maipoGrande;component/pages/updatepdv.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Updatepdv.xaml"
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
            
            #line 15 "..\..\..\Pages\Updatepdv.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fechafinLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.fechaFinBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.IdEstadoPDVLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cbIdEstadoPDV = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Pages\Updatepdv.xaml"
            this.cbIdEstadoPDV.Loaded += new System.Windows.RoutedEventHandler(this.CbIdEstadoPDV_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.IdSolicitudLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cbIdSolicitud = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\Pages\Updatepdv.xaml"
            this.cbIdSolicitud.Loaded += new System.Windows.RoutedEventHandler(this.CbIdSolicitud_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.VentaLocalSi = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.VentaLocalNo = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.Actualizar_proceso = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\Updatepdv.xaml"
            this.Actualizar_proceso.Click += new System.Windows.RoutedEventHandler(this.Actualizar_proceso_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

