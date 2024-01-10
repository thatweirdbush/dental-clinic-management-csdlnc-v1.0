﻿#pragma checksum "..\..\..\..\Dentist\DashBoard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9EFDF0E709C7D0ED6301C0405A29E26B4312F2AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DentalClinicManagement.Dentist;
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


namespace DentalClinicManagement.Dentist {
    
    
    /// <summary>
    /// DashBoard
    /// </summary>
    public partial class DashBoard : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock phone;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock email;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock address;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_profile_btn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_appointment_btn;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_patient_btn;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\Dentist\DashBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MedicalManagementButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalClinicManagement;component/dentist/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dentist\DashBoard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.phone = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.email = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.address = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 42 "..\..\..\..\Dentist\DashBoard.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.logOut);
            
            #line default
            #line hidden
            return;
            case 5:
            this.add_profile_btn = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\Dentist\DashBoard.xaml"
            this.add_profile_btn.Click += new System.Windows.RoutedEventHandler(this.ReceivePatient);
            
            #line default
            #line hidden
            return;
            case 6:
            this.view_appointment_btn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Dentist\DashBoard.xaml"
            this.view_appointment_btn.Click += new System.Windows.RoutedEventHandler(this.view_appointment_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.add_patient_btn = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\Dentist\DashBoard.xaml"
            this.add_patient_btn.Click += new System.Windows.RoutedEventHandler(this.AddRecord);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MedicalManagementButton = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\..\Dentist\DashBoard.xaml"
            this.MedicalManagementButton.Click += new System.Windows.RoutedEventHandler(this.MedicalManagementButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

