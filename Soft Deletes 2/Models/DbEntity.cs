namespace Soft_Deletes_2.Models;

public class DbEntity
{
    [Key]
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
