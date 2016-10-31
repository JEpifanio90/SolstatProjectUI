﻿#pragma checksum "..\..\..\..\Pages\radiation\radiationPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6F2E43D046BEC3F4EB39EF26EF05B478"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace SolstatProjectUI.Pages.radiation {
    
    
    /// <summary>
    /// radiationPage
    /// </summary>
    public partial class radiationPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map bmap;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CountyList;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox longitudeTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox latitudeTB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDate;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDate;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button thermoButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\radiation\radiationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button photoButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SolstatProjectUI;component/pages/radiation/radiationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\radiation\radiationPage.xaml"
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
            this.bmap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            case 2:
            this.CountyList = ((System.Windows.Controls.ListView)(target));
            
            #line 14 "..\..\..\..\Pages\radiation\radiationPage.xaml"
            this.CountyList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CountyList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.longitudeTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\Pages\radiation\radiationPage.xaml"
            this.longitudeTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.longitudeTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.latitudeTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\Pages\radiation\radiationPage.xaml"
            this.latitudeTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.latitudeTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.startDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.endDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.thermoButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Pages\radiation\radiationPage.xaml"
            this.thermoButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.photoButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Pages\radiation\radiationPage.xaml"
            this.photoButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

