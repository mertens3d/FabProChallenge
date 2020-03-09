using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FabProChallenge.Main.Models
{
    public class BindableData : INotifyPropertyChanged
    {
        private List<string> _allViews = new List<string>();
        private int _allViewsSelectIndex = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<string> AllViews
        {
            get
            {
                return _allViews;
            }
            set
            {
                _allViews = value;
                OnPropertyChanged();
            }
        }

        public int AllViewsSelectedIndex
        {
            get
            {
                return _allViewsSelectIndex;
            }
            set
            {
                _allViewsSelectIndex = value;
                OnPropertyChanged();
            }
        }
    }
}