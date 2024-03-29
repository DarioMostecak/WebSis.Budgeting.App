﻿using Budgeting.App.Api.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Budgeting.App.Api.Brokers.UserManagers
{
    public interface IUserManagerBroker
    {
        ValueTask<User> SelectUserByEmailAsync(string email);
        ValueTask<IdentityResult> InsertUserAsync(User user, string password);
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<IdentityResult> UpdateUserAsync(User user);
        ValueTask<IdentityResult> DeleteUserAsync(User user);
        ValueTask<bool> ConfirmUserByPasswordAsync(User user, string password);
    }
}
