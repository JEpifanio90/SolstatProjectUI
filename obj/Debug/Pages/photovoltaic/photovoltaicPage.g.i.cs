﻿#pragma checksum "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0F533649C7C9C9835A0DB4C4D6E36710"
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


namespace SolstatProjectUI.Pages.photovoltaic {
    
    
    /// <summary>
    /// photovoltaicPage
    /// </summary>
    public partial class photovoltaicPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView mainComponentListPhoto;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView secondaryComponentListPhoto;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView outputListPhoto;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button photoNextBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button photoBackBtn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button photoUpdateBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/SolstatProjectUI;component/pages/photovoltaic/photovoltaicpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
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
            this.mainComponentListPhoto = ((System.Windows.Controls.ListView)(target));
            
            #line 12 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
            this.mainComponentListPhoto.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.mainComponentListPhoto_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.secondaryComponentListPhoto = ((System.Windows.Controls.ListView)(target));
            
            #line 23 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
            this.secondaryComponentListPhoto.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.secondaryComponentListPhoto_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.outputListPhoto = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.photoNextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
            this.photoNextBtn.Click += new System.Windows.RoutedEventHandler(this.photoNextBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.photoBackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
            this.photoBackBtn.Click += new System.Windows.RoutedEventHandler(this.photoBackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.photoUpdateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Pages\photovoltaic\photovoltaicPage.xaml"
            this.photoUpdateBtn.Click += new System.Windows.RoutedEventHandler(this.photoUpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

