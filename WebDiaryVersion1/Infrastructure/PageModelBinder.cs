

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebDiaryVersion1.BL.General
{
    public class PageModelBinder : Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public PageModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }
        Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
        {
            string[,,] week = new string[6, 7, 2];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        string InputsName = $"{i}{j}{k}";
                        var InputsValue = bindingContext.ValueProvider.GetValue(InputsName);
                        string? value = InputsValue.FirstValue;
                        week[i, j, k] = value ?? "что-то";
                    }

                }
            }
            bindingContext.Result = ModelBindingResult.Success(week);
            return Task.CompletedTask;
        }
    }
}
