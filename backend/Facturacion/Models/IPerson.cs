namespace Models
{
    public interface IPerson
    {
        int Id { get; set; }
        string? Complement {  get; set; }
        string? Name { get; set; }
    }
}