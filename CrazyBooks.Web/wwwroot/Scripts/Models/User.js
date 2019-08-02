class User extends Entity
{
    constructor(json)
    {
        super(json);

        if (json)
        {
            this.Name = json.name;
            this.Surname1 = json.surname1;
            this.Surname2 = json.surname2;
            this.Password = json.password;
            this.Email = json.email;
        }
        else
        {
            this.Name = "";
            this.Surname1 = "";
            this.Surname2 = "";
            this.Email = "";
            this.Password = "";
        }
    }
}