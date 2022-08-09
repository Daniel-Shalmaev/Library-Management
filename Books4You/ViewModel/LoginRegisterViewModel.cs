using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Books4You.ViewModel
{
    public class LoginRegisterViewModel : ViewModelBase
    {
        public LoginRegisterViewModel()
        {
            ExitCommand = new RelayCommand(ExitFunc);
            LoginCommand = new RelayCommand(LoginFunc);
            RegisterCommand = new RelayCommand(RegisterFunc);
        }


        private string userNameTbx;
        private string passwordTbx;

        public string UserNameTbx { get => userNameTbx; set => Set(ref userNameTbx, value); }
        public string PasswordTbx { get => passwordTbx; set => Set(ref passwordTbx, value); }

        public RelayCommand ExitCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }

        string path = @"C:\Users\danie\OneDrive\שולחן העבודה\Books4You\Books4You\Assets\Files\LoginFile.txt";

        private void ExitFunc() => Application.Current.Shutdown();

        private void LoginFunc()
        {
            string[] lines;
            lines = File.ReadAllLines(path);
            bool foundUser = false;

            for (int i = 0; i < lines.Length; i += 3)
            {
                if (lines[i] == UserNameTbx && lines[i + 1] == PasswordTbx)
                {
                    foundUser = true;
                    UserLogin.UserName = lines[i];
                    UserLogin.Password = lines[i + 1];
                    UserLogin.IsManager = lines[i + 2] == "1";
                    MainWindow mainWindow = new MainWindow();
                    Window main = new Window { Width = 1250, Height = 750 };
                    main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    main.DataContext = mainWindow.DataContext;
                    main.Content = mainWindow.Content;
                    mainWindow.Show();
                    UserNameTbx = default;
                    PasswordTbx = default;
                }
            }
            if (!foundUser) MessageBox.Show("Wrong Input , Please try again!");
        }

        private void RegisterFunc()
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            if (userNameTbx == null && passwordTbx == null)
            {
                MessageBox.Show("Please enter some input");
                return;
            }
            else if (userNameTbx == null)
            {
                MessageBox.Show("Please enter username");
                return;
            }
            else if (passwordTbx == null || passwordTbx.Length < 6)
            {
                MessageBox.Show("Please enter vailid password");
                return;
            }
            lines.Add(UserNameTbx);
            lines.Add(PasswordTbx);
            lines.Add("0");
            File.WriteAllLines(path, lines);
            MessageBox.Show("Succeed");
            UserNameTbx = default;
            PasswordTbx = default;
        }
    }
}

