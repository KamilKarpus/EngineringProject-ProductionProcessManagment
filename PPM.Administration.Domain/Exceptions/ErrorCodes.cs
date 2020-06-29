namespace PPM.Administration.Domain.Exceptions
{
    public enum ErrorCodes
    {
        FlowIsNotEditable = 1001,
        StepPositionCannotBeChanged = 1002,
        ValidationErrorMaxPercentage = 1003,
        ValidationErrorStepPercentage = 1004,
        ValidationErrorMaxDaysError = 1005,
        NameIsTaken = 1006,
        LocationNotExists = 1007,
        FirstLocationMustSupportPrinting = 1008,
        FlowDoesNotExists = 1009,
    }
}
