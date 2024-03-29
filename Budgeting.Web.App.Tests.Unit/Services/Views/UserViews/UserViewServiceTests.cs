﻿using Budgeting.Web.App.Brokers.DateTimes;
using Budgeting.Web.App.Brokers.Loggings;
using Budgeting.Web.App.Brokers.Navigations;
using Budgeting.Web.App.Brokers.UniqueIDGenerators;
using Budgeting.Web.App.Models.ExceptionModels;
using Budgeting.Web.App.Models.UserViews;
using Budgeting.Web.App.Services.Foundations.Users;
using Budgeting.Web.App.Services.Views.UserViews;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace Budgeting.Web.App.Tests.Unit.Services.Views.UserViews
{
    public partial class UserViewServiceTests
    {
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBroker;
        private readonly Mock<IUniqueIDGeneratorBroker> uniqueIDGeneratorBroker;
        private readonly Mock<INavigationBroker> navigationBrokerMock;
        private readonly IUserViewService userViewService;

        public UserViewServiceTests()
        {
            this.userServiceMock = new Mock<IUserService>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBroker = new Mock<IDateTimeBroker>();
            this.uniqueIDGeneratorBroker = new Mock<IUniqueIDGeneratorBroker>();
            this.navigationBrokerMock = new Mock<INavigationBroker>();

            this.userViewService = new UserViewService(
                userService: this.userServiceMock.Object,
                loggingBroker: this.loggingBrokerMock.Object,
                dateTimeBroker: this.dateTimeBroker.Object,
                uniqueIDGeneratorBroker: this.uniqueIDGeneratorBroker.Object,
                navigationBroker: this.navigationBrokerMock.Object);
        }

        private static Expression<Func<ExceptionModel, bool>> SameExceptionAs(ExceptionModel expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as ExceptionModel).DataEquals(expectedException.InnerException.Data);
        }

        private static UserView CreateUserView() =>
            new UserView
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test1",
                Email = "Test@mail.com",
                Password = "password",
                ConfirmPassword = "password",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(10),
            };

        private static IEnumerable<object[]> InvalidDataUserView() =>
            new List<object[]> {

                new object[] { null, null, null, null, "11111111"},
                new object[] { string.Empty, string.Empty, string.Empty, string.Empty, "11111111"},

                new object[] {
                    new MnemonicString(1, 1, 2).GetValue(),
                    new MnemonicString(1, 1, 2).GetValue(),
                    "ddddd@",
                    new MnemonicString(1, 1, 7).GetValue(),
                    "11111111"
                },

                new object[]
                {
                     new MnemonicString(1, 21, 30).GetValue(),
                     new MnemonicString(1, 21, 30).GetValue(),
                     "ddddd@",
                     new MnemonicString(1, 26, 30).GetValue(),
                     "11111111"
                }

            };
    }
}
