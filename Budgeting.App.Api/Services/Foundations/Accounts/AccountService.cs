﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Budgeting.App.Api.Brokers.Loggings;
using Budgeting.App.Api.Brokers.Storages;
using Budgeting.App.Api.Models.Accounts;

namespace Budgeting.App.Api.Services.Foundations.Accounts
{
    public partial class AccountService : IAccountService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IStorageBroker storageBroker;

        public AccountService(
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
        }

        public ValueTask<Account> AddAccountAsync(Account account) =>
        TryCatch(async () =>
        {
            //Validate account
            return await this.storageBroker.InsertAccountAsync(account);
        });


        public ValueTask<Account> RetrieveAccountById(Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
