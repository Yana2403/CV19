using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CV19.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged //интерфейс для изменений

    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName=null)//можно не указывать переменную,в этом случае подставится имя метода, откуда идет вызов
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)  //для разрешения кольцевых обновлений свойств(когда одно за другим)
        {
            if (Equals(field, value)) return false; //если поле уже заполнено нужным, то ничего не делаем
            field = value; //если нет,то обновляем
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
