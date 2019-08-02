class MembersViewModel
{    
    constructor($MembersService, $window)
    {
        this.Members = [];
        this.MembersSvc = $MembersService;
        this.Window = $window;
        this.GetAllMembers();
        this.SelectedMember = null;
        this.IsFormOpen = true;

        this.GridOptions =
        {
            enableFiltering: false,
            data: 'vm.Members',
            appScopeProvider: this,
            columnDefs: [
                { name: 'Name', field: 'Name' },
                { name: 'Email', field: 'Email' },
                { name: 'Surname1', field: 'Surname1' },
                { name: 'Surname2', field: 'Surname2' },
                { name: '', field: 'Id', cellTemplate: '<div class="ui-grid-cell-contents" title="TOOLTIP"><input type="button" style="width: 80px;" value="Select" ng-click="grid.appScope.SelectMember(row.entity)"><input type="button" style="margin-left:10px; width: 80px;" value="Delete" ng-click="grid.appScope.DeleteMember(row.entity)"></div>' }
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

    AddNewMember()
    {
        let member = new Member();

        member.Name = this.Name;
        member.Surname1 = this.Surname1;
        member.Surname2 = this.Surname2;
        member.Password = this.Password;
        member.Email = this.Email;
        
        this.MembersSvc.AddAsync(member)
            .then((response) => { this.OnAddedMember( response ); });
    }

    OnAddedMember( response )
    {
        let member = new Member(response.data); // response.data es un objeto que viene de un json
        this.Members.push(member);
        this.IsFormOpen = false;
    }

    GetAllMembers()
    {
        this.MembersSvc.GetAllAsync()
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Members.length = 0;  //esto limpia el array cuando lo subimos

        for (let i in response.data)  // response.data es una lista de objetos que viene de un json
        {
            let member = new Member(response.data[i]);
            this.Members.push(member);
        }
    }

    SelectMember(member)
    {
        this.SelectedMember = member;

        this.Name = member.Name;
        this.Surname1 = member.Surname1;
        this.Surname2 = member.Surname2;
        this.Password = member.Password;
        this.Email = member.Email;

        this.IsFormOpen = true;
    }

    SaveMember()
    {
        this.SelectedMember.Name = this.Name;
        this.SelectedMember.Surname1 = this.Surname1;
        this.SelectedMember.Surname2 = this.Surname2;
        this.SelectedMember.Password = this.Password;
        this.SelectedMember.Email = this.Email;

        this.MembersSvc.UpdateAsync(this.SelectedMember)
            .then((response) => { this.OnUpdateMember(response); });
    }

    OnUpdateMember(response)
    {
        // si la respuesta es incorrecta entonces deberíamos cambiar los datos

        this.ClearForm();
    }

    DeleteMember(member)
    {
        var r = this.Window.confirm("¿seguro que lo quieres borrar?");
        if (r === true)
        {
            this.MembersSvc.DeleteAsync(member.Id)
                .then((response) =>
                {
                    this.OnDeletedData(response, member);
                });
        }       
    }

    OnDeletedData(response, member)
    {
        if (response.data)
        {
            var indexToDelete = this.Members.findIndex(x => x.Id.toString() === member.Id.toString());
            this.Members.splice(indexToDelete, 1);
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

app.component('members',
{
    templateUrl: './Scripts/Views/Home/Members/MembersView.html',
    controller: MembersViewModel,
    controllerAs: "vm"
});