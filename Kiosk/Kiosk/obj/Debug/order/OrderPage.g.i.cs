﻿#pragma checksum "..\..\..\order\OrderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7DCA6697A1DEE5DEB5788740BC0B5D7AF8B17FB18C8BB937C234504BF92B1AC"
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
        
        
        #line 30 "..\..\..\order\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox xCategory;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\order\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox xMenus;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\order\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\order\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Order_Cancel;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\order\OrderPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/order/orderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\order\OrderPage.xaml"
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
            
            #line 31 "..\..\..\order\OrderPage.xaml"
            this.xCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.xMenus = ((System.Windows.Controls.ListBox)(target));
            
            #line 70 "..\..\..\order\OrderPage.xaml"
            this.xMenus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listView = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            
            #line 129 "..\..\..\order\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 138 "..\..\..\order\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Next_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Order_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\order\OrderPage.xaml"
            this.Order_Cancel.Click += new System.Windows.RoutedEventHandler(this.Order_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Order_Button = ((System.Windows.Controls.Button)(target));
            
            #line 167 "..\..\..\order\OrderPage.xaml"
            this.Order_Button.Click += new System.Windows.RoutedEventHandler(this.Order_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

