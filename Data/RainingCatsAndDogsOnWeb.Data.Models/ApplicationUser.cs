﻿// ReSharper disable VirtualMemberCallInConstructor
namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System;
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static RainingCatsAndDogsOnWeb.Common.DataConstants.ApplicationUser;


    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
