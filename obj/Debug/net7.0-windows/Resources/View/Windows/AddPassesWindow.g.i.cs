﻿#pragma checksum "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E86AEB7718506564813CBB6A7BA64E490DCF3EC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Diplom.Resources.View.Windows;
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


namespace Diplom.Resources.View.Windows {
    
    
    /// <summary>
    /// AddPassesWindow
    /// </summary>
    public partial class AddPassesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimizeWindowButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExpandWindowButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitApplicationButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PassImage;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPass;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Diplom;component/resources/view/windows/addpasseswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.minimizeWindowButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.ExpandWindowButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.ExitApplicationButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.PassImage = ((System.Windows.Controls.Image)(target));
            
            #line 37 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
            this.PassImage.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.PassImage_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddPass = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\..\..\Resources\View\Windows\AddPassesWindow.xaml"
            this.AddPass.Click += new System.Windows.RoutedEventHandler(this.AddPass_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

