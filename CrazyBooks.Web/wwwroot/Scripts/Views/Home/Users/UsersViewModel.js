class UsersViewModel
{
    constructor($UsersService)
    {
        this.Users = [];
        this.UsersSvc = $UsersService;
        this.GetAllUsers();
    }

    AddNewUser()
    {
        let user = new User();
        user.Name = "Pepe";
        user.Surname = "Laaaa";
        user.Password = "1234";
        
        this.UsersSvc.AddAsync(user)
            .then(function (response)
            {
                alert("add success for " + response.data.name);
            });
    }

    GetAllUsers()
    {
        this.UsersSvc.GetAllAsync()
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        //this.Message = JSON.stringify(response.data);
        this.Users = response.data;
    }
}

app.component('users',
{
    templateUrl: './Scripts/Views/Home/Users/UsersView.html',
    controller: UsersViewModel,
    controllerAs: "vm"
});