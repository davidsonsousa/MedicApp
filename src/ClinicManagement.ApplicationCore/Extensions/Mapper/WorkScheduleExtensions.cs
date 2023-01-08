using ClinicManagement.ApplicationCore.Models.Responses.WorkScheduleEmployee;

namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class WorkScheduleExtensions
{
    /// <summary>
    /// Maps a WorkSchedule entity to a WorkScheduleEmployeeResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static WorkScheduleEmployeeResponse MapToResponse(this WorkSchedule? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new WorkScheduleEmployeeResponse
        {
            Item = item.MapToItem()
        };
    }

    /// <summary>
    /// Maps a WorkSchedule entity to a WorkScheduleEmployeeItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static WorkScheduleEmployeeItem MapToItem(this WorkSchedule? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new WorkScheduleEmployeeItem
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            EmployeeId = item.Person.VanityId,
            DepartmentId = item.Department.VanityId
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;WorkSchedule&gt; to WorkScheduleEmployeeListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static WorkScheduleEmployeeListResponse MapToListResponse(this IEnumerable<WorkSchedule>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new WorkScheduleEmployeeListResponse
        {
            Items = items.Select(wse => wse.MapToItem())
        };
    }

    /// <summary>
    /// Maps a WorkScheduleEditModel to a WorkSchedule entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="person"></param>
    /// <param name="department"></param>
    /// <returns></returns>
    public static WorkSchedule MapToEntity(this WorkScheduleEmployeeRequest item, Person? person, Department? department)
    {
        Guard.Against.Null(person, nameof(person));
        Guard.Against.Null(department, nameof(department));

        return new WorkSchedule
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            PersonId = person.Id,
            DepartmentId = department.Id
        };
    }

    /// <summary>
    /// Maps a WorkScheduleEditModel to an existing WorkSchedule entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="workSchedule"></param>
    /// <returns></returns>
    public static WorkSchedule MapToEntity(this WorkScheduleEmployeeRequest item, WorkSchedule? workSchedule)
    {
        Guard.Against.Null(workSchedule, nameof(workSchedule));

        item.DateTimeSchedule = item.DateTimeSchedule;
        item.EmployeeId = workSchedule.Person.VanityId;
        item.DepartmentId = workSchedule.Department.VanityId;

        return workSchedule;
    }
}
