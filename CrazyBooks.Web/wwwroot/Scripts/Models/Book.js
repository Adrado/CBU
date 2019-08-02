class Book extends Entity
{
    get ComposedName()
    {
        return this.Title + ", " + this.Author;
    }

    constructor(json)
    {
        super( json);

        if (json)
        {
            this.Title = json.title;
            this.Author = json.author;
            this.PublicationDate = json.publicationDate;
            this.Edition = json.edition;
        }
        else
        {
            this.Title = "";
            this.Author = "";
            this.PublicationDate = null;
            this.Edition = 0;
        }
    }
}