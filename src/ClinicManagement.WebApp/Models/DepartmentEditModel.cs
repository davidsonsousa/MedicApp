﻿using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.WebApp.Models;

public class DepartmentEditModel
{
    [Required]
    public Guid VanityId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}
