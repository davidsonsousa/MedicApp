namespace MedicApp.SharedKernel;

public abstract class EntityBase
{
    [NotMapped]
    public bool IsNew
    {
        get
        {
            return Id == 0 && VanityId == Guid.Empty;
        }
    }

    public bool IsDeleted { get; set; }

    [Column(Order = 0)]
    [Key]
    public long Id { get; set; }

    [Column(Order = 1)]
    public Guid VanityId { get; set; }

    public override string ToString()
    {
        var jsonResult = new JObject(
                                    new JProperty("Id", Id),
                                    new JProperty("VanityId", VanityId)
                                    );
        return jsonResult.ToString();
    }
}
