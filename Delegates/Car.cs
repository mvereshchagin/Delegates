using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Delegates;

internal class Car : INotifyPropertyChanged
{
    public string _model = null!;
    public string _producer = null!;
    public int _yearOfCreate;

    public string Model 
    {
        get => _model;
        set
        {
            if (_model == value)
                return;

            _model = value;
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
            // OnPropertyChanged(nameof(Model));
            OnPropertyChanged();
        }
    }
    public string Producer
    {
        get => _producer;
        set
        {
            if (_producer == value)
                return;

            _producer = value;
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
            // OnPropertyChanged(nameof(Producer));
            OnPropertyChanged();
        }
    }

    public int YearOfCreate
    {
        get => _yearOfCreate;
        set
        {
            if (_yearOfCreate == value)
                return;

            _yearOfCreate = value;
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
            // OnPropertyChanged(nameof(YearOfCreate));
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName]string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
        return $"{Producer} {Model} {YearOfCreate}";
    }
}
