using Budgeting.App.Api.Brokers.DateTimes;
using Budgeting.App.Api.Brokers.Loggings;
using Budgeting.App.Api.Brokers.Storages;
using Budgeting.App.Api.Services.Foundations.Categories;

namespace Budgeting.App.Api.Registrars
{
    public class ApplicationServiceRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            #region Add Brokers
            builder.Services.AddSingleton<IStorageBroker, StorageBroker>();
            builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
            builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            #endregion

            #region Add Foundations
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            #endregion

            #region Add ProccesService

            #endregion
        }
    }
}
