﻿using Budgeting.App.Api.Models.Users;
using Budgeting.App.Api.Models.Users.Exceptions;
using MongoDB.Driver;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Budgeting.App.Api.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShoudThrowDependencyExceptionOnModifyIfMongoExceptionOccures()
        {
            //given
            User someUser = CreateUser();
            MongoException mongoException = GetMongoException();

            var failedUserServiceException =
                new FailedUserServiceException(mongoException);

            var expectedUserDependencyException =
                new UserDependencyException(failedUserServiceException);

            this.userManagerBrokerMock.Setup(manager =>
                manager.SelectUserByIdAsync(It.IsAny<Guid>()))
                  .ThrowsAsync(mongoException);

            //when
            ValueTask<User> modifyUserTask =
                this.userService.ModifyUserAsync(someUser);

            //then
            await Assert.ThrowsAsync<UserDependencyException>(() =>
                 modifyUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                 broker.LogError(It.Is(SameExceptionAs(
                     expectedUserDependencyException))),
                       Times.Once);

            this.userManagerBrokerMock.Verify(manager =>
                 manager.SelectUserByIdAsync(It.IsAny<Guid>()),
                   Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerBrokerMock.VerifyNoOtherCalls();
        }
    }
}
