using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KuduClient
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        protected void SetAndRaise<T>(ref T field, T newValue, [CallerMemberName]string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            if (Equals(field, newValue))
                return;

            field = newValue;
            RaisePropertyChangedInternal(propertyName);
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            RaisePropertyChangedInternal(propertyName);
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedInternal(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
