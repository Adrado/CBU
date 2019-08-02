class HeaderViewModel
{
    constructor($window)
    {
        this.Window = $window;
    }

    UserEmail()
    {
        if (this.Window && this.Window.LogonUser)
            return this.Window.LogonUser.email;
        else
            return "";
    }
}

app.component('header',
{
    templateUrl: './Scripts/Views/Home/Header/HeaderView.html',
    controller: HeaderViewModel,
    controllerAs: "vm"
});