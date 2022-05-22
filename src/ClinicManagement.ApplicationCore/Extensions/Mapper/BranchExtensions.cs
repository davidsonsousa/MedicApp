﻿namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class BranchExtensions
{
    /// <summary>
    /// Maps a Branch entity to a BranchRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static BranchRequest MapToRequest(this Branch item)
    {
        return new BranchRequest
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Address = item.Address,
            ClinicId = item.Clinic.VanityId,
            SelectedDepartments = item.Departments.Select(b => b.VanityId).ToArray()
        };
    }

    /// <summary>
    /// Maps a Branch entity to a BranchResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static BranchDetailResponse MapToResponse(this Branch? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new BranchDetailResponse
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Address = item.Address,
            Departments = item.Departments.Select(d => new BranchDepartmentItem
            {
                VanityId = d.VanityId,
                Name = d.Name
            })
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Branch&gt; to IEnumerable&lt;BranchResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<BranchResponse> MapToResponse(this IEnumerable<Branch>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(branch => new BranchResponse
        {
            VanityId = branch.VanityId,
            Name = branch.Name,
            Address = branch.Address,
            DepartmentIds = branch.Departments.Select(b => b.VanityId).ToArray()
        });
    }

    /// <summary>
    /// Maps a BranchRequest to a Branch entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Branch MapToEntity(this BranchRequest item, Clinic? clinic)
    {
        Guard.Against.Null(clinic, nameof(clinic));

        return new Branch
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Address = item.Address,
            ClinicId = clinic.Id,
        };
    }

    /// <summary>
    /// Maps a BranchRequest to an existing Branch entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Branch MapToEntity(this BranchRequest item, Branch? branch, Clinic? clinic)
    {
        Guard.Against.Null(branch, nameof(branch));
        Guard.Against.Null(clinic, nameof(clinic));

        branch.Name = item.Name;
        branch.Address = item.Address;
        branch.ClinicId = clinic.Id;

        return branch;
    }
}
