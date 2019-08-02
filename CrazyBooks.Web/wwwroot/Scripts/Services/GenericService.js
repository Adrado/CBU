class GenericService
{
    get Config()
    {
        var config =
        {
            headers:
            {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.Token
            }
        };
        return config;
    }

    constructor($http, $window, dtoName)
    {
        this.Http = $http;
        this.Token = $window.Token;
        this.ApiUrl = "api/" + dtoName;
    }


    
    GetAllAsync()
    {
        return this.Http.get(this.ApiUrl, this.Config);
    }

    GetByIdAsync(id)
    {
        return this.Http.get(this.ApiUrl + "/" + id, this.Config);
    }

    PostAsync(dto)
    {
        return this.Http.post(this.ApiUrl, dto, this.Config);
    }

    PutAsync(dto)
    {
        return this.Http.put(this.ApiUrl, dto, this.Config);
    }

    DeleteAync(id)
    {
        return this.Http.delete(this.ApiUrl + "/" + id, this.Config);
    }
}