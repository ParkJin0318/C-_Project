﻿#pragma checksum "..\..\OrderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CE776B3C519A38505AF4F1DE03B59C57393B75AF0223EB3C347481A476E8C40"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Kiosk;
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


namespace Kiosk {
    
    
    /// <summary>
    /// OrderPage
    /// </summary>
    public partial class OrderPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox xCategory;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox xMenus;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Order_Cancel;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Order_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/orderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderPage.xaml"
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
            this.xCategory = ((System.Windows.Controls.ListBox)(target));
            
            #line 31 "..\..\OrderPage.xaml"
            this.xCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.xMenus = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.listView = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            
            #line 134 "..\..\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Order_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 152 "..\..\OrderPage.xaml"
            this.Order_Cancel.Click += new System.Windows.RoutedEventHandler(this.Order_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Order_Button = ((System.Windows.Controls.Button)(target));
            
            #line 163 "..\..\OrderPage.xaml"
            this.Order_Button.Click += new System.Windows.RoutedEventHandler(this.Order_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

