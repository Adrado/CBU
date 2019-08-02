class IndexViewModel
{
    constructor($window)
    {
        this.Window = $window;
    }

    IsLogon()
    {
        if (!this.Window || this.Window.LogonUser === null || this.Window.LogonUser === undefined)
            return false;
        else
            return true;
    }

    IsStartVisible()
    {
        let c1 = !this.IsLogon();
        let c2 = !this.Window.IsLoading;
        return c1 && c2;
    }

    IsLoading()
    {
        return this.Window.IsLoading;
    }
   
}

app.component('index',
    {
        templateUrl: './Scripts/Views/IndexView.html',
        controller: IndexViewModel,
        controllerAs: "vm"
    });