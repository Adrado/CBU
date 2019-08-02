class BooksService extends CrudService
{    

    constructor($http, $window)
    {
        super($http, $window, 'books');
    }

}

// esto le dice a Angular que creamos un service que se llama $UsersService
// para que lo inyecte 
app.service('$BooksService', BooksService);