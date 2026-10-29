using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LoginAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // TextBlock
    [ObservableProperty] private string _greeting = "Benvenuto!";

    // TextBox
    [ObservableProperty] private string _nomeUtente = string.Empty;

    // Testo del Button 
    [ObservableProperty] private string _statusLogin = "LOGIN";
    
    // Comando del Button 
    [RelayCommand]
    private void Login()
    {
        if (StatusLogin == "LOGIN")
        {
            // LOGIN
            Greeting = "Benvenuto/a " + NomeUtente;
            StatusLogin = "LOGOUT";
        }
        else
        {
            // LOGOUT
            Greeting = "Arrivederci";
            NomeUtente = string.Empty; 
            StatusLogin = "LOGIN";
        }
    }
}