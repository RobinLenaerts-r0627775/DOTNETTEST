namespace Soft_Deletes_2.Models;
public class Publisher : DbEntity
{
    [Required]
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public bool IsDeleted { get; set; }
}