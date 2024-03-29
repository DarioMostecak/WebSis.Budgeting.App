﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Budgeting.App.Api.Brokers.DateTimes;
using Budgeting.App.Api.Brokers.DbTransactions;
using Budgeting.App.Api.Brokers.Loggings;
using Budgeting.App.Api.Brokers.UniqueIDGenerators;
using Budgeting.App.Api.Models.Accounts;
using Budgeting.App.Api.Models.Users;
using Budgeting.App.Api.Services.Foundations.Accounts;
using Budgeting.App.Api.Services.Foundations.Users;

namespace Budgeting.App.Api.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDbTransactionBroker dbTransactionBroker;
        private readonly IUniqueIDGeneratorBroker uniqueIDGeneratorBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public UserOrchestrationService(
            IUserService userService,
            IAccountService accountService,
            ILoggingBroker loggingBroker,
            IDbTransactionBroker dbTransactionBroker,
            IUniqueIDGeneratorBroker uniqueIDGeneratorBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.userService = userService;
            this.accountService = accountService;
            this.loggingBroker = loggingBroker;
            this.dbTransactionBroker = dbTransactionBroker;
            this.uniqueIDGeneratorBroker = uniqueIDGeneratorBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<User> RegisterUserAsync(User user, string password) =>
        TryCatch(async () =>
        {
            ValidateUserIsNull(user);
            ValidatePasswordIsNull(password);

            this.dbTransactionBroker.BeginTransaction();

            User newUser =
                await this.userService.AddUserAsync(user, password);

            ValidateNewUserIsNull(newUser);

            Account account = CreateAccount(newUser.Id.ToString());

            Account newUserAccount =
               await this.accountService.AddAccountAsync(account);

            ValidateNewUserAccountIsNull(newUserAccount);

            ValidateAccountIdentityIdNotEqualToUserId(
                newUser: newUser,
                newUserAccount: newUserAccount);

            this.dbTransactionBroker.CommitTransaction();

            return user;
        });

        private Account CreateAccount(string userIdentityId)
        {
            DateTime currentDateTime =
                this.dateTimeBroker.GetCurrentDateTime();

            Guid accountId =
                this.uniqueIDGeneratorBroker.GenerateUniqueID();

            decimal initialBalance = 0;

            return new Account
            {
                AccountId = accountId,
                UserIdentityId = userIdentityId,
                Balance = initialBalance,
                TimeCreated = currentDateTime,
                TimeModify = currentDateTime,
            };
        }



    }
}
