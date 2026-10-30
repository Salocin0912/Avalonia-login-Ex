using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace LoginAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // TextBlock di benvenuto
    [ObservableProperty] private string _greeting = "Benvenuto!";

    // TextBox modificata in Password (al posto di _nomeUtente)
    [ObservableProperty] private string _password = string.Empty;

    // Testo del Button 
    [ObservableProperty] private string _statusLogin = "LOGIN";

    // Item selezionato dalla ListBox
    [ObservableProperty] private string? _selectedName;

    // Sorgente dati (ItemsSource) per la ListBox
    public ObservableCollection<string> Names { get; } = new()
    {
        "Nicolas", "Martia", "Vegito", "Guts", "San Michele"
    };

    private bool _isLoggedIn = false;

    // Metodo parziale generato dal Toolkit: si attiva automaticamente al cambio di selezione
    partial void OnSelectedNameChanged(string? value)
    {
        // Se l'utente è loggato, aggiorna il messaggio di conseguenza 
        if (_isLoggedIn && !string.IsNullOrEmpty(value))
        {
            Greeting = "Benvenuto/a " + value;
        }
    }

    // Comando del Button 
    [RelayCommand]
    private void Login()
    {
        if (StatusLogin == "LOGIN")
        {
            // LOGIN
            string nameToGreet = !string.IsNullOrEmpty(SelectedName) ? SelectedName : "Ospite";
            Greeting = "Benvenuto/a " + nameToGreet;
            StatusLogin = "LOGOUT";
            _isLoggedIn = true;
        }
        else
        {
            // LOGOUT
            Greeting = "Bye Bye";
            StatusLogin = "LOGIN";
            
            // Ripristino dello stato iniziale
            Password = string.Empty; 
            SelectedName = null; 
            _isLoggedIn = false;
        }
    }
}