class CrudService extends GenericService
{    
    constructor($http, $window, model)
    {
        super($http, $window, model);
    }

    AddAsync(dto)
    {
        return this.PostAsync(dto);
    }

    UpdateAsync(dto)
    {
        return this.Put(dto);
    }

    DeleteAsync(id)
    {
        return this.DeleteAync(id);
    }
}