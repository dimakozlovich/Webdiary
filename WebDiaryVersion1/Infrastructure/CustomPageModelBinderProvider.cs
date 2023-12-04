using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebDiaryVersion1.BL.General;

namespace WebDiaryVersion1.Infrastructure
{
    public class CustomPageModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            // Для объекта SimpleTypeModelBinder необходим сервис ILoggerFactory
            // Получаем его из сервисов
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder binder = new PageModelBinder(new SimpleTypeModelBinder(typeof(string[,,]), loggerFactory));
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}
