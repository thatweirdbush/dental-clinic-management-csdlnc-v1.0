﻿#pragma checksum "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22B95BEEEB8FA20176D076027D673801F4A06C45"
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
    /// ViewRestrictedMedicationList
    /// </summary>
    public partial class ViewRestrictedMedicationList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ContraindicatedMedicationListDataGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewRestrictedMedicationButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MedicationNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewMedicationIDTextBox;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalClinicManagement;component/dentist/viewrestrictedmedicationlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.ContraindicatedMedicationListDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            this.ContraindicatedMedicationListDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.RestrictedMedicationList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddNewRestrictedMedicationButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            this.AddNewRestrictedMedicationButton.Click += new System.Windows.RoutedEventHandler(this.AddNewRestrictedMedicationButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MedicationNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NewMedicationIDTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.HomeButton = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            this.HomeButton.Click += new System.Windows.RoutedEventHandler(this.HomeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\..\Dentist\ViewRestrictedMedicationList.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

