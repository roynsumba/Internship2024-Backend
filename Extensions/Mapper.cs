using System.Reflection;

namespace AppraisalTracker.Extensions;
public static class ConfigureMapper
{
    public static void ConfigureAutoMapper(this WebApplicationBuilder builder, params Assembly[] assemblies)
    {
        builder.Services.AddAutoMapper(config =>
        {
            var exportedTypes = assemblies.SelectMany(it => it.GetExportedTypes()).ToList();
            var viewModels = exportedTypes
                .Where(it => it.IsClass && (
                    it.Name.EndsWith("ViewModel") ||
                    it.Name.EndsWith("UpdateModel") ||
                    it.Name.EndsWith("CreateModel")
                ))
                .ToList();

            var viewNames = viewModels.Select(it => it.Name);
            var modelNames = viewNames
                .Where(it => it.EndsWith("ViewModel"))
                .Select(it => it.Replace("ViewModel", ""))
                .ToList();

            var models = exportedTypes
                .Where(it => it.IsClass && modelNames.Contains(it.Name))
                .ToList();

            viewModels.ForEach(viewModel =>
            {
                var modelName = viewModel.Name
                    .Replace("ViewModel", "")
                    .Replace("UpdateModel", "")
                    .Replace("CreateModel", "");
                var model = models.FirstOrDefault(m => m.Name == modelName);
                if (model == null) return;

                Console.WriteLine($@"AutoMapper >> Model:{model.Name}, View:{viewModel.Name}");
                config.CreateMap(model, viewModel);
                config.CreateMap(viewModel, model);
            });

        }, assemblies);
    }
}
