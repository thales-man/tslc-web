// -----------------------------------------------------------------------------
// copyright (c) 2016, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tiny.Framework.Utility;

namespace Front.Services.ViewModels
{
    /// <summary>
    /// the observable base abstract class.
    /// </summary>
    /// <seealso cref="INotifyPropertyChanged" />
    public abstract class ObservableItem :
        INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="T">the type of value being set.</typeparam>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>true if it changes.</returns>
        /// <exception cref="ArgumentNullException">MemberName cannot be null.</exception>
        protected bool SetPropertyValue<T>(ref T oldValue, T newValue, [CallerMemberName] string memberName = "")
        {
            It.IsEmpty(memberName)
                .AsGuard<ArgumentNullException>(nameof(memberName));

            // check to see if it's changed
            if (It.IsDifferent(oldValue, newValue))
            {
                // overwrite the old value
                oldValue = newValue;

                // let's tell everybody
                OnPropertyChanged(memberName);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
