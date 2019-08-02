class AdminsViewModel
{
    constructor($AdminsService, $window)
    {
        this.Admins = [];
        this.AdminsSvc = $AdminsService;
        this.Window = $window;
        this.GetAllAdmins();
        this.SelectedAdmin = null;
        this.IsFormOpen = true;

        this.GridOptions =
            {
                enableFiltering: false,
                data: 'vm.Admins',
                appScopeProvider: this,
                columnDefs: [
                    { name: 'Name', field: 'Name' },
                    { name: 'Email', field: 'Email' },
                    { name: 'Surname1', field: 'Surname1' },
                    { name: 'Surname2', field: 'Surname2' },
                    { name: '', field: 'Id', cellTemplate: '<div class="ui-grid-cell-contents" title="TOOLTIP"><input type="button" style="width: 80px;" value="Select" ng-click="grid.appScope.SelectAdmin(row.entity)"><input type="button" style="margin-left:10px; width: 80px;" value="Delete" ng-click="grid.appScope.DeleteAdmin(row.entity)"></div>' }
                ]
            };
    }

    get IsListOpen()
    {
        return !this.IsFormOpen;
    }
    set IsListOpen(value)
    {
        this.IsFormOpen = !value;
    }

    AddNewAdmin()
    {
        let admin = new Admin();

        admin.Name = this.Name;
        admin.Surname1 = this.Surname1;
        admin.Surname2 = this.Surname2;
        admin.Password = this.Password;
        admin.Email = this.Email;

        this.AdminsSvc.AddAsync(admin)
            .then((response) => { this.OnAddedAdmin(response); });
    }

    OnAddedAdmin(response)
    {
        let admin = new Admin(response.data); // response.data es un objeto que viene de un json
        this.Admins.push(admin);
        this.IsFormOpen = false;
    }

    GetAllAdmins()
    {
        this.AdminsSvc.GetAllAsync()
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Admins.length = 0;  //esto limpia el array cuando lo subimos

        for (let i in response.data)  // response.data es una lista de objetos que viene de un json
        {
            let admin = new Admin(response.data[i]);
            this.Admins.push(admin);
        }
    }

    SelectAdmin(admin)
    {
        this.SelectedAdmin = admin;

        this.Name = admin.Name;
        this.Surname1 = admin.Surname1;
        this.Surname2 = admin.Surname2;
        this.Password = admin.Password;
        this.Email = admin.Email;

        this.IsFormOpen = true;
    }

    SaveAdmin()
    {
        this.SelectedAdmin.Name = this.Name;
        this.SelectedAdmin.Surname1 = this.Surname1;
        this.SelectedAdmin.Surname2 = this.Surname2;
        this.SelectedAdmin.Password = this.Password;
        this.SelectedAdmin.Email = this.Email;

        this.AdminsSvc.UpdateAsync(this.SelectedAdmin)
            .then((response) => { this.OnUpdateAdmin(response); });
    }

    OnUpdateAdmin(response)
    {
        // si la respuesta es incorrecta entonces deberíamos cambiar los datos

        this.ClearForm();
    }

    DeleteAdmin(admin)
    {
        var r = this.Window.confirm("¿seguro que lo quieres borrar?");
        if (r === true)
        {
            this.AdminsSvc.DeleteAsync(admin.Id)
                .then((response) =>
                {
                    this.OnDeletedData(response, admin);
                });
        }
    }

    OnDeletedData(response, admin)
    {
        if (response.data)
        {
            var indexToDelete = this.Admins.findIndex(x => x.Id.toString() === admin.Id.toString());
            this.Admins.splice(indexToDelete, 1);
        }
    }

    ClearForm()
    {
        this.Title = "";
        this.Author = "";
        this.PublicationDate = new Date();
        this.Edition = 0;
    }
}

app.component('admins',
    {
        templateUrl: './Scripts/Views/Home/Admins/AdminsView.html',
        controller: AdminsViewModel,
        controllerAs: "vm"
    });