namespace DCOM.WPF.MVVM
{
    using System;

    public class FocusRequestedEventArgs : EventArgs
    {
        public FocusRequestedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}