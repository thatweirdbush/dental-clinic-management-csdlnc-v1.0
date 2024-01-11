﻿#pragma checksum "..\..\..\..\Dentist\MedicalManagement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D4321AE3BCC39C371ADE721A09A936FF70AF11C4"
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
    /// MedicalManagement
    /// </summary>
    public partial class MedicalManagement : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboPage;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ListMedical;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas ViewMedicalDetail;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListBook;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Dentist\MedicalManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas EditMedicalDetail;
        
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
            System.Uri resourceLocater = new System.Uri("/DentalClinicManagement;V1.0.0.0;component/dentist/medicalmanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dentist\MedicalManagement.xaml"
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
            
            #line 17 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnBackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\Dentist\MedicalManagement.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPrevious_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comboPage = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\..\Dentist\MedicalManagement.xaml"
            this.comboPage.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboPage_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 36 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListMedical = ((System.Windows.Controls.DataGrid)(target));
            
            #line 38 "..\..\..\..\Dentist\MedicalManagement.xaml"
            this.ListMedical.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 43 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addMedical);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ViewMedicalDetail = ((System.Windows.Controls.Canvas)(target));
            return;
            case 9:
            this.ListBook = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            
            #line 77 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editMedical);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 84 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deletemedical);
            
            #line default
            #line hidden
            return;
            case 12:
            this.EditMedicalDetail = ((System.Windows.Controls.Canvas)(target));
            return;
            case 13:
            
            #line 106 "..\..\..\..\Dentist\MedicalManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.completeMedical);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

