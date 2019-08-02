class BooksViewModel
{    
    constructor($BooksService, $window)
    {
        this.Books = [];
        this.BooksSvc = $BooksService;
        this.Window = $window;
        this.GetAllBooks();
        this.SelectedBook = null;
        this.IsFormOpen = true;

        this.GridOptions =
        {
            enableFiltering: false,
            data: 'vm.Books',
            appScopeProvider: this,
            columnDefs: [
                { name: 'Title', field: 'Title' },
                { name: 'Author', field: 'Author' },
                { name: 'PublicationDate', field: 'PublicationDate' },
                { name: 'Edition', field: 'Edition' },
                { name: '', field: 'Id', cellTemplate: '<div class="ui-grid-cell-contents" title="TOOLTIP"><input type="button" style="width: 80px;" value="Select" ng-click="grid.appScope.SelectBook(row.entity)"><input type="button" style="margin-left:10px; width: 80px;" value="Delete" ng-click="grid.appScope.DeleteBook(row.entity)"></div>' }
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

    AddNewBook()
    {
        let book = new Book();
        book.Title = this.Title;
        book.Author = this.Author;
        book.PublicationDate = this.PublicationDate;
        book.Edition = this.Edition;

        this.BooksSvc.AddAsync(book)
            .then((response) => { this.OnAddedBook( response ); });
    }

    OnAddedBook( response )
    {
        let book = new Book(response.data); // response.data es un objeto que viene de un json
        this.Books.push(book);
        this.IsFormOpen = false;
    }

    GetAllBooks()
    {
        this.BooksSvc.GetAllAsync()
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Books.length = 0;  //esto limpia el array cuando lo subimos

        for (let i in response.data)  // response.data es una lista de objetos que viene de un json
        {
            let book = new Book(response.data[i]);
            this.Books.push(book);
        }
    }

    SelectBook(book)
    {
        this.SelectedBook = book;

        this.Title = book.Title;
        this.Author = book.Author;
        this.PublicationDate = book.PublicationDate;
        this.Edition = book.Edition;

        this.IsFormOpen = true;
    }

    SaveBook()
    {
        this.SelectedBook.Title = this.Title;
        this.SelectedBook.Author = this.Author;
        this.SelectedBook.PublicationDate = this.PublicationDate;
        this.SelectedBook.Edition = this.Edition;

        this.BooksSvc.UpdateAsync(this.SelectedBook)
            .then((response) => { this.OnUpdateBook(response); });
    }

    OnUpdateBook(response)
    {
        // si la respuesta es incorrecta entonces deberíamos cambiar los datos

        this.ClearForm();
    }

    DeleteBook(book)
    {
        var r = this.Window.confirm("¿seguro que lo quieres borrar?");
        if (r === true)
        {
            this.BooksSvc.DeleteAsync(book.Id)
                .then((response) =>
                {
                    this.OnDeletedData(response, book);
                });
        }       
    }

    OnDeletedData(response, book)
    {
        if (response.data)
        {
            var indexToDelete = this.Books.findIndex(x => x.Id == book.Id);
            this.Books.splice(indexToDelete, 1);
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

app.component('books',
{
    templateUrl: './Scripts/Views/Home/Books/BooksView.html',
    controller: BooksViewModel,
    controllerAs: "vm"
});