namespace Soft_Deletes_2.Models;
public class Book : DbEntity
{
    [Key]
    public string ISBN { get; set; }
    [Required]
    public string Title { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }
    public int Pages { get; set; }
    public virtual Publisher Publisher { get; set; }
    public bool IsDeleted { get; set; }
}