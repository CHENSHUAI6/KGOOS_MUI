﻿#pragma checksum "..\..\..\..\Pages\BaseData\Coupon.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "057F3EA3DFD034C1EAD0B80938DFD6AED7F70275"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
using KGOOS_MUI.Control;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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


namespace KGOOS_MUI.Pages.BaseData {
    
    
    /// <summary>
    /// Coupon
    /// </summary>
    public partial class Coupon : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Select;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Del;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Insert;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Save;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Cancel;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Name;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Money;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Pages\BaseData\Coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DG1;
        
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
            System.Uri resourceLocater = new System.Uri("/KGOOS_MUI;component/pages/basedata/coupon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\BaseData\Coupon.xaml"
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
            this.Btn_Select = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Pages\BaseData\Coupon.xaml"
            this.Btn_Select.Click += new System.Windows.RoutedEventHandler(this.Btn_Select_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Btn_Del = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Pages\BaseData\Coupon.xaml"
            this.Btn_Del.Click += new System.Windows.RoutedEventHandler(this.Btn_Del_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Btn_Insert = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Pages\BaseData\Coupon.xaml"
            this.Btn_Insert.Click += new System.Windows.RoutedEventHandler(this.Btn_Insert_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_Save = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Pages\BaseData\Coupon.xaml"
            this.Btn_Save.Click += new System.Windows.RoutedEventHandler(this.Btn_Save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Btn_Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.TB_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TB_Money = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DG1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 88 "..\..\..\..\Pages\BaseData\Coupon.xaml"
            this.DG1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DG1_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

