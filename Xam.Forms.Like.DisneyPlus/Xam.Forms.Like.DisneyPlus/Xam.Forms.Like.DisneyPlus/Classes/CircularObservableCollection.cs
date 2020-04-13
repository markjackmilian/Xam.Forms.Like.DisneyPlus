using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xam.Forms.Like.DisneyPlus.Classes
{
    public class CircularObservableCollection<T> : ObservableCollection<T>
    {
        public CircularObservableCollection(T[] linearItems) : base(linearItems)
        {
        }

        public void SetCurrentIndex(int currentCenterIndex)
        {
            if (currentCenterIndex == this.Count - 1)
            {
                var element = this[0];
                this.RemoveAt(0);
                this.Add(this[0]);
            }

            if (currentCenterIndex == 1)
            {
                var toAdd = this.Last();
                this.Remove(toAdd);
                this.Insert(0, toAdd);
            }
        }
    }
}