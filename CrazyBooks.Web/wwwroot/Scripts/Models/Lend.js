class Lend extends Entity
{
    constructor(json)
    {
        super(json);

        if (json)
        {
            this.Book = json.book;
            this.Member = json.member;
            this.LendedOn = json.lendedOn;
            this.BookComposedName = json.bookComposedName;
        }
        else
        {
            this.LendedOn = new Date();
            this.Book =  null;
            this.Member = null;
        }
    }
}