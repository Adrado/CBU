class LendsService extends CrudService
{    
    constructor($http, $window)
    {
        super($http, $window, 'lends');
    }

    GetLendsByMember(memberId)
    {
        return this.Http.get(this.ApiUrl + "/ByMember/" + memberId, this.Config);
    }
}

// esto le dice a Angular que creamos un service que se llama $UsersService
// para que lo inyecte 
app.service('$LendsService', LendsService);