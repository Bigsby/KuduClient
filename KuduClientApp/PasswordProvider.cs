using KuduClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KuduClientApp
{
    //public class PasswordProvider : UserControl, ISercurePasswordProvider
    //{
    //    public static readonly DependencyProperty PasswordBoxProperty = DependencyProperty.Register("PasswordBox", typeof(PasswordBox), typeof(PasswordProvider), new PropertyMetadata(null));
    //    public PasswordBox PasswordBox
    //    {
    //        get { return (PasswordBox)GetValue(PasswordBoxProperty); }
    //        set { SetValue(PasswordBoxProperty, value); }
    //    }

    //    public static readonly DependencyProperty BindingProperty = DependencyProperty.Register("Binding", typeof(ISercurePasswordProvider), typeof(PasswordProvider), new PropertyMetadata(null));
    //    public ISercurePasswordProvider Binding
    //    {
    //        get { return this; }
    //        set { }
    //    }

    //    public string GetPassword()
    //    {
    //        return PasswordBox?.Password;
    //    }
    //}

    public class PasswordProvider : DependencyObject, ISecurePasswordProvider
    {
        private readonly PasswordBox _passwordBox;
        private PasswordProvider(PasswordBox passwordBox)
        {
            _passwordBox = passwordBox;
        }

        public static readonly DependencyProperty BindingProperty = DependencyProperty.RegisterAttached("Binding", typeof(ISecurePasswordProvider), typeof(PasswordProvider), new PropertyMetadata(new PasswordProvider(null), ValueChanged));

        public static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            var binding = passwordBox.GetBindingExpression(BindingProperty);
            binding.ParentBinding.
            var stop = "here";
        }

        public static void SetBinding(DependencyObject target, ISecurePasswordProvider value)
        {
            target.SetValue(BindingProperty, value);
        }

        public static ISecurePasswordProvider GetBinding(DependencyObject target)
        {
            return (ISecurePasswordProvider)target.GetValue(BindingProperty);
        }

        public string GetPassword()
        {
            return _passwordBox.Password;
        }
    }
}
