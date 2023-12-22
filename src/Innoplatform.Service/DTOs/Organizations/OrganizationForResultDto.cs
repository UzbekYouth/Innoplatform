﻿using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Organizations;

public class OrganizationForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string CallCenter { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Hash { get; set; }
    public string Address { get; set; }
    public Roles Role { get; set; }
}
