class Member extends User
{
    get ComposedName()
    {
        return this.Name + " " + this.Surname1 + ", " + this.Email;
    }
        

    constructor(json)
    {
        super(json);
    }
}