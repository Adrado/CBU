class LendsViewModel
{
    get SelectedMember()
    {
        return this._selectedMember;
    }
    set SelectedMember(value)
    {
        this._selectedMember = value;
        this.GetMemberLends();
    }

    constructor($MembersService, $BooksService, $LendsService)
    {
        this.LendsSvc = $LendsService;
        this.MembersSvc = $MembersService;
        this.BooksSvc = $BooksService;

        this.Lends = [];
        this.Books = [];
        this.Members = [];

        this._selectedMember = null;

        this.GridOptions =
            {
                enableFiltering: false,
                data: 'vm.Lends',
                appScopeProvider: this,
                columnDefs: [
                    { name: 'Book', field: 'BookComposedName' },
                    { name: '', field: 'Id', cellTemplate: '<div class="ui-grid-cell-contents" title="TOOLTIP"><input type="button" style="width: 80px;" value="Select" ng-click="grid.appScope.SelectBook(row.entity)"><input type="button" style="margin-left:10px; width: 80px;" value="Delete" ng-click="grid.appScope.DeleteBook(row.entity)"></div>' }
                ]
            };

        this.GetMembers();
        this.GetBooks();
    }

    GetMembers()
    {
        this.MembersSvc.GetAllAsync().then((response) =>
        {
            this.OnGetMembers(response);
        });
    }

    OnGetMembers(response)
    {
        this.Members.length = 0;

        for (let i in response.data)
        {
            let memberAsJson = response.data[i];
            let member = new Member(memberAsJson);
            this.Members.push(member);
        }
    }

    GetBooks()
    {
        this.BooksSvc.GetAllAsync().then((response) =>
        {
            this.OnGetBooks(response);
        });
    }

    OnGetBooks(response)
    {
        this.Books.length = 0;

        for (let i in response.data)
        {
            let bookAsJson = response.data[i];
            let book = new Book(bookAsJson);
            this.Books.push(book);
        }
    }

    GetMemberLends()
    {
        this.LendsSvc.GetLendsByMember(this.SelectedMember.Id)
            .then((response) =>
            {
                this.OnGetMemberLends(response);
            });
    }

    OnGetMemberLends(response)
    {
        this.Lends.length = 0;

        for (let i in response.data)
        {
            let lendAsJson = response.data[i];
            let lend = new Lend(lendAsJson);
            this.Lends.push(lend);
        }
    }

    RequestLend()
    {
        let lend = new Lend();
        lend.BookId = this.SelectedBook.Id;
        lend.MemberId = this.SelectedMember.Id;
        lend.DaysLended = 30;

        this.LendsSvc.AddAsync(lend).
            then((response) =>
            {
                this.GetMemberLends();
            });
    }
}


app.component('lends',
    {
        templateUrl: './Scripts/Views/Home/Lends/LendsView.html',
        controller: ['$MembersService', '$BooksService', '$LendsService', LendsViewModel],
        controllerAs: "vm"
    });