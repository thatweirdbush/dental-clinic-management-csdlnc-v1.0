﻿#pragma checksum "..\..\..\..\Admin\ReportAppointment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78594EBE87670368771CEDE07D3AE7B40137E7E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DentalClinicManagement.Admin;
using DentalClinicManagement.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace DentalClinicManagement.Admin {
    
    
    /// <summary>
    /// ReportAppointment
    /// </summary>
    public partial class ReportAppointment : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Date;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Date_Copy;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fromDatePicker;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker toDatePicker;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Schedule;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ReportAppointListView;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DentistSearch;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button filter_btn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Admin\ReportAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalClinicManagement;component/admin/reportappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admin\ReportAppointment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Date_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.fromDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.toDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Schedule = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ReportAppointListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.DentistSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.filter_btn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Admin\ReportAppointment.xaml"
            this.filter_btn.Click += new System.Windows.RoutedEventHandler(this.Filter_Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Admin\ReportAppointment.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.viewHome);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

