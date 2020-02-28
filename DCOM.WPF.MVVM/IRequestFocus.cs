namespace DCOM.WPF.MVVM
{
    using System;

    public interface IRequestFocus
    {
        event EventHandler<FocusRequestedEventArgs> FocusRequested;
    }
}