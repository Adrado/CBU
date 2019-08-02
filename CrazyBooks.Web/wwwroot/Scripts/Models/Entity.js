class Entity
{
    constructor(json)
    {
        if (json)
        {
            this.Id = json.id.toString();
        }
        else
        {
            this.Id = "00000000-0000-0000-0000-000000000000";
        }
    }
}