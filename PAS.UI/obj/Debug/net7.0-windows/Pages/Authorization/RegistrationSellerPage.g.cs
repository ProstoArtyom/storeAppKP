﻿#pragma checksum "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B1F07AA2FFADA6448420ACAB51343A182D53F45B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PAS.UI.Pages;
using PAS.UI.Pages.Authorization;
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


namespace PAS.UI.Pages.Authorization {
    
    
    /// <summary>
    /// RegistrationSellerPage
    /// </summary>
    public partial class RegistrationSellerPage : PAS.UI.Pages.PASAppPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTb;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTb;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberTb;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTb;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RepeatPasswordTb;
        
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
            System.Uri resourceLocater = new System.Uri("/PAS.UI;component/pages/authorization/registrationsellerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
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
            this.LoginTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.EmailTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NumberTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PasswordTb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.RepeatPasswordTb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            
            #line 83 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegisterBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 86 "..\..\..\..\..\Pages\Authorization\RegistrationSellerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReturnBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

