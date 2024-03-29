﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Budgeting.Web.App.Models.AuthenticationRequests;
using Budgeting.Web.App.Models.AuthenticationResults;

namespace Budgeting.Web.App.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<AuthenticationResult> PostLoginAsync(AuthenticationRequest AuthenticationRequest);
    }
}
