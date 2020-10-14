using PPM.Domain.ValueObject;
using PPM.Locations.Domain;

namespace PPM.Locations.Infrastructure.Documents.Progress
{
    public static class Extensions
    {
        public static PackageProgressDocument ToDocument(this PackageProgress progress)
        {
            return new PackageProgressDocument()
            {
                FlowId = progress.FlowId,
                CurrentStepNumber = progress.CurrentStepNumber,
                Id = progress.Id,
                IsValid = progress.IsValid,
                LocationId = progress.LocationId,
                PackageId = progress.PackageId,
                Percentage = progress.Percentage.Value
            };
        }
        public static PackageProgress AsEntity(this PackageProgressDocument packageProgress)
        {
            return new PackageProgress(packageProgress.Id, packageProgress.PackageId, packageProgress.LocationId,
                packageProgress.FlowId, packageProgress.CurrentStepNumber, packageProgress.IsValid,
                Percentage.Of(packageProgress.Percentage));
        }
    }
}
