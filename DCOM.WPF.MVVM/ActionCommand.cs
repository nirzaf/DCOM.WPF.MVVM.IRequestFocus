namespace DCOM.WPF.MVVM
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// An implementation of System.Windows.Input.ICommand that takes an Action(T) and Predicate(T).
    /// </summary>
    public class ActionCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action to invoke on command.</param>
        public ActionCommand(Action<Object> action) : this(action, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action to invoke on command.</param>
        /// <param name="predicate">The predicate that determines if the action can be invoked.</param>
        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            this.action = action ?? throw new ArgumentNullException("action", "You must specify an Action<T>.");
            this.predicate = predicate;
        }

        /// <summary>
        /// Occurs when the <see cref="CommandManager"/> detects conditions that might change the ability of a command to execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        /// <returns>
        ///     Returns true if the command can execute, otherwise returns false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (predicate == null)
            {
                return true;
            }
            return predicate(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute()
        {
            Execute(null);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}