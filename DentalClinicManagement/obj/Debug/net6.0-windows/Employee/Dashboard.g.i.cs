﻿#pragma checksum "..\..\..\..\Employee\Dashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72D9F29E650C3D53A2F18A15A01550FDDBFB6704"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DentalClinicManagement.Converter;
using DentalClinicManagement.Employee;
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


namespace DentalClinicManagement.Employee {
    
    
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logOutButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button takePatientButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button findPatientButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button findPatientButton_Copy;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button findPatientButton_Copy1;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ScheduleButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Employee\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PaymentListButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DentalClinicManagement;V1.0.0.0;component/employee/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Employee\Dashboard.xaml"
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
            
            #line 10 "..\..\..\..\Employee\Dashboard.xaml"
            ((DentalClinicManagement.Employee.Dashboard)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logOutButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Employee\Dashboard.xaml"
            this.logOutButton.Click += new System.Windows.RoutedEventHandler(this.logOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.takePatientButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Employee\Dashboard.xaml"
            this.takePatientButton.Click += new System.Windows.RoutedEventHandler(this.takePatientButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.findPatientButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Employee\Dashboard.xaml"
            this.findPatientButton.Click += new System.Windows.RoutedEventHandler(this.findPatientButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.findPatientButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Employee\Dashboard.xaml"
            this.findPatientButton_Copy.Click += new System.Windows.RoutedEventHandler(this.ViewAppointment);
            
            #line default
            #line hidden
            return;
            case 6:
            this.findPatientButton_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Employee\Dashboard.xaml"
            this.findPatientButton_Copy1.Click += new System.Windows.RoutedEventHandler(this.viewSchedule);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ScheduleButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Employee\Dashboard.xaml"
            this.ScheduleButton.Click += new System.Windows.RoutedEventHandler(this.ScheduleButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PaymentListButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Employee\Dashboard.xaml"
            this.PaymentListButton.Click += new System.Windows.RoutedEventHandler(this.PaymentListButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

