﻿#pragma checksum "..\..\..\..\Windows\HomeScherm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A3AA72A8F9DA821BA68069C1151F5863D3ED5C07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using VoetbalProject.Presentation.Windows;


namespace VoetbalProject.Presentation.Windows {
    
    
    /// <summary>
    /// HomeScherm
    /// </summary>
    public partial class HomeScherm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\Windows\HomeScherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label groeplabel;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Windows\HomeScherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TrainingButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Windows\HomeScherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateButton;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Windows\HomeScherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Export;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VoetbalProject.Presentation;component/windows/homescherm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\HomeScherm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 25 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 26 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.groeplabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            
            #line 45 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TrainingButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Windows\HomeScherm.xaml"
            this.TrainingButton.Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 57 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CreateButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Windows\HomeScherm.xaml"
            this.CreateButton.Click += new System.Windows.RoutedEventHandler(this.NavigateToNextWindow);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 68 "..\..\..\..\Windows\HomeScherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exporteer_NaarTekstFile);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Export = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\Windows\HomeScherm.xaml"
            this.Export.Click += new System.Windows.RoutedEventHandler(this.Exporteer_NaarTekstFile);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

