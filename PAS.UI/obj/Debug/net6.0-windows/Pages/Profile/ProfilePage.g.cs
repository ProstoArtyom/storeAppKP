﻿#pragma checksum "..\..\..\..\..\Pages\Profile\ProfilePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B29AD0EB2DEAC02977DD8B1989E2A39E626A888D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PAS.UI.Pages;
using PAS.UI.Pages.Profile;
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


namespace PAS.UI.Pages.Profile {
    
    
    /// <summary>
    /// ProfilePage
    /// </summary>
    public partial class ProfilePage : PAS.UI.Pages.PASAppPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame AccountInfoFrame;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OrderDataGrid;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OrdersStatusLbl;
        
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
            System.Uri resourceLocater = new System.Uri("/PAS.UI;component/pages/profile/profilepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.AccountInfoFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.OrderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 67 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
            this.OrderDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OrderDataGrid_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrdersStatusLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            
            #line 135 "..\..\..\..\..\Pages\Profile\ProfilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

