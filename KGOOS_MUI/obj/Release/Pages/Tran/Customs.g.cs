﻿#pragma checksum "..\..\..\..\Pages\Tran\Customs.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9589D330CB7FA375F27D681B57C5F3432D014B0F"
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


namespace KGOOS_MUI.Pages.Tran {
    
    
    /// <summary>
    /// Customs
    /// </summary>
    public partial class Customs : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelect;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOutput;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CBID;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClear;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBID;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DateTimePicker TBStartTime;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DateTimePicker TBEndTime;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\Pages\Tran\Customs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBReturnNum;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\Pages\Tran\Customs.xaml"
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
            System.Uri resourceLocater = new System.Uri("/KGOOS_MUI;component/pages/tran/customs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Tran\Customs.xaml"
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
            this.BtnSelect = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Pages\Tran\Customs.xaml"
            this.BtnSelect.Click += new System.Windows.RoutedEventHandler(this.BtnSelect_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnOutput = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.CBID = ((System.Windows.Controls.CheckBox)(target));
            
            #line 52 "..\..\..\..\Pages\Tran\Customs.xaml"
            this.CBID.Checked += new System.Windows.RoutedEventHandler(this.CBID_Checked);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\Pages\Tran\Customs.xaml"
            this.CBID.Unchecked += new System.Windows.RoutedEventHandler(this.CBID_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnClear = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Pages\Tran\Customs.xaml"
            this.BtnClear.Click += new System.Windows.RoutedEventHandler(this.BtnClear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TBID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TBStartTime = ((System.Windows.Forms.DateTimePicker)(target));
            return;
            case 7:
            this.TBEndTime = ((System.Windows.Forms.DateTimePicker)(target));
            return;
            case 8:
            this.TBReturnNum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.DG1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

