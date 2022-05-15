﻿namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class WorkScheduleExtensions
{
    /// <summary>
    /// Maps a WorkSchedule entity to a WorkScheduleEditModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static WorkScheduleEmployeeRequest MapToRequest(this WorkSchedule item)
    {
        return new WorkScheduleEmployeeRequest
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            EmployeeId = item.Person.VanityId,
            DepartmentId = item.Department.VanityId
        };
    }

    /// <summary>
    /// Maps a WorkSchedule entity to a WorkScheduleViewModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static WorkScheduleEmployeeResponse MapToResponse(this WorkSchedule? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new WorkScheduleEmployeeResponse
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            EmployeeId = item.Person.VanityId,
            DepartmentId = item.Department.VanityId
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;WorkSchedule&gt; to IEnumerable&lt;WorkScheduleViewModel&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<WorkScheduleEmployeeResponse> MapToResponse(this IEnumerable<WorkSchedule>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(workSchedule => new WorkScheduleEmployeeResponse
        {
            VanityId = workSchedule.VanityId,
            DateTimeSchedule = workSchedule.DateTimeSchedule,
            EmployeeId = workSchedule.Person.VanityId,
            DepartmentId = workSchedule.Department.VanityId
        });

    }

    /// <summary>
    /// Maps a WorkScheduleEditModel to a WorkSchedule entity
    /// </summary>
    /// <param name="item"></param>
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
