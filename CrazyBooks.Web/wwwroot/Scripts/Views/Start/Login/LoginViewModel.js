class LoginViewModel
{    
    constructor($LoginService, $window)
    {
        this.LoginService = $LoginService;
        this.Window = $window;

        this.Email = "s@s";
        this.Password = "1234";
    }   

    Login()
    {
        this.Window.IsLoading = true;
        this.LoginService.LoginAsync(this.Email, this.Password)
            .then((response) =>
            {
                if (response.data !== "")
                {
                    this.Window.Token = response.data.token;
                    this.Window.LogonUser = response.data;
                }
                else
                {
                    alert("Usuario incorrecto");
                }
                this.Window.IsLoading = false;
            },
            (error) =>
            {
                alert(error.data.message);
                this.Window.Token = null;

                this.Window.IsLoading = false;
            });
    }
}

app.component('login',
{
    templateUrl: './Scripts/Views/Start/Login/LoginView.html',
    controller: LoginViewModel,
    controllerAs: "vm"
});