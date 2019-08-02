class RegisterService extends GenericService
{    
    constructor($http, $window)
    {
        super($http, $window, 'register');
    }

    RegisterAsync(email, password, imageId)
    {
        var request = new RegisterRequest(email, password, imageId);
        return this.PostAsync(request);
    }
}

// esto le dice a Angular que creamos un service que se llama $UsersService
// para que lo inyecte 
app.service('$RegisterService', RegisterService);